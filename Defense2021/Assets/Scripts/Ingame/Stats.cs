using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float MaxHp;
    public float CurHp;
    public float ATK;
    public float ATKspd;
    public float Armor;
    public bool invincible=false;
    

    public void MaxRule()
    {
        if (MaxHp < CurHp && invincible == false)
            CurHp = MaxHp;
        else if (invincible == true)
        {
            CurHp = 10000000f;
        }

        if (Armor > 100)
            Armor = 100;
        else if (Armor < 0)
            Armor = 0;
    }

    void Start()
    {
       
        CurHp = MaxHp;
       
    }
    void Update() 
    {
        MaxRule();
       
    }
}
