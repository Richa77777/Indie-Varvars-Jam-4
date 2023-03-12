using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField] private GameObject _image1;
    [SerializeField] private GameObject _image2;

    public void OnAll()
    {
        _image1.SetActive(true);
        _image2.SetActive(true);

        Time.timeScale = 0f;
    }
}