using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;

        float xAxis = Mathf.Clamp(transform.position.x, _xAxisMin, _xAxisMax);
        float yAxis = Mathf.Clamp(transform.position.y + _yOffset, _yAxisMin, _yAxisMax);

        Vector3 targetPos = new Vector3(xAxis, yAxis, _camera.transform.position.z);

        _camera.transform.position = targetPos;
    }

    private void Update()
    {
        MoveCameraToPlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region Move
    private Rigidbody2D _rigidBody;

    [Header("Player Move")]
    [SerializeField] private float _moveSpeed;

    private float _horizontal;

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        _rigidBody.velocity = new Vector2(_horizontal * _moveSpeed, _rigidBody.velocity.y);
    }
    #endregion

    #region CameraMove
    private Camera _camera;

    [Space(15f)]
    [Header("Camera Move")]
    [SerializeField] private float _cameraMoveSpeed;
    [SerializeField] private float _yOffset;

    [Space(15f)]

    [SerializeField] private float _xAxisMin;
    [SerializeField] private float _xAxisMax;

    [SerializeField] private float _yAxisMin;
    [SerializeField] private float _yAxisMax;

    private void MoveCameraToPlayer()
    {
        float xAxis = Mathf.Clamp(transform.position.x, _xAxisMin, _xAxisMax);
        float yAxis = Mathf.Clamp(transform.position.y + _yOffset, _yAxisMin, _yAxisMax);

        Vector3 targetPos = new Vector3(xAxis, yAxis, _camera.transform.position.z);

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPos, _cameraMoveSpeed * Time.fixedDeltaTime);
    }


    #endregion

}
