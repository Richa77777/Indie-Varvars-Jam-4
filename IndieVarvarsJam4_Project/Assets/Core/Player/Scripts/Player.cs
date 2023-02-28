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

        _audioSource.clip = _stepSound;
    }

    private void Update()
    {
        if (_moveBlock == false)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (_animator.enabled == false)
                {
                    _animator.enabled = true;
                }

                _animator.SetBool("isWalking", true);

                if (_idleCor != null)
                {
                    StopCoroutine(_idleCor);
                    _idleCor = null;
                    _animator.StopPlayback();
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

    [SerializeField] private bool _moveBlock = true;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public Animator AnimatorGet => _animator;

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        _rigidBody.velocity = new Vector2(_horizontal * _moveSpeed, _rigidBody.velocity.y);

    }

    private void StopMove()
    {
        _rigidBody.velocity = new Vector2(0, 0);
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    public void BlockMove()
    {
        _moveBlock = true;

        StopMove();

        _animator.SetBool("isWalking", false);
        _animator.StopPlayback();
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
}
