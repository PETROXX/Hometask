using UnityEngine;

[RequireComponent(typeof(HealthBar))]

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _changeSpeed;

    private bool _isHPChanging;
    private float _aimhp;

    public float Health { get => _currentHealth; }
    public bool IsHealthChanging => _isHPChanging;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _aimhp = _currentHealth;
    }

    private void Update()
    {
        if (_isHPChanging)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _aimhp, _changeSpeed * Time.deltaTime);
            if (_currentHealth == _aimhp)
            {
                _isHPChanging = false;
            }
        }
    }

    public void PlusHP(float hp)
    {
        if (_currentHealth + hp > _maxHealth)
            return;

        _isHPChanging = true;
        _aimhp += hp;
    }

    public void MinusHP(float hp)
    {
        if (_currentHealth - hp < 0)
            return;

        _isHPChanging = true;
        _aimhp -= hp;
    }
}