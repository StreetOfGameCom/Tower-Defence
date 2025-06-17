using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private ObjectViewManager _viewManager;
    [SerializeField] private GameObject _bulletObject;
    [SerializeField] private Transform _spawnBulletPosition;

    [SerializeField] private float _checkDistance;
    [SerializeField] private LayerMask _targetLayer;

    private Transform _target;
    private Quaternion _initRotate;
    private float _time;
    private float _damage;
    private float _shootDelay;

    public void Init(TowerUpgrateData data)
    {
        _viewManager.SetView(data);
        _damage = data.Damage;
        _shootDelay = data.ShootDelay;
        _initRotate = transform.localRotation;
    }

    private void Update()
    {
        if (_target == null)
            _target = FindTarget();
        else
        {
            RotateTower(_target);
            if (!CheckTargetIsInDistance())
            {
                _target = null;
                transform.localRotation = _initRotate;
            }
            else
            {
                if (_time >= _shootDelay)
                {
                    Shoot();
                    _time = 0;
                }
                _time += Time.deltaTime;
            }
        }

    }

    private void RotateTower(Transform huntedObject)
    {
        Vector3 direction = huntedObject.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private Transform FindTarget()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, _checkDistance, (Vector2)transform.position, 0f, _targetLayer);
        if(hit.Length > 0) return hit[0].transform;
        return null;
    }

    private bool CheckTargetIsInDistance()
    {
        if(Vector2.Distance(transform.position, _target.position) < _checkDistance && _target.gameObject.active == true) return true;
        return false;
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletObject, _spawnBulletPosition.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.Init(_damage, _target);
    }
}
