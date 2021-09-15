using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicsManager : MonoBehaviour
{

    public GameObject GoldRelic;
    public GameObject SwordRelic;
    public GameObject ShieldRelic;
    public GameObject AppleRelic;
    public GameObject BoomerangRelic;
    public GameObject TicketRelic;
    public GameObject StarRelicActiveAnimation;
    public Button StarRelic;
    Stats stats;
    GoldManager goldmanager;
    public bool Goldset = false;
    public bool Swordset = false;
    public bool Shieldset = false;
    public bool Appleset = false;
    public bool Boomerangset = false;
    public bool Ticketset = false;
    public bool Starset = false;
    public bool CanUse = true;
    public bool IsActive = false;
    public float tempHp;
  
    public void Regeneration()
    {
        stats.CurHp += 5;

    }
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
            InvokeRepeating("Regeneration", 0, 1);
            Appleset = true;
        }
        else if (AppleRelic.activeSelf == false && Appleset == true)
        {
            CancelInvoke("Regeneration");
            Appleset = false;
        }
    }
    public void ShieldRelicEnable()
    {
        if (ShieldRelic.activeSelf == true && Shieldset == false)
        {
            stats.Armor += 50;
            Shieldset = true;
        }
        else if (ShieldRelic.activeSelf == false && Shieldset == true)
        {
            stats.Armor -= 50;
            Shieldset = false;
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
    public void BoomerangEnable()
    {
        if (BoomerangRelic.activeSelf == true && Boomerangset == false)
        {
            stats.ATKspd*=1.2f;
            Boomerangset = true;
        }
        else if (BoomerangRelic.activeSelf == false && Boomerangset == true)
        {
            stats.ATKspd /= 1.2f;
            Boomerangset = false;
        }

    }
    public void StarRelicActive() 
    {
       
   
        if (CanUse && IsActive == false)
        {
            StarRelicActiveAnimation.SetActive(true);
            IsActive = true;
            tempHp = stats.CurHp;
            stats.invincible = true;
            Invoke("DisableStarRelic", 5f);
        }
    }

    public void DisableStarRelic()
    {
        stats.invincible = false;
        stats.CurHp = tempHp;
        StarRelicActiveAnimation.SetActive(false);
        IsActive = false;
        CanUse = false;
        StarRelic.transform.GetChild(0).gameObject.SetActive(true);
        InvokeRepeating("CoolTime", Time.deltaTime, Time.deltaTime);
    }

    public void CoolTime()
    {
        if (StarRelic.transform.GetChild(0).GetComponent<Image>().fillAmount == 0)
        {
            StarRelic.transform.GetChild(0).gameObject.SetActive(false);
            StarRelic.transform.GetChild(0).GetComponent<Image>().fillAmount = 1;
            CancelInvoke("CoolTime");
            CanUse = true;
        }
        StarRelic.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.1f * Time.deltaTime;
    }

    public void TicketRelicEnable()
    {
        if (TicketRelic.activeSelf == true && Ticketset == false)
        {
            goldmanager.Enemyprice *= 0.8f;
            Ticketset = true;
        }
        else if (TicketRelic.activeSelf == false && Ticketset == true)
        {
            goldmanager.Enemyprice /= 0.8f;
            Ticketset = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();
        stats = GameObject.Find("OurTeam").GetComponent<Stats>();
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();

    }

    // Update is called once per frame
    void Update()
    {
        GoldRelicEnable();
        SwordRelicEnable();
        AppleRelicEnable();
        BoomerangEnable();
        TicketRelicEnable();
    }
}
