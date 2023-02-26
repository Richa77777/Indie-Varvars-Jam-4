using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Uleeetaaaay : MonoBehaviour
{
    private Player _player;
    private CinemachineVirtualCamera _camera;

    private IEnumerator _vzletCor;

    [SerializeField] private AudioClip _boom;
    [SerializeField] private AudioClip _zasos;

    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource2;

    private void Start()
    {
        _player = FindObjectOfType<Player>(true);
        _camera = FindObjectOfType<CinemachineVirtualCamera>(true);

        _audioSource1.clip = _boom;
        _audioSource2.clip = _zasos;
    }

    public void Vzlet()
    {
        _vzletCor = VzletCor();

        StartCoroutine(_vzletCor);
    }

    private IEnumerator VzletCor()
    {
        _player.BlockMove();

        yield return new WaitForSeconds(2f);

        _camera.Follow = null;

        Vector3 target = new Vector3(_player.transform.position.x, _player.transform.position.y + 10f, _player.transform.position.z);

        _audioSource1.Play();

        yield return new WaitForSeconds(1f);

        _audioSource2.Play();

        while (_player.transform.position != target)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, target, 12f * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        RestartGameVrem._restartGame.Restart();
    }
}
