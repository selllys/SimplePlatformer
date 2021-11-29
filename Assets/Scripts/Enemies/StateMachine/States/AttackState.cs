using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _cooldown = 2f;

    private static int _animatorAttack = Animator.StringToHash("Attack");
    private Animator _animator;
    private Coroutine _attackRoutine;

    private void Awake()
    {
        _animator = Entity.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _attackRoutine = StartCoroutine(AttackRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_attackRoutine);
    }

    private IEnumerator AttackRoutine()
    {
        var attackDelay = new WaitForSeconds(_cooldown);

        while (true)
        {
            Attack(Entity.Target);
            yield return attackDelay;
        }
    }

    private void Attack(Player target)
    {
        _animator.SetTrigger(_animatorAttack);
        target.TakeDamage(_damage);
    }
}