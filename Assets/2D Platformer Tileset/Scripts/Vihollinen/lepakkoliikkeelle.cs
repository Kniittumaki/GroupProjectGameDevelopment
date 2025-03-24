using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class lepakkoliikkeelle : MonoBehaviour
{

    
    public Transform playerTransform;
    public float havaintoEtaisyys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, playerTransform.position) < havaintoEtaisyys)
        {
            gameObject.GetComponent<AIPath>().canMove = true;
        }

    }
}
