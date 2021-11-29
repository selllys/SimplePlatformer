using UnityEngine;

public class TargetFoundTransition : Transition
{
    [SerializeField] private Transform _targetDetector;
    [SerializeField] private float _detectionDistance;
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private LayerMask _platformLayers;

    private void Update()
    {
        DetectTarget();
    }

    private void DetectTarget()
    {
        if (IsTargetFound())
        {
            Entity.SetTarget(GetTarget());
            NeedTransit = true;
        }
    }

    private bool IsTargetFound()
    {
        RaycastHit2D targetHit = GetHit(_targetLayers);

        if (targetHit.collider == null)
        {
            return false;
        }

        RaycastHit2D wallHit = GetHit(_platformLayers);

        if (wallHit.collider == null)
        {
            return true;
        }

        float distanceToTarget = Vector2.Distance(transform.position, targetHit.point);
        float distanceToWall = Vector2.Distance(transform.position, wallHit.point);

        return distanceToTarget < distanceToWall;
    }

    private Player GetTarget()
    {
        RaycastHit2D targetHit = GetHit(_targetLayers);

        if (targetHit.collider != null && targetHit.collider.TryGetComponent<Player>(out Player target))
        {
            return target;
        }

        return null;
    }

    private RaycastHit2D GetHit(LayerMask layerMask)
    {
        return Physics2D.Raycast(_targetDetector.position, Entity.MoveDirection, _detectionDistance, layerMask);
    }
}