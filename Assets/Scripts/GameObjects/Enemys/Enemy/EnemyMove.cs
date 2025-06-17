using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Vector3[] _route;
    [SerializeField] private EnemyPoolObject _enemyPool;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isMove = false;
    private int _lastPosition;
    public void Init(Vector3[] route)
    {
        _route = route;
        _isMove = false;
        _lastPosition = 0;
    }

    public void SetSpeed(float speed) => _speed = speed;

    public void StartMove()
    {
        _lastPosition = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _isMove = true;
    }

    public void StopMove()
    {
        _isMove = false;
        _lastPosition = 0;
    }

    private void Update()
    {
        if (_isMove)
        {
            if (transform.position == _route[_lastPosition] && _lastPosition < _route.Length)
            {
                _lastPosition++;
                if(_lastPosition != _route.Length)
                {
                    Rotate();
                }
                else
                {
                    _isMove = false;
                    _enemyPool.DeactivateObject();
                }
            }
            else
            {
                Move();
            }

        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _route[_lastPosition], _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 direction = _route[_lastPosition] - _route[_lastPosition - 1];
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
