using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicsManager : MonoBehaviour
{

    public GameObject GoldRelic;
    public GameObject SwordRelic;
    public GameObject AppleRelic;
    Stats stats;
    GoldManager goldmanager;
    public bool Goldset = false;
    public bool Swordset = false;
    public bool Appleset = false;


    public void GoldRelicEnable()
    {
        if (GoldRelic.activeSelf == true && Goldset == false)
        {
            goldmanager.GoldColor += 1;
            Goldset = true;
        }
        else if (GoldRelic.activeSelf == false && Goldset == true)
        {
            goldmanager.GoldColor -= 1;
            Goldset = false;
        }
    }
    public void AppleRelicEnable()
    {
        if (AppleRelic.activeSelf == true && Appleset == false)
        {

            
        }
        else if (AppleRelic.activeSelf == false && Appleset == true)
        {
           
        }
    }

    public void SwordRelicEnable() 
    {
        if (SwordRelic.activeSelf == true && Swordset ==false)
        {
            stats.ATK *= 2;
            Swordset = true;
        }
        else if (SwordRelic.activeSelf == false && Swordset == true)
        {
            stats.ATK *=0.5f;
            Swordset = false;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();
        stats = GameObject.Find("Enemy").GetComponent<Stats>();


    }

    // Update is called once per frame
    void Update()
    {
        GoldRelicEnable();
        SwordRelicEnable();
    }
}
