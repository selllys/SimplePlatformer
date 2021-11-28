public class TargetDiedTransition : Transition
{
    private Player Target => Entity.Target;

    private void OnEnable()
    {
        Target.Died += OnTargetDied;
    }

    private void OnDisable()
    {
        Target.Died -= OnTargetDied;
    }

    private void OnTargetDied()
    {
        NeedTransit = true;
    }
}