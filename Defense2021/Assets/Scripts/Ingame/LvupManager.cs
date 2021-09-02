using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvupManager : MonoBehaviour
{
    public Button ArcherUpgradeButton;
    public int ArcherLevel = 1;
    public int ArcherCost = 100;
    public Text ArcherCostinfo;
    public Text ArcherLevelinfo;
    public Text NowMoney;
    public GameObject warningpanel;
    GoldManager goldManager;

    public void ArcherUpgrade(){
        ArcherCostinfo.text = ArcherCost.ToString();
        ArcherUpgradeButton.onClick.AddListener(AddArcherCost);

    }
    public void AddArcherCost(){
        if (goldManager.gold >= ArcherCost){
            goldManager.gold -= ArcherCost;
            ArcherLevel += 1;
            ArcherCost += 150;
            ArcherCostinfo.text = ArcherCost.ToString();
            ArcherLevelinfo.text = "궁수 Lv. " + ArcherLevel.ToString();
        }
        else{
            OpenWarning();
        }
    }
    public void OpenWarning(){
        if(warningpanel.activeSelf == false){
            warningpanel.SetActive(true);
            Invoke("enablewarning",1f);
        }
        else{
            CancelInvoke("enablewarning");
            warningpanel.SetActive(true);
            Invoke("enablewarning",1f);
        }
    }
    public void enablewarning()
    {
        warningpanel.SetActive(false);
    }
    void Start()
    {
        goldManager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();
        ArcherLevelinfo.text = "궁수 Lv. " + ArcherLevel.ToString();
        ArcherCostinfo.text = ArcherCost.ToString();
        ArcherUpgradeButton.onClick.AddListener(AddArcherCost);
    }
    void Update(){
        NowMoney.GetComponent<Text>().text = "현재 돈 : " + goldManager.gold + " G";
    }
}
