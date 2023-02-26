using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEnterActions;
    [SerializeField] private UnityEvent _triggerExitActions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _triggerEnterActions?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _triggerExitActions?.Invoke();
        }
    }
}
