﻿using System.Collections;
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
        float anitime;
        bool check = true;
        void Awake()
        {
            UnitStat = GetComponent<Stats>();
            animator = GetComponent<Animator>();
            animator.SetBool("isDie", false);
            animator.SetBool("isCollision", false);
            animator.SetBool("isEnemy", false);
            
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
            /*
            if(collision.gameObject.tag != "Attack" && collision.gameObject.tag != ThisUnit.gameObject.tag)
            {
                animator.SetBool("isCollision", true);
                animator.SetBool("isEnemy", true);
            }
            else
            {
                Stats bulletatk;
                bulletatk = collision.gameObject.GetComponent<Stats>();
                UnitStat.CurHp -= bulletatk.ATK;
            }
            */
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
            if(otherani.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && check)
            {
                UnitStat.CurHp -= otherstat.ATK;
                HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;
                check = false;
                StartCoroutine(WaitForIt(otherstat.ATKspd));
            }

        }

        IEnumerator WaitForIt(float spd)
        {
            yield return new WaitForSeconds(spd);
            check = true;
        }
    }
}

