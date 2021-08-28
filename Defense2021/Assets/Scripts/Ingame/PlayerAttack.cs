using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;

    private RaycastHit hit;
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 8;    
    }

    // Update is called once per frame
    void Update()
    {
        if(curtime <= 0)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }
            curtime = cooltime;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
        }
        curtime -= Time.deltaTime;
    }
}
