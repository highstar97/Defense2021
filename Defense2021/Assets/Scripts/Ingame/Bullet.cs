using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    void Update()
    {
        transform.Translate(Vector3.forward * 1f);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "OurTeam")
        {
            Destroy(gameObject);
        }
    }
}
