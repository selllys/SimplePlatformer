using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    public event UnityAction<Damagable> AttackConnected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Damagable>(out Damagable damagable))
        {
            AttackConnected?.Invoke(damagable);
        }
    }
}