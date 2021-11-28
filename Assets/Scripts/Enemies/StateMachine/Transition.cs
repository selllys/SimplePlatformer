using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    protected Enemy Entity { get; private set; }

    public void Init(Enemy entity)
    {
        Entity = entity;
    }

    public void ResetTransition()
    {
        NeedTransit = false;
    }
}