using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedScript : MonoBehaviour
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

    public void Died()
    {
        _actionsController.DiedAmountAdd = 1;
        _diedCor = DiedCor();

        StartCoroutine(_diedCor);
    }

    private IEnumerator DiedCor()
    {
        yield return new WaitForSeconds(7.5f);

        _player.AnimatorGet.enabled = false;

        _player.BlockMove();

        _player.AnimatorGet.enabled = false;

        yield return new WaitForSeconds(0.1f);

        _audioSource.PlayOneShot(_boom);
        _playerRenderer.sprite = _koleni;

        yield return new WaitForSeconds(1f);

        _audioSource.PlayOneShot(_zadixaetsa);

        yield return new WaitForSeconds(1f);

        _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 0.75f, _player.transform.position.z);
        _playerRenderer.sprite = _died;

        yield return new WaitForSeconds(2.5f);

        RestartGameVrem._restartGame.Restart();
    }

    public void DiedBezZad()
    {
        _diedCor = DiedBezZadCor();

        StartCoroutine(_diedCor);
    }

    private IEnumerator DiedBezZadCor()
    {
        _player.BlockMove();

        _player.AnimatorGet.enabled = false;

        _audioSource.PlayOneShot(_boom);
        _playerRenderer.sprite = _koleni;

        yield return new WaitForSeconds(1f);

        _audioSource.PlayOneShot(_zadixaetsa);

        yield return new WaitForSeconds(1f);

        _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y - 0.75f, _player.transform.position.z);
        _playerRenderer.sprite = _died;

        yield return new WaitForSeconds(2.5f);

        RestartGameVrem._restartGame.Restart();
    }
}
