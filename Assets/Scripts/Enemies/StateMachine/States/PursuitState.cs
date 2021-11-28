using UnityEngine;

public class PursuitState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Entity.MoveTo(Entity.TargetPosition, _speed);
    }
}