using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private bool isOkay = true;
    public float entitytime, pos_x, pos_y, pos_z;
    public GameObject thisunit;
    Stats unitstat;
    private void Awake()
    {
        unitstat = thisunit.gameObject.GetComponent<Stats>();
    }
    void Update()
    {
        if(unitstat.CurHp <= 0)
        {
            isOkay = false;
        }
        if(isOkay)
        {
            transform.Translate(new Vector3(pos_x, pos_y, pos_z) * entitytime);
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        isOkay = false;
       
    }
    private void OnCollisionStay(Collision collision)
    {
        Stats collisionstat;
        collisionstat = collision.gameObject.GetComponent<Stats>();
        if (collisionstat.CurHp <= 0)
        {
            isOkay = true;
        }
    }
}
