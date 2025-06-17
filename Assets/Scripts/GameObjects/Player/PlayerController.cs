using UnityEngine;

public interface IPlayerController
{
    static event PlayerController.OnPlayerChangedHealth PlayerChangedHealth;
    event PlayerController.OnPlayerDied PlayerDied;
    float Health { get; }
    void Init(PlayerData playerData);
}

public class PlayerController : MonoBehaviour, IHealthController, IPlayerController
{
    [SerializeField] private string _enemyTag;
    [SerializeField] private ObjectViewManager _viewManager;
    public delegate void OnPlayerChangedHealth(float value);
    public static event OnPlayerChangedHealth PlayerChangedHealth;
    public delegate void OnPlayerDied();
    public event OnPlayerDied PlayerDied;
    public float Health { get => _health; }

    private PlayerData _playerData;
    private float _health;

    public void Init(PlayerData playerData)
    {
        _playerData = playerData;
        _viewManager.SetView(playerData);
        _health = playerData.Health;
        PlayerChangedHealth?.Invoke(_health);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        _health = Mathf.Clamp(_health -= Mathf.Round(damage),0, _playerData.Health);
        PlayerChangedHealth?.Invoke(_health);
        if(_health == 0) PlayerDied?.Invoke();
    }

    public void TakeHealth(float treatment)
    {
        if (treatment < 0) return;
        _health = Mathf.Clamp(_health += Mathf.Round(treatment), 0, _playerData.Health);
        PlayerChangedHealth?.Invoke(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _enemyTag)
        {
            TakeDamage(_playerData.Damage);
        }
    }
}
