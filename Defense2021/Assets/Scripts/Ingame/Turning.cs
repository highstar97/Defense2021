using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    Collider range;
    GameObject p;
    public GameObject target = null;
    Quaternion tmp;
    void Awake()
    {
        range = GetComponent<BoxCollider>();
        p = transform.parent.gameObject;
        tmp = p.transform.rotation;
    }
    void OnTriggerEnter(Collider other)
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (target == null)
            target = other.gameObject;
        Stats o_st = other.gameObject.GetComponent<Stats>();

        if (o_st.CurHp <= 0 || other == null)
        {
            p.transform.rotation = tmp;
            target = null;
        }
        if (target != null && gameObject.tag != target.gameObject.tag)
        {
            p.transform.LookAt(target.transform);
        }
    }
    void OnTriggerExit(Collider other)
    {
        return;
    }
}


