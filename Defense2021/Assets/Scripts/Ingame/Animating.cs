using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defense2021
{
    public class Animating : MonoBehaviour
    {
        public Stats temp;
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
            if (temp.CurHp <= 0)
            {
                animator.SetBool("isDie", true);
                Destroy(this);
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
            if(otherani.GetBool("isCollision") && otherani.GetBool("isEnemy")&&check)
            {
                check = false;
                temp.CurHp -= otherstat.ATK;
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

