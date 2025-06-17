using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;
    [SerializeField] private string _enemyTag;
    private float _damage;
    private Transform _target;
    private bool _isMove;

    public void Init(float damage, Transform target)
    {
        _damage = damage;
        _target = target;
        _isMove = true;
        Destroy(gameObject, _destroyTime);
    }

    public float GetDamage()
    {
        return _damage;
    }

    private void Update()
    {
        if (_isMove) Move(_target);
    }

    private void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isMove || collision.gameObject.tag != _enemyTag) return;
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
            return;
        }
        Destroy(gameObject);
    }

}
