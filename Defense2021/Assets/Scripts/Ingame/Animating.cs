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
        void Awake()
        {
            UnitStat = GetComponent<Stats>();
            animator = GetComponent<Animator>();
            animator.SetBool("isDie", false);
            animator.SetFloat("AtkSpd", (float)UnitStat.ATKspd);
        }

        void FixedUpdate()
        {
            HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;

            if (UnitStat.CurHp <= 0)
            {
                animator.SetBool("isDie", true);
                Destroy(ThisUnit, 3.0f);
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
                return;
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

