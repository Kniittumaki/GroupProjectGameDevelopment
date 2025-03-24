using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahaKerays : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {

        RahaLaskuri rahaLaskuri = other.GetComponent<RahaLaskuri>();
        pelaajanAanet pelaajanAanet = other.GetComponent<pelaajanAanet>();

        if(rahaLaskuri != null)
        {
            rahaLaskuri.count();
            pelaajanAanet.kerays_aani();
            gameObject.SetActive(false);
        }

    } 

        void OnCollisionEnter2D(Collision2D other)
    {

        RahaLaskuri rahaLaskuri = other.gameObject.GetComponent<RahaLaskuri>();
        pelaajanAanet pelaajanAanet = other.gameObject.GetComponent<pelaajanAanet>();

        if(rahaLaskuri != null)
        {
            rahaLaskuri.count();
            pelaajanAanet.kerays_aani();
            gameObject.SetActive(false);
        }

    } 
}
