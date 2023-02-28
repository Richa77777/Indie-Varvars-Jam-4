using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UlicaScript : MonoBehaviour
{
    [SerializeField] private AudioClip _boom;
    [SerializeField] private AudioClip _zadixaetsa;

    [SerializeField] private Sprite _koleni;
    [SerializeField] private Sprite _died;

    private Player _player;
    private SpriteRenderer _playerRenderer;

    private AudioSource _audioSource;

    private IEnumerator _diedCor;

    private PlayerActionsController _actionsController;

    private void Start()
    {
        _player = FindObjectOfType<Player>(true);
        _audioSource = GetComponent<AudioSource>();
        _playerRenderer = _player.gameObject.GetComponent<SpriteRenderer>();
        _actionsController = FindObjectOfType<PlayerActionsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _actionsController.DiedAmountAdd = 1;
        _diedCor = DiedCor();

        StartCoroutine(_diedCor);
    }

    private IEnumerator DiedCor()
    {
        _player.BlockMove();

        _audioSource.PlayOneShot(_boom);
        _playerRenderer.sprite = _koleni;

        yield return new WaitForSeconds(1f);

        _audioSource.PlayOneShot(_zadixaetsa);

        yield return new WaitForSeconds(1f);

        _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 0.75f, _player.transform.position.z);
        _playerRenderer.sprite = _died;

        yield return new WaitForSeconds(1f);

        RestartGameVrem._restartGame.Restart();
    }
}
