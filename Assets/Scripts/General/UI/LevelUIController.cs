using UnityEngine;
using UnityEngine.SceneManagement;

public interface IUIController
{
    void RestartButton();
    void UpgrateHealth(float health);
    void UgrateWaves(int wave);
    void GameOver();
    void GameWin();
}

public class LevelUIController : MonoBehaviour, IUIController
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextVizualizer _healthText;
    [SerializeField] private TextVizualizer _wavesText;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _lossPanel;
    [SerializeField] private Animator _waveAnimator;
    [SerializeField] private string _newWaveTag;
    private float _lastTimeScale = 1f;

    private void Start()
    {
        _winPanel.SetActive(false);
        _lossPanel.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerController.PlayerChangedHealth += UpgrateHealth;
    }
    public void RestartButton() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void UpgrateHealth(float health) => _healthText.Vizualize(health);
    public void UgrateWaves(int wave)
    {
        _wavesText.Vizualize(wave);
        _waveAnimator.SetTrigger(_newWaveTag);
    }
    public void GameWin()
    {
        _winPanel.SetActive(true);
    }
    public void GameOver()
    {
        _lossPanel.SetActive(true);
    }
    public void PauseGame()
    {
        _lastTimeScale = Time.timeScale;
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayGame()
    {
        Time.timeScale = _lastTimeScale;
        _pausePanel.SetActive(false);
    }
}

