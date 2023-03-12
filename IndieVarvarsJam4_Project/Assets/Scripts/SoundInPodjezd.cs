using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInPodjezd : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject[] _whatOn = new GameObject[2];

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < _whatOn.Length; i++)
        {
            _whatOn[i].SetActive(true);
        }

        _audioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < _whatOn.Length; i++)
        {
            _whatOn[i].SetActive(false);
        }

        _audioSource.Stop();
    }
}
