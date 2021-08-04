using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rigid;
    Animator anim;
    public int Dmg;
    public float rate;
    public Transform missilePos;
    public GameObject missile;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        
    }
  

    void Update()
    {
        Attack();

    }

    public void Attack()
    {
        StartCoroutine("Shot");
        Debug.Log("실행");
    }

    IEnumerable Shot()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject instantMissile = Instantiate(missile, missilePos.position, missilePos.rotation);
        Rigidbody missileRigid = instantMissile.GetComponent<Rigidbody>();
        missileRigid.velocity = missilePos.forward * 30;
        yield return new WaitForSeconds(0.5f);
    }


}
