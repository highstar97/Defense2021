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
    
    void Update()
    {
        if(isOkay)
        {
            transform.Translate(new Vector3(pos_x, pos_y, pos_z) * entitytime);
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        isOkay = false;
    }
    void OnCollisionStay(Collision collision)
    {
        if(Vector3.Distance(transform.position, collision.transform.position) <= 0.5f)
            isOkay = false;
       
    }
    void OnCollsionExit(Collision collision)
    {
        Debug.Log("Collision End");
        isOkay = true;
    }
}
