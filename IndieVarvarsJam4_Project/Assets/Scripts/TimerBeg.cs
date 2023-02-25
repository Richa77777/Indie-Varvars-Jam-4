using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBeg : MonoBehaviour
{
    private Player _player;

    [SerializeField] private float _timeForRun;
    [SerializeField] private float _speedMultiplier;

    private float _currentTime;


    private void Start()
    {
        _player = FindObjectOfType<Player>(true);
        
        _currentTime = _timeForRun;
    }

    public void TimerRun()
    {
        _player.AnimatorGet.SetFloat("SpeedMultiplier", _speedMultiplier);
    }

    public void Kill()
    {
        _player.BlockMove();
    }
}
