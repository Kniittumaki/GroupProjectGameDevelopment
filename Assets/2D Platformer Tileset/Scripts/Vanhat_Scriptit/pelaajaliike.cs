using System;
using System.CodeDom;
using UnityEngine;

public class pelaajaliike : MonoBehaviour
{
    private float horizontalInput;
    
    private bool isFacingRight = false;
   
    private bool isGrounded = false;

    [SerializeField]
     private float jumpPower = 8f;
     [SerializeField]
     private float moveSpeed = 10f;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        //transform.Translate(direction * moveSpeed * Time.deltaTime);

        FlipSprite();

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}