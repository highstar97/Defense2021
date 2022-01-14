using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanKingBuff : BuffManager
{
    GoldManager goldmanager;

    public override void UseKingSkill()
    {
        base.UseKingSkill();
        if (CanUse && IsActive == false)
        {
            KingSkillActiveAnimation.SetActive(true);
            Bufftext.text = "인간군주의 스킬(Gold x5)";
            KingSkillButton.transform.GetChild(1).GetComponent<Text>().text = "활성화";
            IsActive = true;
            goldmanager.GoldColor += 1;
            Invoke("DisableKingSkill", 5f);
        }
    }

    public override void DisableKingSkill()
    {
        base.DisableKingSkill();
        goldmanager.GoldColor -= 1;
        KingSkillActiveAnimation.SetActive(false);
        IsActive = false;
        CanUse = false;
        Bufftext.text = "";
        KingSkillButton.transform.GetChild(0).gameObject.SetActive(true);
        KingSkillButton.transform.GetChild(1).GetComponent<Text>().text = "군주 스킬";
        InvokeRepeating("CoolTime", Time.deltaTime, Time.deltaTime);
    }

    void Start()
    {
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();
        KingSkillButton.onClick.AddListener(UseKingSkill);
    }
}
