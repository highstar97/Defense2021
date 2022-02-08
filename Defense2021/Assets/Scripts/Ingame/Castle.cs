using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public float Max_HP = 1000;
    public float Current_HP = 800;

    public Text HP_Text;
    public Image HP_Bar;

    void Start()
    {
        Current_HP = Max_HP;
    }

    void Update()
    {
        UpdateHPBar();
    }

    void UpdateHPBar()
    {
        HP_Bar.fillAmount = Current_HP/Max_HP;
        HP_Text.text = string.Format("HP {0}/{1}", Current_HP,Max_HP);
    }

    bool IsAttacked()
    {
        GetDamage(1);
        return true;
    }

    float GetDamage(float damage)
    {
        Current_HP -= damage;
        if(Current_HP <= 0)
        {
            Result.IsWin = false;
            SceneManager.LoadScene("ResultScene");
        }
        return damage;
    }
}
