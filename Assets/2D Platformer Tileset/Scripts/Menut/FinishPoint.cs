using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishPoint : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            RahaLaskuri rahaLaskuri = FindObjectOfType<RahaLaskuri>();
            if (rahaLaskuri != null && rahaLaskuri.countCoins >= rahaLaskuri.maxCoins)
            {
                //UnlockNewLevel();
                SceneController.instance.NextLevel();
            }
            else
            {
                Debug.Log("Kerää lisää kolikoita avataksesi seuraavan tason.");
            }
        }
    } 

   
   // pelin tallennus
    // void UnlockNewLevel()
    // {
    //      if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
    //    {
    //         PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
    //         PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) +1);
    //         PlayerPrefs.Save();
    //      }
    //  }
}
