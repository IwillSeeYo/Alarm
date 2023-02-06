using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    const float MaxVolume = 1.0f;
    const float MinVolume = 0f;
    const float StepVolume = 0.02f;

    private Coroutine _coroutineActiveSound;
    private float _requiredVolume;

    private void Start()
    {
        _audioSource.volume = MinVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            Playback(MaxVolume);
            _audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            Playback(MinVolume);
        }
    }

    private void Playback(float requiredVolume)
    {
        if (_coroutineActiveSound != null)
            StopCoroutine(_coroutineActiveSound);

        _requiredVolume = requiredVolume;
        _coroutineActiveSound = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _requiredVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _requiredVolume, StepVolume * Time.deltaTime);

            yield return null;
        }
    }
}
