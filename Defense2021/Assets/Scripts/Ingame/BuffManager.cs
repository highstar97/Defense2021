using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffManager : MonoBehaviour
{
    public bool CanUse = true;
    public bool IsActive = false;
    public Button KingSkillButton;
    public Text Bufftext;
    public GameObject KingSkillActiveAnimation;
    GoldManager goldmanager;
    public void HumanKingSkill()
    {
        if (CanUse && IsActive == false)
        {
            KingSkillActiveAnimation.SetActive(true);
            Bufftext.text = "HumanKing's Buff(Gold x5)";
            KingSkillButton.transform.GetChild(1).GetComponent<Text>().text = "Active";
            IsActive = true;
            goldmanager.GoldColor += 1;
            Invoke("DisableHumanKingSkill", 5f);
        }
    }

    public void DisableHumanKingSkill()
    {
        goldmanager.GoldColor -= 1;
        KingSkillActiveAnimation.SetActive(false);
        IsActive = false;
        CanUse = false;
        Bufftext.text = "";
        KingSkillButton.transform.GetChild(0).gameObject.SetActive(true);
        KingSkillButton.transform.GetChild(1).GetComponent<Text>().text = "King Skill";
        InvokeRepeating("CoolTime", Time.deltaTime, Time.deltaTime);
    }

    public void CoolTime()
    {
        if (KingSkillButton.transform.GetChild(0).GetComponent<Image>().fillAmount == 0)
        {
            KingSkillButton.transform.GetChild(0).gameObject.SetActive(false);
            KingSkillButton.transform.GetChild(0).GetComponent<Image>().fillAmount = 1;
            CancelInvoke("CoolTime");
            CanUse = true;
        }
        KingSkillButton.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.1f * Time.deltaTime;
    }
    void Start()
    {
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();


    }
}