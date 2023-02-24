using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private Door _attachDoor;
    [SerializeField] private GameObject _point;
    [SerializeField] private UnityEvent _actions = new UnityEvent();

    [SerializeField] private AudioClip _doorSound;
    private AudioSource _audioSource;

    private bool _doorOpen = false;

    public bool DoorOpenGet => _doorOpen;
    public GameObject PointGet => _point;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _doorSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player component) && _doorOpen == true)
        {
            if (_attachDoor != null)
            {
                _audioSource.Play();

                collision.gameObject.transform.position = _attachDoor.PointGet.transform.position;
                component.SetCameraToPlayer();
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
