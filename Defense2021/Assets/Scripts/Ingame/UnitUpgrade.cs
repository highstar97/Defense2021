using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUpgrade : MonoBehaviour
{
    public Button ArcherUpgradeButton;
    public int ArcherCost = 100;
    public Text ArcherCostinfo;
    public int ArcherLevel = 1;
    public Text ArcherLevelinfo;
    public GameObject warningpanel;
    ObjectSpawn obspawn;


    public void ArcherUpgrade()
    {
        ArcherCostinfo.text = ArcherCost.ToString();
        ArcherUpgradeButton.onClick.AddListener(AddArcherCost);

    }
    public void AddArcherCost() 
    {
        if (obspawn.gold >= ArcherCost)
        {
            
            obspawn.gold -= ArcherCost;
            ArcherLevel += 1;
            ArcherCost += 150;
            ArcherCostinfo.text = ArcherCost.ToString();
            ArcherLevelinfo.text = "궁수 Lv. " + ArcherLevel.ToString();
        }
        else
        {
            warningpanel.SetActive(true);
            Invoke("enablewarning", 1);
        }

    }
    public void enablewarning()
    {
        warningpanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        obspawn = GameObject.Find("Canvas").GetComponent<ObjectSpawn>();
        ArcherLevelinfo.text = "궁수 Lv. " + ArcherLevel.ToString();
        ArcherCostinfo.text = ArcherCost.ToString();
        ArcherUpgradeButton.onClick.AddListener(AddArcherCost);

    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
