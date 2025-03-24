using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void newGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
