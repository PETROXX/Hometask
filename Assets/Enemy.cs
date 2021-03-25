using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private int _patrolPointIndex = 0;
    private Player _player;
    private bool _isAttacking;

    [SerializeField] private float _speed;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _patrolPointsHandler;
    [SerializeField] private List<Transform> _patrolPoints;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _patrolPoints = _patrolPointsHandler.GetComponentsInChildren<Transform>().ToList();
        _patrolPoints.Remove(_patrolPointsHandler);
    }

    private void Update()
    {
        Move();
        DetectPlayer();
    }

    private void Move()
    {
        if (_patrolPointIndex >= _patrolPoints.Count) return;
        _rb.AddForce((_patrolPoints[_patrolPointIndex].position - transform.position) * Time.deltaTime * _speed); // get move direction 
        _spriteRenderer.flipX = _rb.velocity.x > 0;
        if (_rb.velocity.x != 0) _anim.SetInteger("AnimState", 2); // run animation
    }

    private void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _attackRange)
        {
            _player.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PatrolPoint")
        {
            if (_patrolPointIndex < _patrolPoints.Count) _patrolPointIndex++;
            else _patrolPointIndex = 0;
        }
    }
}
