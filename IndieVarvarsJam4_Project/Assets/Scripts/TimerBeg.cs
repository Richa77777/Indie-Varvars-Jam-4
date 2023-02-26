using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBeg : MonoBehaviour
{
    private Player _player;

    [SerializeField] private float _timeForRun;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private TextMeshProUGUI _textTimer;

    private float _currentTime;

    private IEnumerator _timerCor;

    private DiedScript _diedScript;

    private void Start()
    {
        _player = FindObjectOfType<Player>(true);
        _diedScript = GetComponent<DiedScript>();

        _currentTime = _timeForRun;
    }
    public void Kill()
    {
        _diedScript.DiedBezZad();
    }

    public void TimerRun()
    {
        _player.AnimatorGet.SetFloat("SpeedMultiplier", _speedMultiplier);
        _player.MoveSpeed *= _speedMultiplier;

        _textTimer.gameObject.SetActive(true);

        _timerCor = TimerCor();

        StartCoroutine(_timerCor);
    }

    private IEnumerator TimerCor()
    {
        while (_currentTime != 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;

            if (_currentTime < 10)
            {
                _textTimer.text = $"00:0{_currentTime}";
            }
            
            else if (_currentTime >= 10)
            {
                _textTimer.text = $"00:{_currentTime}";
            }
        }

        Kill();
    }
}
