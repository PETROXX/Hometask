using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _animator.SetBool("IsJumping", !_playerMovement.IsGrounded);
        _animator.SetBool("IsRunning", Mathf.Abs(_playerMovement.Velocity.x) >= 0.5);
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("IsAttacking");
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("IsDead");
    }
}
