using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Defense2021
{
    public class Animating : MonoBehaviour
    {
        public GameObject ThisUnit;
        Stats UnitStat;
        Animator animator;
        public GameObject HealthBar;
        //float anitime;
        float unitspd;
        bool check = true;
        void Awake()
        {
            
            UnitStat = GetComponent<Stats>();
            animator = GetComponent<Animator>();

            unitspd = (float)1 / UnitStat.ATKspd;

            animator.SetBool("isDie", false);
            animator.SetBool("isCollision", false);
            animator.SetBool("isEnemy", false);
            animator.SetFloat("Speed", UnitStat.ATKspd);
        }
        void Update()
        {
            
            if (UnitStat.CurHp <= 0)
            {
                animator.SetBool("isDie", true);
                Destroy(ThisUnit, 3.0f);
            }
            
        }
        void OnCollisionEnter(Collision collision)
        {
            animator.SetBool("isCollision", true);
            animator.SetBool("isEnemy", true);
            animator.SetTrigger("isAttack");
            Stats collisionstat = collision.gameObject.GetComponent<Stats>();
            if(collision.gameObject.tag != "Attack" && collision.gameObject.tag != ThisUnit.gameObject.tag)
            {
                animator.SetBool("isCollision", true);
                animator.SetBool("isEnemy", true);
            }
            else
            {
                UnitStat.CurHp -= collisionstat.ATK;
            }
            
        }
        void OnCollisionStay(Collision other)
        {
            Animator otherani;
            Stats otherstat;
            otherani = other.gameObject.GetComponent<Animator>();
            otherstat = other.gameObject.GetComponent<Stats>();
            /*if (otherani.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
            {
                otherani.ResetTrigger("isAttack");
                if (otherstat.CurHp <= 0)
                {
                    animator.SetBool("isCollision", false);
                    animator.SetBool("isEnemy", false);
                }
                UnitStat.CurHp -= otherstat.ATK;
                HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;
            }
            if(otherani.GetCurrentAnimatorStateInfo(0).IsName("New State"))
            {

            }*/
            if(other.gameObject.tag != "Attack" && other.gameObject.tag != ThisUnit.gameObject.tag)
            {
                if (otherani.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && check)
                {
                    UnitStat.CurHp -= otherstat.ATK;
                    HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;
                    check = false;
                    StartCoroutine(WaitForIt());
                }
            }
            

        }

        IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(unitspd);
            check = true;
        }
    }
}

