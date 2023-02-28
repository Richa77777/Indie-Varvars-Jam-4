using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckList : MonoBehaviour
{
    [SerializeField] private GameObject _listok;
    [SerializeField] private UnityEvent _actions = new UnityEvent();

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>(true);
    }

    public void ListCheck()
    {
        StartCoroutine(ListCheckCor());
    }

    private IEnumerator ListCheckCor()
    {
        _player.BlockMove();
        _listok.SetActive(true);

        yield return new WaitForSeconds(2f);

        _listok.SetActive(false);
        _player.UnblockMove();
        _actions?.Invoke();
    }
}
