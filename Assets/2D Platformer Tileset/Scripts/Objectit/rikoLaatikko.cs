using System.Collections;
using System.Collections.Generic;
//using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class rikoLaatikko : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;

    SpriteRenderer sr;
    private float duration = 5f;
    BoxCollider2D boxCollider2D;

    public pelaajanAanet PelaajanAanet;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Sword" || collider.tag == "Nuoli")
        {
            rb.velocity = new Vector2(0,0);
            animator.SetTrigger("break");
            boxCollider2D.enabled = false;
            rb.bodyType=RigidbodyType2D.Static;
            //Destroy(gameObject,3f);
            PelaajanAanet.rikkominen_aani();
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
