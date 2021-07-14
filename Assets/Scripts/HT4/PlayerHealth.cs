using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    private UnityEvent _healthChanged;

    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthChanged = new UnityEvent();
        _healthChanged.AddListener(FindObjectOfType<HealthBar>().OnButtonPressed);
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