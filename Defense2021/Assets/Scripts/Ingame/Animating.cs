using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense2021
{
    public class Animating : MonoBehaviour
    {
        public GameObject thisob;
        public Stats UnitStat;
        Animator animator;
        bool check = true;
        void Awake()
        {
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
                Destroy(thisob, 3.0f);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag != "Attack")
            {
                animator.SetBool("isCollision", true);
                animator.SetBool("isEnemy", true);
            }
            else if(collision.gameObject.tag != UnitStat.gameObject.tag)
            {
                Stats bulletatk;
                bulletatk = collision.gameObject.GetComponent<Stats>();
                UnitStat.CurHp -= bulletatk.ATK;
            }

        }
        void OnCollisionExit(Collision collision)
        {
            if(collision.gameObject.tag != "Attack")
            {
                animator.SetBool("isCollision", false);
                animator.SetBool("isEnemy", false);
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if(other.gameObject.tag == "Attack")
            {
                Destroy(other.gameObject);
            }
            else
            {
                Animator otherani;
                Stats otherstat;
                otherani = other.gameObject.GetComponent<Animator>();
                otherstat = other.gameObject.GetComponent<Stats>();
                if (otherani.GetBool("isCollision") && otherani.GetBool("isEnemy") && check)
                {
                    check = false;
                    UnitStat.CurHp -= otherstat.ATK;
                    StartCoroutine(WaitForIt(otherstat.ATKspd));
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

