using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameVrem : MonoBehaviour
{
    public static RestartGameVrem _restartGame;

    private void Start()
    {
        _restartGame = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
