using UnityEngine;

public interface IWaveController 
{
    int CurrentWaveIndex {  get; }
    void SartWaves(WaveData[] waveDatas, IUIController UIController);
    event WaveManager.OnWaveEnded WaveEnded;
}


public class WaveManager : MonoBehaviour, IWaveController
{
    public delegate void OnWaveEnded();
    public event OnWaveEnded WaveEnded;

    [SerializeField] private EnemyObjectSpawner _enemySpawner;

    private IUIController _UIController;
    private WaveData[] _waveDatas;
    private int _waveIndex;
    public int CurrentWaveIndex { get => _waveIndex; }

    public void SartWaves(WaveData[] waveDatas, IUIController UIController)
    {
        _waveIndex = 0;
        _UIController = UIController;
        _waveDatas = waveDatas;
        SartNewWave();
    }

    private void OnEnable()
    {
        EnemyPoolObject.Deactivated += CheckWave;
    }

    private void OnDisable()
    {
        EnemyPoolObject.Deactivated -= CheckWave;
    }

    private void SartNewWave()
    {
        if (_waveIndex >= _waveDatas.Length)
        {
            WaveEnded?.Invoke();
            return;
        }
        _UIController.UgrateWaves(_waveIndex + 1);
        _enemySpawner.SpawnEnemys(_waveDatas[_waveIndex].Enemies, _waveDatas[_waveIndex].SpawnInterval);
        _waveIndex++;
    }

    private void CheckWave()
    {
        if (!_enemySpawner.CheckActiveAll()) SartNewWave();
    }

}
