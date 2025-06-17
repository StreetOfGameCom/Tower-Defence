using UnityEngine;

namespace ObjectPool 
{
    public abstract class PoolObject : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private bool _isActive;

        public virtual void InitPool(Vector3 startPosition)
        {
            _isActive = false;
            gameObject.SetActive(false);
            _startPosition = startPosition;
            transform.position = startPosition;
        }

        public virtual void ActivateObject()
        {
            if (_isActive) return;
            _isActive = true;
            gameObject.SetActive(true);
            transform.position = _startPosition;
        }

        public virtual void DeactivateObject()
        {
            if (!_isActive) return;
            _isActive = false;
            gameObject.SetActive(false);
        }

        public virtual bool CheckActive()
        {
            return _isActive;
        }
    }
}

