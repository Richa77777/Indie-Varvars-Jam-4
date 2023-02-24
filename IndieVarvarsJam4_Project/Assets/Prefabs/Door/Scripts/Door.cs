using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Door _attachDoor;
    [SerializeField] private GameObject _point;

    [SerializeField] private AudioClip _doorSound;
    private AudioSource _audioSource;

    public GameObject PointGet => _point;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _doorSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player component))
        {
            _audioSource.Play();

            collision.gameObject.transform.position = _attachDoor.PointGet.transform.position;
            component.SetCameraToPlayer();
        }
    }
}
