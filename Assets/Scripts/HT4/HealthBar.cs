using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerHealth))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (_playerHealth.IsHealthChanging)
            UpdateUI();
    }

    public void UpdateUI()
    {
        _slider.value = _playerHealth.Health;
        _hpText.text = $"{(int)_playerHealth.Health}";
    }
}
