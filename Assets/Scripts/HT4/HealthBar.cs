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

    private Coroutine _changeSliderValue;

    private void Start()
    {
        _playerHealth.OnHealthChanged += OnButtonPressed;
    }

    public void OnButtonPressed()
    {
        ChangeHealthBar();
    }

    private void ChangeHealthBar()
    {
        _hpText.text = $"{(int)_playerHealth.CurrentHealth}";

        if (_changeSliderValue != null)
            StopCoroutine(_changeSliderValue);

        _changeSliderValue = StartCoroutine(ChangeSliderValue(_playerHealth.CurrentHealth));
    }

    private IEnumerator ChangeSliderValue(float value)
    {
        do
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _changeSpeed);
            yield return null;
        } while (_slider.value != value);
    }
}
