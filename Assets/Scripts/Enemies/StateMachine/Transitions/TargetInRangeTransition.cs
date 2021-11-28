using UnityEngine;

public class TargetInRangeTransition : Transition
{
    [SerializeField] private float _transitionDistance;

    private void Update()
    {
        NeedTransit = Entity.DistanceToTarget < _transitionDistance;
    }
}