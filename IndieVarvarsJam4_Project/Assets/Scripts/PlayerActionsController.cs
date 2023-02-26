using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsController : MonoBehaviour
{
    [SerializeField] private int _diedAmount = 0;
    
    public int DiedAmountAdd
    {
        get
        {
            return _diedAmount;
        }

        set
        {
            _diedAmount += value;
            PlayerPrefs.SetInt("Deaths", _diedAmount);
        }
    }

    private void Start()
    {
        _diedAmount = PlayerPrefs.GetInt("Deaths");
    }
}
