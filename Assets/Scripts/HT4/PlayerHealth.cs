using UnityEngine;

[RequireComponent(typeof(HealthBar))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

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
    }

    public void MinusHP(float hp)
    {
        if (_currentHealth - hp < 0)
            return;

        _currentHealth -= hp;
    }
}