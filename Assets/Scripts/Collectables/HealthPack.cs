using UnityEngine;

public class HealthPack : Collectable
{
    [SerializeField, Min(1)] private int _amount = 3;

    public override void Collect(Player player)
    {
        player.Heal(_amount);
    }
}