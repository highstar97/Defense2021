using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffManager : MonoBehaviour
{
    public bool IsActive = false;
    public Button KingSkillButton;
    public Text Bufftext;
    GoldManager goldmanager;

    public void HumanKingSkill()
    {
        Bufftext.text = "HumanKing's Buff(Gold x5)";
        KingSkillButton.transform.GetChild(0).GetComponent<Text>().text = "Active";
        IsActive = true;
        goldmanager.GoldColor += 1;
        Invoke("DisableHumanKingSkill",5f);
    }

    public void DisableHumanKingSkill(){
        goldmanager.GoldColor -= 1;
        IsActive = false;
        Bufftext.text = "";
        KingSkillButton.transform.GetChild(0).GetComponent<Text>().text = "King Skill";
    }

    void Start()
    {
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();


    }
}