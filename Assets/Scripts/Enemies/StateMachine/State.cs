using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Enemy Entity { get; private set; }

    public void Init(Enemy entity)
    {
        Entity = entity;
        gameObject.SetActive(false);

        _transitions.ForEach(transition => transition.Init(entity));
    }

    public void Enter()
    {
        if (gameObject.activeSelf == false)
        {
            _transitions.ForEach(transition => transition.ResetTransition());
            gameObject.SetActive(true);
        }
    }

    public void Exit()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }

    [ContextMenu("Update Transitions")]
    private void UpdateTransitions()
    {
        _transitions = GetComponents<Transition>().ToList();
    }
}