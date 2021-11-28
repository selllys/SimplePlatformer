using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D), typeof(Damagable))]
public class Enemy : MonoBehaviour
{
    private static int _animatorHit = Animator.StringToHash("Hit");

    private Animator _animator;
    private Damagable _damagable;
    private Player _target;

    public event UnityAction<Enemy> Died;

    public bool IsFacingRight => transform.localScale.x > 0;

    public Vector2 MoveDirection => transform.right * (IsFacingRight ? 1 : -1);

    public Player Target => _target;

    public Vector3 TargetPosition => Target != null ? Target.transform.position : transform.position;

    public float DistanceToTarget => Vector2.Distance(transform.position, TargetPosition);

    private void Awake()
    {
        _damagable = GetComponent<Damagable>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _damagable.DamageTaken += OnDamageTaken;
        _damagable.HealthDepleted += OnHealthDepleted;
    }

    private void OnDisable()
    {
        _damagable.DamageTaken -= OnDamageTaken;
        _damagable.HealthDepleted -= OnHealthDepleted;
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    public void Turn()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, 1f, 1f);
    }

    public void MoveForward(float speed) => transform.Translate(MoveDirection * speed * Time.deltaTime);

    public void MoveTo(Vector2 position, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void OnDamageTaken(int amount)
    {
        _animator.SetTrigger(_animatorHit);
    }

    private void OnHealthDepleted()
    {
        Died?.Invoke(this);
    }
}