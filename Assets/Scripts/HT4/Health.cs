using UnityEngine;

[RequireComponent(typeof(HealthBar))]

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _currentHP;
    [SerializeField] private float _changeSpeed;

    private HealthBar _healthBar;
    private bool _isHPChanging;
    private float _aimhp;

    public float HP { get => _currentHP; }

    private void Start()
    {
        _healthBar = GetComponent<HealthBar>();
        _currentHP = _maxHP;
        _aimhp = _currentHP;
        _healthBar.UpdateUI();
    }

    private void Update()
    {
        if (_isHPChanging)
        {
            _currentHP = Mathf.MoveTowards(_currentHP, _aimhp, _changeSpeed * Time.deltaTime);
            _healthBar.UpdateUI();
            if (_currentHP == _aimhp)
            {
                _isHPChanging = false;
            }
        }
    }

    public void PlusHP(float hp)
    {
        if (_currentHP + hp > _maxHP)
            return;

        _isHPChanging = true;
        _aimhp += hp;
    }

    public void MinusHP(float hp)
    {
        if (_currentHP - hp < 0)
            return;

        _isHPChanging = true;
        _aimhp -= hp;
    }
}
