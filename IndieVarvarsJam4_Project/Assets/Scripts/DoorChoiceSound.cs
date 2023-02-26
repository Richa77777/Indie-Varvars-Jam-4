using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChoiceSound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDoorSound()
    {
        _audioSource.Play();
    }
}
