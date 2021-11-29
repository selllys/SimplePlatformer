using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private PlatformTurnChecker _platformTurnChecker;

    [System.Serializable]
    private struct PlatformTurnChecker
    {
        public Transform Transform;
        public float CheckDistance;
        public LayerMask PlatformLayers;

        public Vector3 Position => Transform.position;
    }

    private void Update()
    {
        if (IsTurnNeeded())
        {
            Entity.Turn();
        }

        Entity.MoveForward(_speed);
    }

    private bool IsTurnNeeded()
    {
        bool isGroundHit = CheckPlatformHit(Vector2.down);
        bool isWallHit = CheckPlatformHit(Entity.MoveDirection);

        return isWallHit || isGroundHit == false;
    }

    private bool CheckPlatformHit(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(_platformTurnChecker.Position, direction, _platformTurnChecker.CheckDistance, _platformTurnChecker.PlatformLayers);
        return hit.collider != null;
    }
}