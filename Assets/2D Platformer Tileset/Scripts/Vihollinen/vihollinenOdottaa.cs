using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollinenOdottaa : MonoBehaviour
{

    Animator animator;

    public float moveSpeed;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    public vihollisenAanet vihollisenAanet;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new  Vector3(1,1,1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }   

            if(transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new  Vector3(-1,1,1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }   
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            
      
            
        }

        
        animator.SetBool("run", moveSpeed !=0);
    }
}
