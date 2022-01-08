using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffManager : MonoBehaviour
{
    protected bool CanUse = true;
    public bool IsActive = false;
    private string King = "Human";    
    public Button KingSkillButton;
    public Text Bufftext;
    public GameObject KingSkillActiveAnimation;

    public virtual void UseKingSkill()
    {

    }

    public virtual void DisableKingSkill()
    {
        
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
    private void EnableKingScript()
    {
        if(King == "Human")
        {
            this.GetComponent<HumanKingBuff>().enabled = true;
        }
        else if(King == "Elf")
        {
            ;
        }   
    }

    void Start()
    {
        EnableKingScript();
    }
}