using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    Stats st;
    public Text HP_Text;
    public Image HP_Bar;

    void Awake()
    {
        st = gameObject.GetComponent<Stats>();
    }
    void Start()
    {
    }

    void Update()
    {
        UpdateHPBar();
    }

    void UpdateHPBar()
    {
        HP_Bar.fillAmount = st.CurHp/st.MaxHp;
        HP_Text.text = string.Format("HP {0}/{1}", st.CurHp,st.MaxHp);
        if (st.CurHp <= 0)
        {
            Result.IsWin = false;
            SceneManager.LoadScene("ResultScene");
        }
    }
}
