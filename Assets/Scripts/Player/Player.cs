using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Damagable))]
public class Player : MonoBehaviour
{
    private int _coins = 0;
    private Damagable _playerHealth;

    public event UnityAction CoinCollected;

    public event UnityAction Died;

    public int Coins => _coins;

    private void Awake()
    {
        _playerHealth = GetComponent<Damagable>();
    }

    private void OnEnable()
    {
        _playerHealth.HealthDepleted += OnHealthDepleted;
    }

    private void OnDisable()
    {
        _playerHealth.HealthDepleted -= OnHealthDepleted;
    }

    public void AddCoin()
    {
        _coins++;
        CoinCollected?.Invoke();
    }

    public void Heal(int amount)
    {
        _playerHealth.Heal(amount);
    }

    public void TakeDamage(int amount)
    {
        _playerHealth.TakeDamage(amount);
    }

    public void Kill()
    {
        _playerHealth.TakeDamage(_playerHealth.Health);
    }

    public void RestoreHealth()
    {
        _playerHealth.Restore();
    }

    private void OnHealthDepleted()
    {
        Died?.Invoke();
    }
}