using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Collect(player);
            Destroy(gameObject);
        }
    }

    public abstract void Collect(Player player);
}