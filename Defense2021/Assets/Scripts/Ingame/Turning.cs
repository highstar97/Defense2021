using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    Collider range;
    public bool chk = true;
    GameObject p;
    public GameObject target;
    void Awake()
    {
        range = GetComponent<BoxCollider>();
        p = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != other.gameObject.tag && chk)
        {
            p.transform.LookAt(other.transform);
            target = other.gameObject;
            chk = false;
        }
    }
}


