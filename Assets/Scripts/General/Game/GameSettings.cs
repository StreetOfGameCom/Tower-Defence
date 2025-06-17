using UnityEngine;

[System.Serializable]
public class GameSettings
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private ChapterData _chapterData;
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private LevelUIController _controller;
    [SerializeField] private TowerShopManager _shopManager;
    [SerializeField] private EnemyObjectSpawner _enemyObjectSpawner;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LevelCompliter _levelCompliter;
    [SerializeField] private Vector3[] _road;
    [SerializeField] private TowerData[] _itemsData;

    public LevelData LevelData { get => _levelData; }
    public ChapterData ChapterData { get => _chapterData; }
    public Vector3[] Road { get => _road; }
    public LevelUIController UIController { get => _controller; }
    public WaveManager WaveManager { get => _waveManager; }
    public TowerShopManager ShopManager { get => _shopManager; }
    public EnemyObjectSpawner EnemyObjectSpawner { get => _enemyObjectSpawner; }
    public PlayerController PlayerController { get => _playerController; }  
    public LevelCompliter LevelCompliter { get => _levelCompliter; }
    public TowerData[] ItemsData { get => _itemsData; }
}
