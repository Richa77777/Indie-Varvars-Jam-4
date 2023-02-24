using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region Move
    [Header("Player Move")]
    private Rigidbody2D _rigidBody;

    [SerializeField] private float _moveSpeed;

    private float _horizontal;

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        _rigidBody.velocity = new Vector2(_horizontal * _moveSpeed, _rigidBody.velocity.y);
    }

    //private void StopMove()
    //{
    //    _rigidBody.velocity = new Vector2(0, 0);
    //}

    #endregion

}
