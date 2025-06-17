using System;
using UnityEngine;


[Serializable]
[CreateAssetMenu(menuName ="GameData/Waves/Wave Data")]
public class WaveData : ScriptableObject
{
    [SerializeField] private EnemyData[] _enemies;
    [SerializeField, Range(0.5f, 10)] private float _spawnInterval;

    public EnemyData[] Enemies { get =>  _enemies; }
    public float SpawnInterval { get => _spawnInterval; }
}