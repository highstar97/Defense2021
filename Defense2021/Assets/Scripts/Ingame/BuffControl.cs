using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class BuffControl : MonoBehaviour
{
    public Button KingSkillButton;
    public GameObject KingSkillobj;
    public Text Bufftext;
    ObjectSpawn obspawn;


    void addGold()
    {
    
        obspawn.gold += obspawn.addgold*5;

    }
    void subGold()
    {

        obspawn.gold -= obspawn.addgold * 5;

    }
    public void DisableKingSkill()
    {

        InvokeRepeating("subGold", 1, 0.1f);
        Bufftext.text = "";
        KingSkillobj.SetActive(true);
    }

    public void HumanKingSkill()
    {
        InvokeRepeating("addGold", 1, 0.1f);
        Bufftext.text = "HumanKing's Buff(Gold x5)";
        Invoke("DisableKingSkill", 5);
        KingSkillobj.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        obspawn = GameObject.Find("Canvas").GetComponent<ObjectSpawn>();
        KingSkillButton.onClick.AddListener(HumanKingSkill);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
