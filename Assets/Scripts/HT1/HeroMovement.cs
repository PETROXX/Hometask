using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement: MonoBehaviour
{
    [SerializeField] private AnimationClip _attackAnimation;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _playerRig;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed = 100;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _jumpForce;

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.15f, _groundLayer);
        _animator.SetBool("IsJumping", !_isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("IsAttacking", true);
            StartCoroutine(Wait(_attackAnimation.length));
        }
    }

    IEnumerator Wait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _animator.SetBool("IsAttacking", false);
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;
        _playerRig.velocity = new Vector2(x * _speed, _playerRig.velocity.y);
        _animator.SetBool("IsRunning", _playerRig.velocity.x != 0.0);
    }

    private void Jump()
    {
        _playerRig.AddForce(new Vector2(1, _jumpForce));
    }
}
