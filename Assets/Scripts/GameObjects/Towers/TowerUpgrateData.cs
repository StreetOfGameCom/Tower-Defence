using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Towers/TowerUpgrateData")]
public class TowerUpgrateData : ScriptableObject, IObjectViewData
{
    [SerializeField] private Sprite _view;
    [SerializeField] private float _size;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    [SerializeField] private int _levelIndex;
    [SerializeField, Range(0, 1000)] private float _damage;
    [SerializeField, Range(0.1f, 10)] private float _shootDelay;
    [SerializeField, Range(0, 5000)] private int _price;

    public Sprite View { get => _view; }
    public float Size { get => _size; }
    public RuntimeAnimatorController AnimatorController { get => _animatorController; }

    public int LevelIndex { get => _levelIndex; }
    public float Damage { get => _damage; }
    public float ShootDelay { get => _shootDelay; }
    public int Price { get => _price; }
}
