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
            animator.SetBool("isCollision", false);
            animator.SetBool("isEnemy", false);
        }

        void Update()
        {
            if (UnitStat.CurHp <= 0)
            {
                animator.SetBool("isDie", true);
                Destroy(ThisUnit, 3.0f);
                animator.SetBool("isCollision", false);
                animator.SetBool("isEnemy", false);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            animator.SetBool("isCollision", true);
            animator.SetBool("isEnemy", true);
        }
        void OnCollisionExit(Collision collision)
        {
            animator.SetBool("isCollision", false);
            animator.SetBool("isEnemy", false);
        }
        private void OnCollisionStay(Collision other)
        {
            Animator otherani;
            Stats otherstat;
            otherani = other.gameObject.GetComponent<Animator>();
            otherstat = other.gameObject.GetComponent<Stats>();
            
            //if (otherani.GetBool("isCollision") && otherani.GetBool("isEnemy") && check)
            if(Vector3.Distance(ThisUnit.transform.position, other.transform.position) <= 0.5f && check)
            {
                animator.SetBool("isCollision", true);
                animator.SetBool("isEnemy", true);
                check = false;
                UnitStat.CurHp -= otherstat.ATK;
                HealthBar.GetComponent<Image>().fillAmount = UnitStat.CurHp / UnitStat.MaxHp;
                StartCoroutine(WaitForIt(otherstat.ATKspd));
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

