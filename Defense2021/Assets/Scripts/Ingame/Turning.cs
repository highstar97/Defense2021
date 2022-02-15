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
        Stats o_st = other.gameObject.GetComponent<Stats>();
        if (o_st.CurHp <= 0)
        {
            p.transform.rotation = tmp;
            if (other.gameObject != target)
                target = other.gameObject;
        }
        if (gameObject.tag != other.gameObject.tag && target == null)
        {
            p.transform.LookAt(other.transform);
            target = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        return;
    }
}


