using System.Collections;
using ObjectPool;
using UnityEngine;

public class EnemyObjectSpawner : ObjectPoolManager
{
    private Vector3[] _route;
    public void InitPool(Vector3[] route)
    {
        _route = route;
        FillPool();
    }

    protected override PoolObject CreatPoolObject(GameObject objectPrefab)
    {
        var poolObject = Instantiate(objectPrefab).GetComponent<PoolObject>();
        poolObject.InitPool(_SpawnPosition);
        poolObject.gameObject.GetComponent<EnemyMove>().Init(_route);
        _Pool.Add(poolObject);
        return poolObject;
    }

    private IEnumerator SpawnObjectFromPool(EnemyData[] enemies, float delay)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = SpawnFromPool();
            enemy.gameObject.GetComponent<Enemy>().Init(enemies[i]);
            yield return new WaitForSeconds(delay);
        }
    }

    public void SpawnEnemys(EnemyData[] enemies, float delay)
    {
        if (!CheckActiveAll())
        {
            StartCoroutine(SpawnObjectFromPool(enemies, delay));
        }
    }

}

