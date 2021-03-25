using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _playerRig;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded;

    public bool IsGrounded { get => _isGrounded; }
    public Vector2 Velocity { get => _playerRig.velocity; }

    private void Start()
    {
        _playerRig = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.15f, _groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
        if (Input.GetMouseButtonDown(0))
            _playerAnimation.AttackAnimation();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _playerRig.velocity = new Vector2(x * _speed, _playerRig.velocity.y);
    }

    private void Jump()
    {
        _playerRig.AddForce(new Vector2(0, _jumpForce));
    }

    public void MovePlayerToGround()
    {
        transform.position = new Vector2(transform.position.x, -2);
    }
}
