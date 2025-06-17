using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Openspot : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private Transform _spawn;
    [SerializeField] private TowerShopManager _shopManager;
    [SerializeField] private TowerRedactPanel _redactPanel;
    [SerializeField] private AudioClip _clip;

    private TowerData _tower;
    private TowerController _towerController;
    private bool _isOccupied = false;
    private bool _canRedact;
    private int _levelIndex;

    private void OnMouseDown()
    {
        if (!_isOccupied)
            _shopManager.EnablingShop(this);
        else
            _redactPanel.OpenToolsPanel(this, _levelIndex < _tower.TowerUpgrateDatas.Length - 1 || _canRedact);
    }

    public void CreateTower(TowerData tower)
    {
        _levelIndex = 0;
        _canRedact = true;
        _tower = tower;
        _towerController = Instantiate(tower.TowerPrefab, _spawn).GetComponent<TowerController>();
        _isOccupied = true;
        ChangeTower(_tower.TowerUpgrateDatas[_levelIndex]);
        _source.PlayOneShot(_clip);
    }

    public void UpgrateTower()
    {
        if(_levelIndex == _tower.TowerUpgrateDatas.Length - 1 || !MoneyService.CheckValueInBalance(_tower.TowerUpgrateDatas[_levelIndex + 1].Price, KeyManager.GetLevelMoneyKey()))return;
        _levelIndex++;
        MoneyService.DecreaseBalance(_tower.TowerUpgrateDatas[_levelIndex].Price, KeyManager.GetLevelMoneyKey());
        ChangeTower(_tower.TowerUpgrateDatas[_levelIndex]);
        if(_levelIndex == _tower.TowerUpgrateDatas.Length - 1)
            _canRedact = false;
        _source.PlayOneShot(_clip);
    }    
    public void DestroyTower()
    {
        if (!_isOccupied) return;
        Destroy(_towerController.gameObject);
        _tower = null;
        _towerController = null;
        _isOccupied = false;
        _source.PlayOneShot(_clip);
    }

    private void ChangeTower(TowerUpgrateData upgrate)
    {
        _towerController.Init(upgrate);
    }



}
