using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;


public class enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator animator;
    
    
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
       

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);

        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            transform.localScale = Vector3.one;
            currentPoint = pointA.transform;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            transform.localScale = new Vector3(-1,1,1);
            currentPoint = pointB.transform;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
