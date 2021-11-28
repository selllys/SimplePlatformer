using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private GroundChecker _groundChecker;

    private static int _animatorSpeed = Animator.StringToHash("Speed");
    private static int _animatorIsGrounded = Animator.StringToHash("IsGrounded");
    private static int _animatorIsFalling = Animator.StringToHash("IsFalling");
    private PlayerInput _input;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private float _xDirection = 0;
    private bool _isGrounded;
    private bool _isFalling;

    [System.Serializable]
    private struct GroundChecker
    {
        public Transform Transform;
        public float Width;
        public float Height;
        public LayerMask GroundLayers;

        public Vector3 Position => Transform.position;

        public Vector2 Size => new Vector2(Width, Height);
    }

    public bool IsGrounded => _isGrounded;

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(_groundChecker.Position, _groundChecker.Size);
    }

    private void Awake()
    {
        _input = new PlayerInput();
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.Player.Move.performed += OnMove;
        _input.Player.Jump.performed += OnJump;

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Player.Move.performed -= OnMove;
        _input.Player.Jump.performed -= OnJump;

        _input.Disable();
    }

    private void Update()
    {
        Move();
        UpdateTurn();
        UpdateIsGrounded();
        UpdateIsFalling();
        UpdateAnimations();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        _xDirection = ctx.ReadValue<float>();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (_isGrounded)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
        }
    }

    private void Move()
    {
        Vector2 moveDirection = new Vector2(_xDirection, 0);
        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    private void UpdateTurn()
    {
        if (_xDirection > 0)
        {
            TurnRight();
        }
        else if (_xDirection < 0)
        {
            TurnLeft();
        }
    }

    private void TurnLeft()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void TurnRight()
    {
        transform.localScale = Vector3.one;
    }

    private void UpdateIsGrounded()
    {
        _isGrounded = Physics2D.OverlapBox(_groundChecker.Position, _groundChecker.Size, 0, _groundChecker.GroundLayers);
    }

    private void UpdateIsFalling()
    {
        _isFalling = _rigidBody.velocity.y < 0;
    }

    private void UpdateAnimations()
    {
        _animator.SetFloat(_animatorSpeed, Mathf.Abs(_xDirection));
        _animator.SetBool(_animatorIsGrounded, _isGrounded);
        _animator.SetBool(_animatorIsFalling, _isFalling);
    }
}