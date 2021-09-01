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
    void Awake()
    {
        Debug.Log(thisunit.gameObject.tag);
    }
    void Update()
    {
        if(isOkay)
        {
            transform.Translate(new Vector3(pos_x, pos_y, pos_z) * entitytime);
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Attack")
        {
            if(thisunit.gameObject.tag != collision.gameObject.tag)
            {
                isOkay = false;
            }
            
        }
       
    }
    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision End");
        isOkay = true;
    }
}
