using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class avaaArkku : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;

    SpriteRenderer sr;
    private float duration = 5f;
    BoxCollider2D boxCollider2D;

    public pelaajanAanet pelaajanAanet;

    public GameObject avaimia;

    public GameObject prefab;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        avaimia = GameObject.FindWithTag("Player");
        ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
        ps.Stop();
    
    }

    void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<AvainLaskuri>().avainLaskuri !=0)
        {
            boxCollider2D.enabled = false;
            rb.velocity = new Vector2(0,0);
            animator.SetTrigger("avaa");
            avaimia.GetComponent<AvainLaskuri>().vahenna();
            pelaajanAanet.avaus_aani();
            ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
            ps.Play();
            

            rb.bodyType=RigidbodyType2D.Static;
                       
            Vector3 right = transform.right;
     
            for(var i = 0; i < 10; i++)
            {
                Vector3 position = transform.position;
                var coin = Instantiate(prefab, position, Quaternion.identity);
                float kulma = UnityEngine.Random.Range(-30,30);
                Vector2 suunta = Quaternion.Euler(0,0,kulma) * Vector2.up;
                Rigidbody2D coinRB = coin.GetComponent<Rigidbody2D>();
                CircleCollider2D coinCollider = coin.GetComponent<CircleCollider2D>();
                coinCollider.isTrigger = false;
                coinRB.gravityScale=1;
                coinRB.AddForce(suunta * 7f, ForceMode2D.Impulse);

            }


            StartCoroutine(Fade());

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
