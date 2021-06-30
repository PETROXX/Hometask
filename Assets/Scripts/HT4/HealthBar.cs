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

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    public void ChangeHealthBar()
    {
        _hpText.text = $"{(int)_playerHealth.CurrentHealth}";
        StartCoroutine(ChangeSliderValue(_playerHealth.CurrentHealth));
    }

    public IEnumerator ChangeSliderValue(float aimValue)
    {
        do
        {
            _slider.value = Mathf.MoveTowards(_slider.value, aimValue, _changeSpeed);
            yield return null;
        } while (_slider.value != aimValue);
    }
}
