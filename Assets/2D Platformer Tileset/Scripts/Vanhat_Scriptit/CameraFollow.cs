using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 3.2f;
    public Transform target;

    public float minBoundsX = -5.2f;  // Aseta vain minirajoitus X-akselille
    // public float maxBoundsX = ...;  // Voit asettaa myös mahdollisen maksimirajoituksen X-akselille

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            Vector3 smoothedPosition = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

            // Rajoitetaan uusi sijainti määritettyihin rajoituksiin
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBoundsX, /*maxBoundsX*/Mathf.Infinity);

            transform.position = smoothedPosition;
        }
    }
}