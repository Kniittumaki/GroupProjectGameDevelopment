using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow2 : MonoBehaviour
{
    private float FollowSpeed = 2f;
    private float yOffset = 2.8f;
    public Transform target;

    // Aloitetaan peli ilman skaalausta vasemmalle reunalle
    private bool initialPositionSet = false;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Laske uusi kameran sijainti
            float newCameraX = initialPositionSet ? Mathf.Clamp(target.position.x, transform.position.x, Mathf.Infinity) : target.position.x;
            float newCameraY = Mathf.Clamp(target.position.y + yOffset, Mathf.NegativeInfinity, Mathf.Infinity);
            float newCameraZ = -10f;

            // Luo uusi Vector3 uudella sijainnilla
            Vector3 newPos = new Vector3(newCameraX, newCameraY, newCameraZ);

            // K�yt� Lerpia seuratakseen pelaajaa sek� vaaka- ett� pystysuunnassa
            transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

            // Aseta initialPositionSet trueksi sen j�lkeen kun pelaajan sijainti on asetettu
            if (!initialPositionSet)
            {
                initialPositionSet = true;
            }
        }
    }
}
