using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector3 _coordinates;

    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>(true);   
    }

    public void Teleportation()
    {
        _player.gameObject.transform.position = _coordinates;
    }
}
