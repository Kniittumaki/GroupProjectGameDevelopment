using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AvainLaskuri : MonoBehaviour
{
    public int avainLaskuri {get; private set;}
    public int avaimiaKentassa;

    public HealthBar healthBar;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void lisaa()
    {
        avainLaskuri++;
        healthBar.SetKeys();
        //animator.Play("coin_collect");
        
    }

    public void vahenna()
    {
        avainLaskuri--;
        healthBar.SetKeys();
    }
}