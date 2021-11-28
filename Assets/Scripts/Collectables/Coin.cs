public class Coin : Collectable
{
    public override void Collect(Player player)
    {
        player.AddCoin();
    }
}