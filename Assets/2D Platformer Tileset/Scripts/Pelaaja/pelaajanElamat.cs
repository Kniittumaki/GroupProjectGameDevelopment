using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class pelaajanElamat : MonoBehaviour
{
    public gameOver gameover;
    Animator animator;
    public int maxHealth = 15;
    public int health;


    public int playerLives;

    public HealthBar healthBar;

    //private pelaajaLiike2 playerController;
    public pelaajanAanet pelaajanAanet;
    public GameObject pelaajanelamat;

    Vector2 startPosition;
    
    void Awake()
    {
        health = maxHealth;
        playerLives = PlayerPrefs.GetInt("PlayerCurrentLives");

    }
    
    // Start is called before the first frame update
        
    void Start()
    {


        animator = GetComponentInChildren<Animator>();
        startPosition = transform.position;
        pelaajanelamat = GameObject.FindWithTag("Player");
        ParticleSystem ps = GameObject.Find("Player").GetComponentInChildren<ParticleSystem>();
        ps.Stop();
        
    }

    // Update is called once per frame
    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.SetValue(health);
        ParticleSystem ps = GameObject.Find("Player").GetComponentInChildren<ParticleSystem>();
        ps.Play();
        pelaajanAanet.osuma_aani();
        //pelaajanelamat.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        //StartCoroutine(Whitecolor());

         
        if(health <= 0)
        {
            playerLives--;
            PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
            PlayerPrefs.Save();
            health = maxHealth;
            healthBar.SetValue(health);   

            if(playerLives!=0)
            {
                ReSpawn();
                pelaajanAanet.uudelleen_aani();
            }
            else
            {
                animator.Play("Die");
                pelaajanAanet.kuolema_aani();
                
                GameOver();
            }
        }




    }

    void ReSpawn()
    {
        transform.position = startPosition;
        playerLives = PlayerPrefs.GetInt("PlayerCurrentLives");

    }

    void GameOver()
    {
        gameover.Setup();
    }

    System.Collections.IEnumerator Whitecolor() {
        yield return new WaitForSeconds(0.5f);
        pelaajanelamat.GetComponentInChildren<SpriteRenderer> ().color = Color.white;

    }
}

