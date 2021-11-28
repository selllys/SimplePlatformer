using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator), typeof(PlayerMovement))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Hitbox _hitbox;
    [SerializeField] private int _attackDamage = 1;

    private static int _animatorAttackTrigger = Animator.StringToHash("Attack");
    private PlayerInput _input;
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Awake()
    {
        _input = new PlayerInput();
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _input.Player.Attack.performed += OnAttack;
        _input.Enable();

        _hitbox.AttackConnected += OnAttackConnected;
    }

    private void OnDisable()
    {
        _input.Player.Attack.performed -= OnAttack;
        _input.Disable();

        _hitbox.AttackConnected -= OnAttackConnected;
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        if (_playerMovement.IsGrounded)
        {
            _animator.SetTrigger(_animatorAttackTrigger);
        }
    }

    private void OnAttackConnected(Damagable damagable)
    {
        damagable.TakeDamage(_attackDamage);
    }

    [ContextMenu("Find HitBox")]
    public void SetHitBox()
    {
        _hitbox = GetComponentInChildren<Hitbox>();
    }
}