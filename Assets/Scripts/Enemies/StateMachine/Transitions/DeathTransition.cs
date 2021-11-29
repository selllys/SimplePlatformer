public class DeathTransition : Transition
{
    private void OnEnable()
    {
        Entity.Died += OnEntityDied;
    }

    private void OnDisable()
    {
        Entity.Died -= OnEntityDied;
    }

    private void OnEntityDied(Enemy entity)
    {
        NeedTransit = true;
    }
}