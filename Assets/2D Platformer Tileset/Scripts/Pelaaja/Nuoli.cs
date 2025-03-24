using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuoli : MonoBehaviour
{
    public float life = 3;
    public int damage;
    Animator animator;

    Rigidbody2D rb;

   // private GameObject pelaaja; 
    void Awake()
    {
        Destroy(gameObject, life);
              
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

      
        if(collider.gameObject.TryGetComponent<vihollisenElamat>(out vihollisenElamat vihollinenComponent ))
        {
            
            vihollinenComponent.takeDamage(damage);
       
            animator.Play("Impact_2");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(0,0);
        }
        if(collider.gameObject.TryGetComponent<lepakko>(out lepakko lepakkoComponent ))
        {
            
            lepakkoComponent.takeDamage(damage);
       
            animator.Play("Impact_2");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(0,0);
        }

        if(collider.tag == "Ground")
        {
            //pelaaja.GetComponent<pelaajaLiike2>().arrowSpeed = 0;
            animator.Play("Impact_2");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(0,0);
        }
        if(collider.tag == "Object")
        {
            //pelaaja.GetComponent<pelaajaLiike2>().arrowSpeed = 0;
            animator.Play("Impact_2");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(0,0);
        }

        if(collider.tag == "Avattava")
        {
            //pelaaja.GetComponent<pelaajaLiike2>().arrowSpeed = 0;
            animator.Play("Impact_2");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(0,0);
        }
        /*     if(collider.tag == "Ground")
        {
            //pelaaja.GetComponent<pelaajaLiike2>().arrowSpeed = 0;
            animator.Play("Avattava");
            Destroy(gameObject,0.5f);
            rb.velocity = new Vector2(0,0);
        }*/
        
    } 
}
