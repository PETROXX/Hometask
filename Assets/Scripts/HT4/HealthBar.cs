using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _health;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private TMP_Text _hpText;

    private bool _isHPChanging;
    private float _aimhp;

    private void Start()
    {
        _health = _maxHP;
        _slider.value = _health;
        _aimhp = _health;
    }

    private void Update()
    {
        if(_isHPChanging)
        {
            _health = Mathf.MoveTowards(_health, _aimhp, _changeSpeed * Time.deltaTime);
            if (_health == _aimhp)
                _isHPChanging = false;
        }
        _slider.value = _health;
        _hpText.text = $"{(int)_health}";
    }

    public void PlusHP(float hp)
    {
        if (_health + hp > _maxHP) return;
        _isHPChanging = true;
        _aimhp += hp;
    }

    public void MinusHP(float hp)
    {
        if (_health - hp < 0) return;
        _isHPChanging = true;
        _aimhp -= hp;
    }
}
