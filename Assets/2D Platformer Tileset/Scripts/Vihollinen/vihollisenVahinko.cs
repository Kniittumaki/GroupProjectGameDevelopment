using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollisenVahinko : MonoBehaviour
{

    public int damage;
    //public pelaajanElamat pelaajanelamat;
    public GameObject pelaajanelamat;

    void Start()
    {
        pelaajanelamat = GameObject.FindWithTag("Player");

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            pelaajanelamat.GetComponent<pelaajanElamat>().takeDamage(damage);
        }
    }

}
