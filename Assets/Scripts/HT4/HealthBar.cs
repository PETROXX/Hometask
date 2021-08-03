using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private PlayerHealth _playerHealth;

    private IEnumerator _changeSliderValue;

    private void Start()
    {
        _playerHealth.HealthChanged += OnButtonPressed;
    }

    public void OnButtonPressed()
    {
        ChangeHealthBar();
    }

    private void ChangeHealthBar()
    {
        _hpText.text = $"{(int)_playerHealth.CurrentHealth}";

        if (_changeSliderValue == null)
        {
            _changeSliderValue = ChangeSliderValue(_playerHealth.CurrentHealth);
            StartCoroutine(_changeSliderValue);
        }
        else
        {
            _changeSliderValue = ChangeSliderValue(_playerHealth.CurrentHealth);
            StartCoroutine(_changeSliderValue);
        }
    }

    private IEnumerator ChangeSliderValue(float value)
    {
        print(value);

        do
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _changeSpeed);
            yield return null;
        } while (_slider.value != value);

        _changeSliderValue = null;
    }
}
