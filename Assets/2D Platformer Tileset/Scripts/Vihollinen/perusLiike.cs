using System;
using UnityEngine;

public class perusLiike : MonoBehaviour
{
    public float patrolSpeed; 
    public float chaseSpeed;

    public float moveSpeed;

    public float raycastDistance; 
    public Transform tarkistusPiste;

    //public Transform playerTransform;

    public bool isFacingRight = true; 
 
    public bool isChasing;
    public float chaseDistance;

    private Vector2 suunta = new Vector2(1,0);
    private Rigidbody2D rb; 
    
    Animator animator;

    [HideInInspector]
    public GameObject playerTransform;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerTransform = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(tarkistusPiste.position, suunta, raycastDistance);
        if(hit == true)
        {
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Object"))
            {
                if(isFacingRight)
                {
                    isFacingRight = false;
                }
                else
                {
                    isFacingRight = true;
                }
  
            }
            
        }
   
        if(Vector2.Distance(transform.position, playerTransform.transform.position) < chaseDistance)
        {
            isChasing = true;
            moveSpeed = chaseSpeed;
            animator.SetBool("run", moveSpeed > patrolSpeed);
            animator.SetBool("walk", false);
          

        }
        else
        {
            isChasing = false;
            moveSpeed = patrolSpeed;
            animator.SetBool("walk", moveSpeed !=0);
            animator.SetBool("run", false);
    
   
        }
        
        if (isChasing)
        {
            if(transform.position.x > playerTransform.transform.position.x)
            {
                transform.localScale = new  Vector3(-1,1,1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                suunta = new Vector2(-1,0);
                isFacingRight = false;
            }   

            if(transform.position.x < playerTransform.transform.position.x)
            {
                transform.localScale = new  Vector3(1,1,1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                suunta = new Vector2(1,0);
                isFacingRight = true;
            }   
        }

        else
        {
            if(isFacingRight)
            {
            transform.localScale = new  Vector3(1,1,1);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            suunta = new Vector2(1,0);
            }
            else
            {
            transform.localScale = new  Vector3(-1,1,1);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            suunta = new Vector2(-1,0);
            }
        }

        if(gameObject.GetComponent<bossi_hyppy>() !=null)
        {
            gameObject.GetComponent<bossi_hyppy>().bossJump();
        }

          
    }

    
}

