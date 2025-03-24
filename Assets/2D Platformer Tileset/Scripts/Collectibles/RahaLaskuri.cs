using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RahaLaskuri : MonoBehaviour
{
    public int countCoins {get; private set;}
    public int maxCoins = 20;

    public HealthBar healthBar;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void count()
    {
        countCoins++;
        healthBar.SetCoins();
        //animator.Play("coin_collect");
        if (countCoins >= maxCoins)
        {
            
            PlayerPrefs.Save();
            SceneController.instance.NextLevel();
        }
        
    }
}
