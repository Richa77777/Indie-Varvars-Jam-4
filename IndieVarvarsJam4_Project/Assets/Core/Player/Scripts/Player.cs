using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _camera = Camera.main;

        _audioSource.clip = _stepSound;

        SetCameraToPlayer();
    }

    private void Update()
    {
        if (_moveBlock == false)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (_idleCor != null)
                {
                    StopCoroutine(_idleCor);
                    _idleCor = null;
                    _animator.StopPlayback();
                    _animator.SetBool("isWalking", true);
                }

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                Move();
            }


            else if (Input.GetAxisRaw("Horizontal") == 0)
            {
                StopMove();

                if (_idleCor == null)
                {
                    _animator.SetBool("isWalking", false);
                    _idleCor = IdleCor();
                    StartCoroutine(_idleCor);
                }
            }
        }

        MoveCameraToPlayer();
    }


    #region Move
    private Rigidbody2D _rigidBody;

    [Header("Player Move")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AudioClip _stepSound;

    private float _horizontal;

    private Animator _animator;
    private AudioSource _audioSource;

    private IEnumerator _idleCor;

    private bool _moveBlock = true;

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        _rigidBody.velocity = new Vector2(_horizontal * _moveSpeed, _rigidBody.velocity.y);

    }

    private void StopMove()
    {
        _rigidBody.velocity = new Vector2(0, 0);
        _animator.SetBool("isWalking", false);
        _animator.StopPlayback();
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    public void BlockMove()
    {
        _moveBlock = true;
        StopMove();
    }

    public void UnblockMove()
    {
        _moveBlock = false;
    }

    private IEnumerator IdleCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));

            if (_animator.GetBool("isWalking") == false)
            {
                _animator.Play("Idle", 0, 0f);
            }
        }
    }
    #endregion

    #region CameraMove
    private Camera _camera;

    [Space(15f)]
    [Header("Camera Move")]
    [SerializeField] private float _cameraMoveSpeed;
    [SerializeField] private float _yOffset;

    //[Space(15f)]

    //[SerializeField] private float _xAxisMin;
    //[SerializeField] private float _xAxisMax;

    //[SerializeField] private float _yAxisMin;
    //[SerializeField] private float _yAxisMax;

    public void SetCameraToPlayer()
    {
        //float xAxis = Mathf.Clamp(transform.position.x, _xAxisMin, _xAxisMax);
        //float yAxis = Mathf.Clamp(transform.position.y + _yOffset, _yAxisMin, _yAxisMax);

        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + _yOffset, _camera.transform.position.z);

        _camera.transform.position = targetPos;
    }

    private void MoveCameraToPlayer()
    {
        //float xAxis = Mathf.Clamp(transform.position.x, _xAxisMin, _xAxisMax);
        //float yAxis = Mathf.Clamp(transform.position.y + _yOffset, _yAxisMin, _yAxisMax);

        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + _yOffset, _camera.transform.position.z);

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPos, _cameraMoveSpeed * Time.deltaTime);
    }
    #endregion
}
