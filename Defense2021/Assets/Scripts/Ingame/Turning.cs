using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    Collider range;
    GameObject p;
    void Awake()
    {
        range = GetComponent<BoxCollider>();
        p = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != other.gameObject.tag)
        {
            p.transform.LookAt(other.transform);
        }
    }  
}
