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
        public GameObject HealthBar;
        Animator animator;
        bool check = true;
        RoundManager roundmanager;
        Turning tar;
        void Awake()
        {
            UnitStat = GetComponent<Stats>();
            animator = GetComponent<Animator>();
            animator.SetBool("isDie", false);
            animator.SetFloat("AtkSpd", (float)UnitStat.ATKspd);
        }
        void Start()
        {
            roundmanager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
        }
        void Update()
        {
            
        }
        void FixedUpdate()
        {
            HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;

            if (UnitStat.CurHp <= 0 && UnitStat.IsEnemy == false)
            {
                animator.SetBool("isDie", true);
                Destroy(ThisUnit, 0.5f);
            }
            else if ((UnitStat.CurHp <= 0 && UnitStat.IsEnemy == true) && UnitStat.status == true)
            {
                animator.SetBool("isDie", true);
                Destroy(ThisUnit, 0.5f);
                roundmanager.RemainEnemyCount -= 1;
                UnitStat.status = false;
               
            }
           
        }

        void OnCollisionEnter(Collision collision)
        {
        }
        void OnCollisionExit(Collision collision)
        {
        }
        private void OnCollisionStay(Collision other)
        {
            //Animator otherani;
            Stats otherstat;
            //otherani = other.gameObject.GetComponent<Animator>();
            otherstat = other.gameObject.GetComponent<Stats>();
            if (otherstat.CurHp <= 0)
            {
                animator.ResetTrigger("isAttack");
            }
            //if (otherani.GetBool("isCollision") && otherani.GetBool("isEnemy") && check)
            if (other.gameObject.tag != ThisUnit.gameObject.tag)
            {
                animator.SetTrigger("isAttack");
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && check)
                {
                    check = false;
                    otherstat.CurHp -= UnitStat.ATK;
                    StartCoroutine(WaitForIt(UnitStat.ATKspd));
                }
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

