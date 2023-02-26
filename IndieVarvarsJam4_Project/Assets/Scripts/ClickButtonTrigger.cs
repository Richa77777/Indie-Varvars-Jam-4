using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _tab;
    [SerializeField] private UnityEvent _actions = new UnityEvent();

    [SerializeField] private bool _offIfClick = true;

    [SerializeField] private KeyCode _keyCode;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = transform.parent.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _tab.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _tab.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(_keyCode) && _tab.activeInHierarchy == true)
        {
            _audioSource.Play();

            _actions?.Invoke();

            if (_offIfClick == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
