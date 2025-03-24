using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pelaajaLiike2 : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    public pelaajanAanet pelaajanAanet;
    public RahaLaskuri rahaLaskuri;

    public AvainLaskuri avainLaskuri;
    
    Animator animator;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;

    private float horizontalInput;

    private int ase = 1;

    public Transform arrowStart; 
    public GameObject arrowSprite;
    public float arrowSpeed;
    public float arrowShootTime;

    private float lastSwordHit = 0f;
    public float swordHitTime;
    float lastArrow;
    public bool pelaajanSuuntaOikealle;

    private GameObject swordHitArea = default;

    bool attacking;

    private float timer = 0f;

    private float jumpCounter;
    public float jumpTime;
    private bool isJumping;

    public Text WINTEXT;
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
        animator.SetLayerWeight(0,0);
        animator.SetLayerWeight(ase,1);
        swordHitArea = transform.GetChild(0).gameObject;
                  
    }

    const float _timeBetweenFootsteps = 0.3f;
    float _lastPlayedFootstepSoundTime = -_timeBetweenFootsteps;
    // Update is called once per frame
    void Update()
    {
 
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (horizontalInput > 0.01f) 
        {
            transform.localScale = Vector3.one;
            pelaajanSuuntaOikealle=true;
            if (Time.timeSinceLevelLoad - _lastPlayedFootstepSoundTime > _timeBetweenFootsteps && IsGrounded())
            {
                pelaajanAanet.liike_aani();
                _lastPlayedFootstepSoundTime = Time.timeSinceLevelLoad;
            }
        }
        else if(horizontalInput < -0.01f) 
        {
            transform.localScale = new Vector3(-1,1,1);
            pelaajanSuuntaOikealle=false;
            if (Time.timeSinceLevelLoad - _lastPlayedFootstepSoundTime > _timeBetweenFootsteps && IsGrounded())
            {
                pelaajanAanet.liike_aani();
                _lastPlayedFootstepSoundTime = Time.timeSinceLevelLoad;
            }
        }

        animator.SetBool("run", horizontalInput !=0);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            isJumping = true;
            jumpCounter = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            pelaajanAanet.hyppy_aani();
                               
        }

        if(rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime) isJumping = false;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
      
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }


        if(rb.velocity.y == 0)
        {
            animator.SetBool("jump",false);
            animator.SetBool("fall", false);
        }

        if(rb.velocity.y > 0)
        {
            animator.SetBool("jump", true);
        }

        if(rb.velocity.y < 0)
        {
            animator.SetBool("jump", false);
            animator.SetBool("fall", true);
        }

       

        if (Input.GetKeyDown(KeyCode.B))
        {
        pelaajaHyokkaa();
        }


        aseenVaihto();

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= swordHitTime)
            {
                timer = 0;
                attacking = false;
                swordHitArea.SetActive(attacking);
            }
        }

    }

    //level 4 pelaaja voittaa

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }


    bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center,boxCollider2D.bounds.size,0f,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }

    void aseenVaihto()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            if(ase==1)
            {
            animator.SetLayerWeight(ase,0);
            ase += 1;
            animator.SetLayerWeight(ase,1);
            pelaajanAanet.vaihto_aani();
            }
            else
            {
            animator.SetLayerWeight(ase,0);
            ase -= 1;
            animator.SetLayerWeight(ase,1);
            pelaajanAanet.vaihto_aani();
            }

        }
    }

    void pelaajaHyokkaa()
    {
        if(ase == 1)
        {
            if(Time.time-lastSwordHit<swordHitTime)
            {
         
                return;
            }

            lastSwordHit = Time.time;
            attacking = true;
            swordHitArea.SetActive(attacking);           

            animator.SetTrigger("attack");
            pelaajanAanet.miekka_aani();
         
        }

        if(ase==2)
        {
            if(Time.time-lastArrow<arrowShootTime)
            {
                return;
            }
            lastArrow = Time.time;
            var arrow =  Instantiate(arrowSprite, arrowStart.position,arrowStart.rotation);
 
            if(pelaajanSuuntaOikealle)
            {
                arrow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * arrowSpeed);
            }
            else
            {
                arrow.GetComponent<Rigidbody2D>().AddForce(Vector2.left * arrowSpeed);
                arrow.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
                arrow.GetComponentInChildren<ParticleSystem>().transform.Rotate(0,0,180);
            }
            animator.SetTrigger("attack");
            pelaajanAanet.jousipyssy_aani();       
        }
    
    }
    
}
