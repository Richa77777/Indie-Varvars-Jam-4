using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWakeUp : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _notPlayer;

    private DialogSystem.DialogController _dialogController;
    private DialogSystem.Dialog _dialog;

    private void Awake()
    {
        PlayerPrefs.SetInt("Deaths", 0);
    }

    private void Start()
    {
        _dialog = GetComponent<DialogSystem.Dialog>();
        _dialogController = FindObjectOfType<DialogSystem.DialogController>(true);

        StartCoroutine(StartCor());
    }

    private IEnumerator StartCor()
    {
        yield return new WaitForSeconds(1.5f);

        _notPlayer.SetActive(false);
        _player.SetActive(true);

        yield return new WaitForSeconds(0.15f);

        _dialogController.PlayNewDialog(_dialog);
    }
}
