using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastExample : MonoBehaviour
{
    private RaycastHit hit;
    private int layerMask;

    void Start()
    {
        layerMask = 1 << 8;    
    }
    void Update()
    {
       if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
       {
            Debug.Log("Hit Enemy " + hit.collider.gameObject.name);
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

       }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
        }
    }
}
