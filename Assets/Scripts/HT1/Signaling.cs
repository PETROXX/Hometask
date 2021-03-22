using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _playerSource;
    [SerializeField] private AudioClip _signalingSound;
    [SerializeField] private float _volumeIncreaseStep;
    [SerializeField] private UnityEvent _alarmRaised;

    private VolumeVariatns VolumeVariant;
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
        _playerSource.clip = _signalingSound;
        _playerSource.volume = 0;
    }

    private void Update()
    {
        if(_isSignalPlaying)
        {
            if (VolumeVariant == VolumeVariatns.Increasing)
            {
                _volume = Mathf.MoveTowards(_volume, 1, _volumeIncreaseStep * Time.deltaTime);
                if (_volume >= 1) VolumeVariant = VolumeVariatns.Decreasing;
            }
            else
            {
                _volume = Mathf.MoveTowards(_volume, 0, _volumeIncreaseStep * Time.deltaTime);
                if (_volume <= 0.1) VolumeVariant = VolumeVariatns.Increasing;
            }
            _playerSource.volume = _volume;
            _playerSource.Play();
        }
    }

    public void RaiseAlarm()
    {
        _playerSource.clip = _signalingSound;
        _alarmRaised.Invoke();
    }

    public void PlaySignal()
    {
        _isSignalPlaying = true;
        //StartCoroutine(PlaySignalCoroutine());
    }

    public void StopSignal()
    {
        _isSignalPlaying = false;
        _playerSource.clip = null;
        _playerSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            RaiseAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StopSignal();
    }
}
