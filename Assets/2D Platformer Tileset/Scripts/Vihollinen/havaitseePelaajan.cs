using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class havaitseePelaajan : MonoBehaviour
{


    Animator animator;
    public float moveSpeed;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    public perusLiike perusLiike;
    // Start is called before the first frame update
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
            
        }   

        if(transform.position.x < playerTransform.position.x)
        {
            perusLiike.moveSpeed = 1.5f;
        }   

    }
    else
    {
        if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
        }

    }

    }
}
