using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float MaxHp;
    public float CurHp;
    public float ATK;
    public float ATKspd;
    public bool IsEnemy;
    public bool status;
    void Start()
    {
        CurHp = MaxHp;
    }
}
