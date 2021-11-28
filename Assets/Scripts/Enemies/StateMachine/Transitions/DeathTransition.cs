public class DeathTransition : Transition
{
    private void OnEnable()
    {
        Entity.Died += OnDeath;
    }

    private void OnDisable()
    {
        Entity.Died -= OnDeath;
    }

    private void OnDeath(Enemy entity)
    {
        NeedTransit = true;
    }
}