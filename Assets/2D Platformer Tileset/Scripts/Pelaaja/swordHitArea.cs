using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHitArea : MonoBehaviour
{
  
    public int swordDamage;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<vihollisenElamat>() != null)
        {
            vihollisenElamat vihollisenElamat = collider.GetComponent<vihollisenElamat>();
       
            vihollisenElamat.takeDamage(swordDamage);


        }

        if(collider.GetComponent<lepakko>() != null)
        {
            lepakko lepakko = collider.GetComponent<lepakko>();
       
            lepakko.takeDamage(swordDamage);


        }
    }

}
