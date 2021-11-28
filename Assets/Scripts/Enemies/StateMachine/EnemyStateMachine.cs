using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private List<State> _states;

    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        Enemy entity = GetComponent<Enemy>();

        _states.ForEach(state => state.Init(entity));
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        _currentState?.Exit();
        _currentState = nextState;
        _currentState?.Enter();
    }

    [ContextMenu("Setup States")]
    private void SetupStates()
    {
        _states = GetComponentsInChildren<State>(true).ToList();
        _firstState = _states.FirstOrDefault();
    }
}