using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Vector3> _route;

    [SerializeField] private int _maxCountEnemy;
}
