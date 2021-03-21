using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _playerSource;
    [SerializeField] private AudioClip _signalingSound;
    [SerializeField] private UnityEvent _alarmRaised;
    [SerializeField] private float _signalingPeriod;
    [SerializeField] private VolumeVariatns VolumeVariant;
    [SerializeField] private bool _isSignalPlaying;

    private float _timer;

    public event UnityAction AlarmRaised
    {
        add => _alarmRaised.AddListener(value);
        remove => _alarmRaised.RemoveListener(value);
    }

    enum VolumeVariatns
    {
        Increasing,
        Decreasing
    }

    private void Start()
    {
        _playerSource.clip = _signalingSound;
        _playerSource.volume = 0;
    }

    public void RaiseAlarm()
    {
        _playerSource.clip = _signalingSound;
        _alarmRaised.Invoke();
    }

    public void PlaySignal()
    {
        _isSignalPlaying = true;
        StartCoroutine(PlaySignalCoroutine());
    }

    public void StopSignal()
    {
        _isSignalPlaying = false;
        _playerSource.clip = null;
        _playerSource.volume = 0;
    }

    private IEnumerator PlaySignalCoroutine()
    {
        if (_isSignalPlaying)
        {
            if (VolumeVariant == VolumeVariatns.Increasing)
            {
                _playerSource.volume += 0.1f;
                if (_playerSource.volume >= 1) VolumeVariant = VolumeVariatns.Decreasing;
            }
            else
            {
                _playerSource.volume -= 0.1f;
                if (_playerSource.volume <= 0.1) VolumeVariant = VolumeVariatns.Increasing;
            }
            _playerSource.Play();
            yield return new WaitForSeconds(_signalingPeriod / 10);
            _timer += _signalingPeriod / 10;
            StartCoroutine(PlaySignalCoroutine());
        }
    }
}
