using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelaajanAanet : MonoBehaviour
{

   public AudioSource audioSource;
    public AudioClip hyppy;
    public AudioClip kuolema;
    public AudioClip miekka;
    public AudioClip jousipyssy;
    public AudioClip osuma; 
    public AudioClip kerays;
    public AudioClip vaihto;
    public AudioClip uudelleen;
    public AudioClip liike;
    public AudioClip avain;
    public AudioClip rikkominen;
    public AudioClip avaus;

    public void hyppy_aani()
    {
        audioSource.PlayOneShot(hyppy);
    }
    public void kuolema_aani()
    {
        audioSource.PlayOneShot(kuolema);
    }
    public void miekka_aani()
    {
        audioSource.PlayOneShot(miekka);
    }
    public void jousipyssy_aani()
    {
        audioSource.PlayOneShot(jousipyssy);
    }
    public void osuma_aani()
    {
        audioSource.PlayOneShot(osuma);
    } 
    public void kerays_aani()
    {
        audioSource.PlayOneShot(kerays);
    } 
    public void vaihto_aani()
    {
        audioSource.PlayOneShot(vaihto);
    }
    public void uudelleen_aani()
    {
        audioSource.PlayOneShot(uudelleen);
    }
    public void liike_aani()
    {
        audioSource.PlayOneShot(liike);
    }
    public void avain_aani()
    {
        audioSource.PlayOneShot(avain);
    }
    public void rikkominen_aani()
    {
        audioSource.PlayOneShot(rikkominen);
    }
    public void avaus_aani()
    { 
        audioSource.PlayOneShot(avaus);
    }
}
