using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;
    RaycastHit hitinfo;

    void Update()
    {
        
        Debug.DrawRay(FirePos.position, FirePos.forward * 300.0f, Color.green);

        if (Physics.Raycast(FirePos.position, FirePos.forward * 300.0f, out hitinfo))
        {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }

        StartCoroutine(WaitForIt());
       
    }
   
    IEnumerator WaitForIt()
    {
        
        yield return new WaitForSeconds(2.0f);
    }
}
