using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;

    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _slider.value = _health.HP;
        _hpText.text = $"{(int)_health.HP}";
    }

    private void Update()
    {
        _slider.value = _health.HP;
        _hpText.text = $"{(int)_health.HP}";
    }
}
