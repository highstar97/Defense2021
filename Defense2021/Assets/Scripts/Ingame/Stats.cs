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

    public void MaxRule()
    {
        if (MaxHp < CurHp)
            CurHp = MaxHp;
        if (Armor >100||Armor<0)
            Armor = 100;
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
