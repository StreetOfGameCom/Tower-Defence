using UnityEngine;

[CreateAssetMenu(menuName ="GameData/ObjectPool/ObjectPoolItem")]
public class ObjectPoolItem : ScriptableObject, PoolItem
{
    public GameObject Prefab => _prefab;

    public int Size => _size;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _size;
}
