using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossi_hyppy : MonoBehaviour
{

    Rigidbody2D rb;

    public int jumpForce;

    bool canJump = false;
    private float timer = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        if(canJump)
        {
            timer += Time.deltaTime;

            if(timer >= 5)
            {
                timer = 0;
                canJump = false;
            }
        }

    }
    public void bossJump()
    {

        int arpa = UnityEngine.Random.Range(0,2000);

        if(arpa < 10 && rb.velocity.y == 0)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;

        }
    }


}
