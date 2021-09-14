using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Defense2021
{
    public class Animating : MonoBehaviour
    {
        public GameObject ThisUnit;
        private bool ctrg = true;
        Stats UnitStat;
        Animator animator;
        public GameObject HealthBar;
        Image barimg;
        bool check;
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

        }
        void OnCollisionStay(Collision other)
        {
            if(ctrg)
            {
                Animator otherani;
                Stats otherstat;
                otherani = other.gameObject.GetComponent<Animator>();
                otherstat = other.gameObject.GetComponent<Stats>();
                ctrg = false;
                check = false;
                if (otherstat.CurHp <= 0)
                {
                    animator.SetBool("isCollision", false);
                    animator.SetBool("isEnemy", false);
                }
                if (otherani.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
                {
                    Debug.Log("Hit");
                    
                    UnitStat.CurHp -= otherstat.ATK;
                    HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;
                    StartCoroutine(WaitForIt(otherstat.ATKspd));
                   
                    ctrg = true;
                }
                
                

                Debug.Log("Collsion");
            }
        }
        IEnumerator WaitForIt(float speed)
        {
            float spd = (float)1 / speed;
            yield return new WaitForSeconds(spd);
            check = true;
        }
    }
}

