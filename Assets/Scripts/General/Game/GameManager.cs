using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private GameSettings _gameSettings;
    private IUIController _UIController;
    private IWaveController _wavesController;
    private IShopManager _towerShopManager;
    private IPlayerController _playerController;
    private ILevelCompliter _levelCompiler;

    public GameManager(GameSettings settings)
    {
        _gameSettings = settings;
        _playerController = settings.PlayerController;
        _UIController = settings.UIController;
        _wavesController = settings.WaveManager;
        _towerShopManager = settings.ShopManager;
        _towerShopManager = settings.ShopManager;
        _levelCompiler = settings.LevelCompliter;

        _towerShopManager.FillingSlots(_gameSettings.ItemsData);
        settings.EnemyObjectSpawner.InitPool(InitRoad());
        MoneyService.DecreaseBalance(MoneyService.GetBalance(KeyManager.GetLevelMoneyKey()), KeyManager.GetLevelMoneyKey());
        MoneyService.IncreaseBalance(settings.LevelData.LevelStartBalance, KeyManager.GetLevelMoneyKey());
        _playerController.Init(settings.LevelData.Base);
        _wavesController.WaveEnded += WaveEnded;
        _playerController.PlayerDied += PlayerDie;
        _wavesController.SartWaves(InitWaves(), _UIController);
    }

    private List<IItemData> InitTowerItems()
    {
        List<IItemData> items = new List<IItemData>();
        var purchases = SavePurchasesService.GetAllPurchases();
        if (purchases == null) return items;
        foreach(var purchasesItem in purchases)
        {
            foreach(var item in _gameSettings.ItemsData)
            {
                if (purchasesItem._key_name == item.SystemName)
                {
                    items.Add(item);
                }
            }
        }
        return items;
    }

    private Vector3[] InitRoad()
    {
        Vector3[] road = _gameSettings.Road;
        if (road.Length == 0)
        {
            throw new Exception("Error! Road length = 0!");
        }
        return road;
    }

    private WaveData[] InitWaves()
    {
        WaveData[] waves = _gameSettings.LevelData.Waves;
        if (waves.Length == 0)
        {
            throw new Exception("Error! Spots length = 0!");
        }
        return waves;
    }

    private void PlayerDie()
    {
        _UIController.GameOver();
    }

    private void WaveEnded()
    {
        _UIController.GameWin();
        _levelCompiler.LevelComplite();
    }
}
