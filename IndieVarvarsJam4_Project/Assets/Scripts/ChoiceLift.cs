using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ChoiceLift : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private GameObject _vklEgo;

    private LiftController _liftController;
    private Player _player;
    private Animator _animator;

    private IEnumerator _otrkLiftCor;
    private IEnumerator _zaxodVLiftCor;

    private void Start()
    {
        _player = FindObjectOfType<Player>(true);
        _animator = GetComponent<Animator>();
        _liftController = GetComponent<LiftController>();
    }

    public void OtrkLift()
    {
        _otrkLiftCor = OtrkLiftCor();
        StartCoroutine(_otrkLiftCor);
    }

    private IEnumerator OtrkLiftCor()
    {
        _liftController.NajalKnopkuSound();

        yield return new WaitForSeconds(1f);

        _liftController.AudioSourceGet.loop = true;
        _liftController.LiftEdetSound();

        yield return new WaitForSeconds(Random.Range(5f, 10f));
        _liftController.AudioSourceGet.Stop();
        _liftController.AudioSourceGet.loop = false;

        _animator.Play("LiftOtkr", 0, 0f);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length + 0.5f);

        _liftController.LiftPribilSound();

        _vklEgo.SetActive(true);

    }

    public void ZaxodVLift()
    {
        _zaxodVLiftCor = ZaxodVLiftCor();

        StartCoroutine(_zaxodVLiftCor);
    }

    private IEnumerator ZaxodVLiftCor()
    {
        Vector3 target = new Vector3(_player.transform.position.x, _player.transform.position.y + 0.35f, _player.transform.position.z);

        while (_player.transform.position != target)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, target, 1f * Time.deltaTime);
            yield return null;
        }

        _player.GetComponent<SpriteRenderer>().sortingOrder = -9;

        yield return new WaitForSeconds(3.5f);

        _liftController.AudioSourceGet.loop = false;
        _liftController.DoorsClosedSound();
        _animator.Play("LiftZakr", 0, 0f);

        yield return new WaitForSeconds(3.5f);

        _liftController.AudioSourceGet.loop = true;
        _liftController.LiftEdetSound();

        Color color = _player.GetComponent<SpriteRenderer>().color;
        color.a = 0f;
        _player.GetComponent<SpriteRenderer>().color = color;

        _player.BlockMove();

        target = new Vector3(_player.transform.position.x, _player.transform.position.y - 15f, _player.transform.position.z);

        while (_player.transform.position != target)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, target, 1f * Time.deltaTime);
            yield return null;
        }

        _liftController.AudioSourceGet.loop = false;
        _liftController.LiftPeredPadenSound();
    }
}
