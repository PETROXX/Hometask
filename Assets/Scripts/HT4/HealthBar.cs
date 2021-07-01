using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerHealth))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private float _changeSpeed;

    private UnityEvent _buttonPressed;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();

        if (_buttonPressed == null)
            _buttonPressed = new UnityEvent();

        _buttonPressed.AddListener(ChangeHealthBar);
    }

    public void ButtonPressed()
    {
        _buttonPressed.Invoke();
    }

    private void ChangeHealthBar()
    {
        _hpText.text = $"{(int)_playerHealth.CurrentHealth}";
        StartCoroutine(ChangeSliderValue(_playerHealth.CurrentHealth));
    }

    private IEnumerator ChangeSliderValue(float aimValue)
    {
        do
        {
            _slider.value = Mathf.MoveTowards(_slider.value, aimValue, _changeSpeed);
            yield return null;
        } while (_slider.value != aimValue);
    }
}
