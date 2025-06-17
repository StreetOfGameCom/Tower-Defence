using UnityEngine;

public class Enemy : MonoBehaviour, IHealthController
{
    [SerializeField] private ObjectViewManager _viewManager;
    [SerializeField] private EnemyPoolObject _pool;
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private ProgressBarVizualizer _healthBar;
    private float _maxHealth;
    private float _health;
    private EnemyData _data;

    public void Init(EnemyData data)
    {
        _viewManager.SetView(data);
        _enemyMove.SetSpeed(data.Speed);
        _maxHealth = data.Health;
        _data = data;
        ResetEnemy();
    }

    public void ResetEnemy()
    {
        _health = _maxHealth;
        _healthBar.Vizualize(_health);
    }

    public void TakeDamage(float damage)
    {
        if(damage < 0) damage = 0;
        _health -= damage;
        _healthBar.Vizualize(_health);
        _health = Mathf.Clamp(_health, 0f, _maxHealth);
        if (_health == 0f)
            Died();
    }

    public void TakeHealth(float treatment)
    {
        if (treatment < 0) treatment = 0;
        _health += treatment;
        _healthBar.Vizualize(_health);
        _health = Mathf.Clamp(_health, 0f, _maxHealth);
    }

    private void Died()
    {
        _health = _maxHealth;
        _healthBar.Vizualize(_health);
        MoneyService.IncreaseBalance(_data.Award, KeyManager.GetLevelMoneyKey());
        _pool.DeactivateObject();
    }
}

