using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(PlayerHealth))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private float _changeSpeed;

    private PlayerHealth _playerHealth;
    private bool _isCoroutineRunning;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    public void OnButtonPressed()
    {
        ChangeHealthBar();
    }

    private void ChangeHealthBar()
    {
        _hpText.text = $"{(int)_playerHealth.CurrentHealth}";

        if(!_isCoroutineRunning)
            StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        _isCoroutineRunning = true;

        do
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _playerHealth.CurrentHealth, _changeSpeed);
            yield return null;
        } while (_slider.value != _playerHealth.CurrentHealth);

        _isCoroutineRunning = false;
    }
}
