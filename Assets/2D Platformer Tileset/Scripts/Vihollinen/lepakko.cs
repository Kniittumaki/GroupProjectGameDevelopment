using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using System.Diagnostics.Tracing;

public class lepakko : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public GameObject nollaus;

    EnemyHealthBar enemyHealthBar;

    public Animator animator;

    BoxCollider2D boxCollider2D;
   
    SpriteRenderer sr;
    private float duration = 1f;

    private void Awake()
    {
        enemyHealthBar = GetComponentInChildren<EnemyHealthBar>();
    }
    void Start()
    {
     
        animator = GetComponentInChildren<Animator>();
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

            boxCollider2D.enabled = false;
            
            if(boxCollider2D.enabled != true)
            {

            gameObject.GetComponent<AIDestinationSetter>().target=null;
            gameObject.GetComponent<AIPath>().gravity.y = 3;
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
