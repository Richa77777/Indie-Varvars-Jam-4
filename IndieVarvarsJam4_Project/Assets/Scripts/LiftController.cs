using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    [SerializeField] private AudioClip _doorsOpen;
    [SerializeField] private AudioClip _doorsClosed;
    [SerializeField] private AudioClip _liftPribil;
    [SerializeField] private AudioClip _najalKnopku;
    [SerializeField] private AudioClip _liftEdet;
    [SerializeField] private AudioClip _padenie;
    [SerializeField] private AudioClip _liftPeredPaden;
    [SerializeField] private AudioClip _liftSlomalsa;
    private AudioSource _audioSource;

    public AudioSource AudioSourceGet => _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DoorsOpenSound()
    {
        _audioSource.clip = _doorsOpen;
        _audioSource.Play();
    }

    public void DoorsClosedSound()
    {
        _audioSource.clip = _doorsClosed;
        _audioSource.Play();
    }

    public void LiftPribilSound()
    {
        _audioSource.clip = _liftPribil;
        _audioSource.Play();
    }

    public void NajalKnopkuSound()
    {
        _audioSource.clip = _najalKnopku;
        _audioSource.Play();
    }

    public void LiftEdetSound()
    {
        _audioSource.clip = _liftEdet;
        _audioSource.Play();
    }

    public void PadenieSound()
    {
        _audioSource.clip = _padenie;
        _audioSource.Play();
    }

    public void LiftPeredPadenSound()
    {
        _audioSource.clip = _liftPeredPaden;
        _audioSource.Play();
    }
    public void LiftSlomalsaSound()
    {
        _audioSource.clip = _liftSlomalsa;
        _audioSource.Play();
    }
}
