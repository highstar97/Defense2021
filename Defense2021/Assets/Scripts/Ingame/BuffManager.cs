using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffManager : MonoBehaviour
{
    public bool IsActive = false;
    public Button KingSkillButton;
    public Text Bufftext;

    public void HumanKingSkill()
    {
        Bufftext.text = "HumanKing's Buff(Gold x5)";
        KingSkillButton.transform.GetChild(0).GetComponent<Text>().text = "Active";
        IsActive = true;
        Invoke("DisableHumanKingSkill",5f);
    }

    public void DisableHumanKingSkill(){
        IsActive = false;
        Bufftext.text = "";
        KingSkillButton.transform.GetChild(0).GetComponent<Text>().text = "King Skill";
    }
}