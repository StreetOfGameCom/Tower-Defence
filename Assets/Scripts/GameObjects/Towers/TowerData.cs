using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Towers/TowerData")]
public class TowerData : ScriptableObject, IItemData
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _price;
    [SerializeField] private int _priceCreate;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _systemName;
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private TowerUpgrateData[] _towerUpgrateDatas;

    public string Name => _name;
    public string Description => _description;
    public int Price => _price;
    public int PriceCreate => _priceCreate;
    public Sprite Icon => _icon;
    public string SystemName => _systemName;
    public GameObject TowerPrefab{ get => _towerPrefab; }
    public TowerUpgrateData[] TowerUpgrateDatas { get => _towerUpgrateDatas; }
}

