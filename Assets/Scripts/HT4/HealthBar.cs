using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerHealth))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private float _changeSpeed;

    private bool _isHpChanging;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (_isHpChanging)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _playerHealth.CurrentHealth, _changeSpeed);
            if (_slider.value == _playerHealth.CurrentHealth)
                _isHpChanging = false;
        }
    }

    public void ChangeHealthBar()
    {
        _isHpChanging = true;
        _hpText.text = $"{(int)_playerHealth.CurrentHealth}";
    }
}
