using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public Stats spdstat;
    private float curtime;
    private RaycastHit hit;
    private int layerMask;
    Vector3 pos2;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 8;
        pos2 = transform.position + new Vector3(0, 10f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(curtime <= 0)
        {
            Debug.Log("Check2");
            if (Physics.Raycast(pos2, transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("check");
                Instantiate(bullet, pos.position, transform.rotation);
            }
            curtime = spdstat.ATKspd;
        }
        else
        {
            Debug.DrawRay(pos2, transform.forward * 1000f, Color.red);
        }
        curtime -= Time.deltaTime;
    }
}
