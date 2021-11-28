using System;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth = 10;

    private int _health;

    public event UnityAction<int> DamageTaken;

    public event UnityAction<int> HealthChanged;

    public event UnityAction HealthDepleted;

    public int Health => _health;

    private enum ChangeMode
    {
        Increase,
        Decrease
    }

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        ChangeHealth(amount, ChangeMode.Decrease);
    }

    public void Heal(int amount)
    {
        ChangeHealth(amount);
    }

    public void Restore()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    private void ChangeHealth(int amount, ChangeMode mode = ChangeMode.Increase)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("amount");
        }

        if (mode == ChangeMode.Decrease)
        {
            DamageTaken?.Invoke(amount);
            amount = -amount;
        }

        _health = Mathf.Clamp(_health + amount, 0, _maxHealth);
        HealthChanged?.Invoke(_health);

        if (_health == 0)
        {
            HealthDepleted?.Invoke();
        }
    }
}