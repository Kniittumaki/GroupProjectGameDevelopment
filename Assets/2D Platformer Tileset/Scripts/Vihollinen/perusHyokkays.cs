using System.Collections.Generic;
using UnityEngine;

public class perusHyokkays : MonoBehaviour
{
    public float attackCooldown = 1f; 
    public bool canAttack = true; 
    public Transform attackPoint; 
    public float attackRange = 1f;
    public GameObject vihollisenaanet;

    public int damage;
    
    public GameObject pelaajanelamat;

    Animator animator;


    void Start()
    {
        pelaajanelamat = GameObject.FindWithTag("Player");      

        animator = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        if (!canAttack)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                canAttack = true;
                attackCooldown = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (canAttack)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
     
                gameObject.GetComponent<vihollisenAanet>().ampuminen_aani();

                AttackPlayer();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (canAttack)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
     
                AttackPlayer();
            }
        }
    }

        private void OnCollisionExit2D(Collision2D other)
    {
        canAttack = false;   
    }

    private void AttackPlayer()
    {
        if (Vector2.Distance(transform.position, pelaajanelamat.transform.position) > attackRange)
        {
          
            animator.SetTrigger("attack");
            pelaajanelamat.GetComponent<pelaajanElamat>().takeDamage(damage);
                    

            canAttack = false;
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }



}

