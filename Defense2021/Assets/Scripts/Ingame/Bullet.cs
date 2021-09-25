using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Stats bulletstat;
    void Awake()
    {
        bulletstat = GetComponent<Stats>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(transform.right * (-1) * speed * Time.deltaTime);
        
    }

}
