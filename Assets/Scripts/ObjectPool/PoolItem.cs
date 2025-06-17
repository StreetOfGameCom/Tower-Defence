using UnityEngine;

public interface PoolItem
{
    GameObject Prefab { get; }
    int Size { get; }
}
