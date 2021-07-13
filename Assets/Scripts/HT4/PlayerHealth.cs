using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    [SerializeField] private UnityEvent _healthChanged;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void PlusHP(float hp)
    {
        if (_currentHealth + hp > _maxHealth)
            return;

        _currentHealth += hp;

        _healthChanged.Invoke();
    }

    public void MinusHP(float hp)
    {
        if (_currentHealth - hp < 0)
            return;

        _currentHealth -= hp;
        _healthChanged.Invoke();
    }
}