using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollisenAanet : MonoBehaviour
{
   public AudioSource audioSource;
    public AudioClip hyppy;
    public AudioClip ampuminen;
    public AudioClip kuolema;
    public AudioClip osuma;
    public AudioClip havaitsee;

    public void hyppy_aani()
    {
        audioSource.PlayOneShot(hyppy);
    }
    public void kuolema_aani()
    {
        audioSource.PlayOneShot(kuolema);
    }
    public void ampuminen_aani()
    {
        audioSource.PlayOneShot(ampuminen);
    }
    public void osuma_aani()
    {
        audioSource.PlayOneShot(osuma);
    }
    public void havaitsee_aani()
    {
        audioSource.PlayOneShot(havaitsee);
    }

}
