using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvainKerays : MonoBehaviour

{
    void OnTriggerEnter2D(Collider2D other)
    {

        AvainLaskuri avainLaskuri = other.GetComponent<AvainLaskuri>();
        pelaajanAanet pelaajanAanet = other.GetComponent<pelaajanAanet>();

        if(avainLaskuri != null)
        {
            avainLaskuri.lisaa();
            pelaajanAanet.avain_aani();
            gameObject.SetActive(false);
        }

    } 
}
