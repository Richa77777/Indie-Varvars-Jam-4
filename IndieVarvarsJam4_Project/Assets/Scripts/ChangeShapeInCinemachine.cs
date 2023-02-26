using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeShapeInCinemachine : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _colliderNextScene;
    private CinemachineConfiner _confiner;

    private void Start()
    {
        _confiner = FindObjectOfType<CinemachineConfiner>(true);
    }
    
    public void ChangeShape()
    {
        _confiner.InvalidatePathCache();
        _confiner.m_BoundingShape2D = _colliderNextScene;
    }
}
