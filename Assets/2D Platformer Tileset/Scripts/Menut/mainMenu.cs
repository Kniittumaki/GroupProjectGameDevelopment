using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour

{


    // Start is called before the first frame update
    public void PlayGame()
    {

        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }

      public void quitGame()
    {
        Application.Quit();
    }


}
