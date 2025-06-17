using System;
using UnityEngine;
using ObjectPool;

public class EnemyPoolObject : PoolObject
{
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private Enemy _enemy;
    public static event Action Deactivated;

    public override void ActivateObject()
    {
        base.ActivateObject();
        _enemyMove.StartMove();
    }

    public override void DeactivateObject()
    {
        base.DeactivateObject();
        _enemy.ResetEnemy();
        Deactivated?.Invoke();
    }
}
