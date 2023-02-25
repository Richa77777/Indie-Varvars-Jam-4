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

    private CanvasGroup _canvasGroup;
    
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        _dialog = GetComponent<DialogSystem.Dialog>();
        _dialogController = FindObjectOfType<DialogSystem.DialogController>(true);
    }

    public void StartNat()
    {
        StartCoroutine(StartCor());
    }

    private IEnumerator StartCor()
    {
        _notPlayer.SetActive(false);
        _player.SetActive(true);

        gameObject.GetComponent<Button>().interactable = false;
        _canvasGroup.alpha = 0f;

        yield return new WaitForSeconds(0.1f);
        
        _dialogController.PlayNewDialog(_dialog);
    }
}
