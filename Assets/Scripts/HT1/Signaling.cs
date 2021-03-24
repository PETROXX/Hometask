using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{

    [SerializeField] private AudioClip _signalingSound;
    [SerializeField] private float _volumeIncreaseStep;
    [SerializeField] private UnityEvent _alarmRaised;

    private AudioSource _audioSource;
    private VolumeVariatns _volumeVariant;
    private bool _isSignalPlaying;
    private float _volume;

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
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _signalingSound;
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if(_isSignalPlaying)
        {
            if (_volumeVariant == VolumeVariatns.Increasing)
            {
                _volume = Mathf.MoveTowards(_volume, 1, _volumeIncreaseStep * Time.deltaTime);
                if (_volume >= 1)
                    _volumeVariant = VolumeVariatns.Decreasing;
            }
            else
            {
                _volume = Mathf.MoveTowards(_volume, 0, _volumeIncreaseStep * Time.deltaTime);
                if (_volume <= 0.1)
                    _volumeVariant = VolumeVariatns.Increasing;
            }
            _audioSource.volume = _volume;
            _audioSource.Play();
        }
    }

    public void RaiseAlarm()
    {
        _audioSource.clip = _signalingSound;
        _alarmRaised.Invoke();
    }

    public void PlaySignal()
    {
        _isSignalPlaying = true;
    }

    public void StopSignal()
    {
        _isSignalPlaying = false;
        _audioSource.clip = null;
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            RaiseAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            StopSignal();
    }
}
