using UnityEngine;

[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;

    private bool _isDead;
    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        if (!_isDead)
        {
            _isDead = true;
            _playerAnimation.DeathAnimation();
        }
        GetComponent<PlayerMovement>().enabled = false;
        if (!GetComponent<PlayerMovement>().IsGrounded)
            GetComponent<PlayerMovement>().MovePlayerToGround();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
