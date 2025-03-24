using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class vihollisenElamat : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public GameObject nollaus;

    EnemyHealthBar enemyHealthBar;

    public Animator animator;
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    public GameObject pelivoitto;
   
    SpriteRenderer sr;
    private float duration = 5f;

    private void Awake()
    {

        enemyHealthBar = GetComponentInChildren<EnemyHealthBar>();
    }
    void Start()
    {
  
        pelivoitto = GameObject.FindWithTag("Win");
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        health = maxHealth;
        enemyHealthBar.UpdateHealthBar(health,maxHealth);

        ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
        ps.Stop();

    }

    public void takeDamage(int damage)
    {

        health -= damage;
        enemyHealthBar.UpdateHealthBar(health,maxHealth);

        ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
        ps.Play();
        gameObject.GetComponent<vihollisenAanet>().osuma_aani();

        if (health <= 0)
        {

            if(gameObject.GetComponent<bossi_hyppy>() !=null)
            {
                pelivoitto.GetComponent<voitto>().pelivoitettu();
            }
            
            boxCollider2D.enabled = false;
            
            if(boxCollider2D.enabled != true)
            {
                  
       
            gameObject.GetComponent<perusLiike>().chaseSpeed=0;
            gameObject.GetComponent<perusLiike>().moveSpeed=0;
            gameObject.GetComponent<perusLiike>().patrolSpeed=0;
            gameObject.GetComponent<perusLiike>().isChasing=false;
            rb.bodyType=RigidbodyType2D.Static;
            animator.SetTrigger("die");
            gameObject.GetComponent<vihollisenAanet>().kuolema_aani();

            StartCoroutine(Fade());
         
 
            }
        }
    }

    private IEnumerator Fade()
    {
        float time = 0.0f;

        while(time<duration)
        {
            float alpha = Mathf.Lerp(2.0f,0.0f,time/duration);
            Color newColor = sr.color;
            newColor.a = alpha;
            sr.color = newColor;

            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
      
    }

}
