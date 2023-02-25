using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Door : MonoBehaviour
{
    [SerializeField] private Door _attachDoor;
    [SerializeField] private GameObject _point;
    [SerializeField] private UnityEvent _actions = new UnityEvent();
    [SerializeField] private PolygonCollider2D _colliderNextScene;

    [SerializeField] private AudioClip _doorSound;
    private AudioSource _audioSource;

    [SerializeField] private bool _doorOpen = false;

    private CinemachineConfiner _confiner;

    public bool DoorOpenGet => _doorOpen;
    public GameObject PointGet => _point;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_doorSound != null)
        {
            _audioSource.clip = _doorSound;
        }

        _confiner = FindObjectOfType<CinemachineConfiner>(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _doorOpen == true)
        {
            if (_attachDoor != null)
            {
                if (_doorSound != null)
                    _audioSource.Play();

                _confiner.InvalidatePathCache();
                _confiner.m_BoundingShape2D = _colliderNextScene;

                collision.gameObject.transform.position = _attachDoor.PointGet.transform.position;
            }
        }

        else if (_doorOpen == false)
        {
            _actions?.Invoke();
        }
    }

    public void OpenDoor()
    {
        _doorOpen = true;
    }
}
