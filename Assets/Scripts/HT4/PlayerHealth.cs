using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    public event UnityAction HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float hp)
    {
        if (_currentHealth + hp > _maxHealth)
            return;

        _currentHealth += hp;

        HealthChanged.Invoke();
    }

    public void GeDamage(float hp)
    {
        if (_currentHealth - hp < 0)
            return;

        _currentHealth -= hp;
        HealthChanged.Invoke();
    }
}