using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private int _patrolPointIndex = 0;
    private Player _player;

    [SerializeField] private float _speed;
    [SerializeField] private float _attackRange;
    [SerializeField] private List<PatrolPoint> _patrolPoints;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _patrolPoints = FindObjectsOfType<PatrolPoint>().ToList();
    }

    private void Update()
    {
        Move();
        DetectPlayer();
    }

    private void Move()
    {
        if (_patrolPointIndex >= _patrolPoints.Count)
            return;

        _rigidbody2D.AddForce((_patrolPoints[_patrolPointIndex].transform.position - transform.position) * Time.deltaTime * _speed);
        _spriteRenderer.flipX = _rigidbody2D.velocity.x > 0;

        if (_rigidbody2D.velocity.x != 0)
            _anim.SetInteger("AnimState", 2);
    }

    private void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _attackRange)
            _player.Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<PatrolPoint>(out PatrolPoint patrolPoint))
        {
            if (_patrolPointIndex < _patrolPoints.Count)
                _patrolPointIndex++;
            else
                _patrolPointIndex = 0;
        }
    }
}
