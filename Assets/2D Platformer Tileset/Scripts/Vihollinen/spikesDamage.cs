using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesDamage : MonoBehaviour
{
    public int damage;

    public GameObject pelaajanelamat;

    void Start()
    {
        pelaajanelamat = GameObject.FindWithTag("Player");

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

            if (other.gameObject.tag == "Player")
            {
            pelaajanelamat.GetComponent<pelaajanElamat>().takeDamage(damage);

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40, ForceMode2D.Impulse);
            }
       
    }

}
