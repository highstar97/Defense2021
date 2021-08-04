using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private bool isOkay = false;
    public float entitytime, pos_x, pos_y, pos_z;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsDie", false);
        
    }
    void Update()
    {
        if (animator.GetBool("IsDie") == true)
        {
            Destroy(this, 1);
        }
        if (isOkay)
        {
            transform.Translate(new Vector3(pos_x, pos_y, pos_z) * entitytime);
        }
        
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        isOkay = false;
        animator.SetBool("Collider", true);
    }
    public void OnCollisionExit(Collision collision)
    {
        isOkay = true;
        animator.SetBool("Collider", false);
    }
    public void DieTest()
    {
        animator.SetBool("IsDie", true);
    }
    public void Move()
    {
        isOkay = true;
    }
}
