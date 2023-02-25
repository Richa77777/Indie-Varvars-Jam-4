using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInPodjezd : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject _whatOn;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _whatOn.SetActive(true);
        _audioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _whatOn.SetActive(false);
        _audioSource.Stop();
    }
}
