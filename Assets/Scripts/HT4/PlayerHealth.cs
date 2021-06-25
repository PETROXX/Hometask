using UnityEngine;

[RequireComponent(typeof(HealthBar))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    private HealthBar _healthBar;

    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponent<HealthBar>();
    }


    public void PlusHP(float hp)
    {
        if (_currentHealth + hp > _maxHealth)
            return;

        _currentHealth += hp;

        _healthBar.ChangeHealthBar();
    }

    public void MinusHP(float hp)
    {
        if (_currentHealth - hp < 0)
            return;

        _currentHealth -= hp;

        _healthBar.ChangeHealthBar();
    }
}