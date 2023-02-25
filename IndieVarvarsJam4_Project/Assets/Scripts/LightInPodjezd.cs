using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInPodjezd : MonoBehaviour
{
    [SerializeField] private AudioClip _brokenLampSound;

    private Animator _animator;
    private AudioSource _audioSource;

    private IEnumerator _lightCor;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _brokenLampSound;
    }

    private void OnEnable()
    {
        _lightCor = LightCor();
        StartCoroutine(_lightCor);
    }

    private void OnDisable()
    {
        StopCoroutine(_lightCor);
        _lightCor = null;
    }

    private IEnumerator LightCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 25f));
            _animator.Play("LightInPodjezd", 0, 0f);
        }
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
