using UnityEngine;

public class TargetOutOfRangeTransition : Transition
{
    [SerializeField] private float _transitionDistance;

    private void Update()
    {
        NeedTransit = Entity.DistanceToTarget > _transitionDistance;
    }
}