using ObjectPool;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] protected ObjectPoolItem _PoolItem;
    [SerializeField] protected Transform _PoolObjectsParent;
    [SerializeField] protected Vector3 _SpawnPosition;
    protected List<PoolObject> _Pool;
    public List<PoolObject> PoolObjects
    {
        get
        {
            if (PoolObjects == null)
            {
                _Pool = new List<PoolObject>();
                return _Pool;
            }
            return _Pool;
        }
    }


    protected virtual void FillPool()
    {
        _Pool = new List<PoolObject>();
        for (int i = 0; i < _PoolItem.Size; i++)
        {
            CreatPoolObject(_PoolItem.Prefab);
        }
    }

    protected virtual PoolObject SpawnFromPool()
    {
        foreach (PoolObject pool in _Pool)
        {
            if (!pool.CheckActive())
            {
                pool.ActivateObject();
                return pool;
            }
        }
        var poolObject = CreatPoolObject(_PoolItem.Prefab);
        poolObject.ActivateObject();
        return poolObject;
    }

    protected virtual PoolObject CreatPoolObject(GameObject objectPrefab)
    {
        var poolObject = Instantiate(objectPrefab, _PoolObjectsParent).GetComponent<PoolObject>();
        poolObject.InitPool(_SpawnPosition);
        _Pool.Add(poolObject);
        return poolObject;
    }

    public virtual bool CheckActiveAll()
    {
        bool allActived = false;
        foreach (PoolObject pool in _Pool)
        {
            if (pool.CheckActive())
            {
                allActived = true;
                return true;
            }
        }
        return allActived;
    }

}

