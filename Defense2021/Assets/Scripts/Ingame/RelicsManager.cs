using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RelicsManager : MonoBehaviour
{
    public GameObject GoldRelic;
    public GameObject SwordRelic;
    public GameObject ShieldRelic;
    public GameObject AppleRelic;
    public GameObject BoomerangRelic;
    public GameObject TicketRelic;
    public GameObject BookRelic;
    public GameObject WandRelic;
    public GameObject RoseRelic;
    public GameObject BoxRelic;
    public GameObject SpearRelic;
    public GameObject LeafRelic;
    public GameObject ClockRelic;
    public GameObject ThrowingStarRelic;
    public GameObject StarRelicActiveAnimation;
    public GameObject DragonballRelic;
    public Button StarRelic;
    public Button PotionRelic;
    Stats stats;
    GoldManager goldmanager;
    LvupManager lvmanager;
    public bool Goldset = false;
    public bool Swordset = false;
    public bool Shieldset = false;
    public bool Appleset = false;
    public bool Boomerangset = false;
    public bool Ticketset = false;
    public bool Boxset = false;
    public bool Wandset = false;
    public bool Spearset = false;
    public bool Roseset = false;
    public bool Starset = false;
    public bool Bookset = false;
    public bool Leafset = false;
    public bool ThrowingStarset = false;
    public bool Dragonballset = false;
    public bool CanUse = true;
    public bool IsActive = false;
    public bool CanUse2 = true;
    public bool IsActive2 = false;
    public float tempHp;
    public Text temp1;
    public int round = 1;

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
    public void LeafRelicEnable()
    {
        if (LeafRelic.activeSelf == true && Leafset == false)
        {
            InvokeRepeating("Regeneration", 0, 1);
            stats.MaxHp *= 1.2f;
            stats.CurHp = stats.MaxHp;
            Leafset = true;
        }
        else if (LeafRelic.activeSelf == false && Leafset == true)
        {
            CancelInvoke("Regeneration");
            stats.MaxHp /= 1.2f;
            Leafset = false;
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
    public void WandRelicEnable()
    {
        if (WandRelic.activeSelf == true && Wandset == false)
        {
            if (stats.melee == false)
                stats.ATK *= 1.5f;
            Wandset = true;
        }
        else if (WandRelic.activeSelf == false && Wandset == true)
        {
            if (stats.melee == false)
                stats.ATK /= 1.5f;
            Wandset = false;
        }
    }
    public void SpearRelicEnable()
    {
        if (SpearRelic.activeSelf == true && Spearset == false)
        {
            if (stats.melee == true)
                stats.ATK *= 1.5f;
            Spearset = true;
        }
        else if (SpearRelic.activeSelf == false && Spearset == true)
        {
            if (stats.melee == true)
                stats.ATK /= 1.5f;
            Spearset = false;
        }
    }
    public void ShieldRelicEnable()
    {
        if (ShieldRelic.activeSelf == true && Shieldset == false)
        {
            stats.Armor += 50f;
            Shieldset = true;
        }
        else if (ShieldRelic.activeSelf == false && Shieldset == true)
        {
            stats.Armor -= 50f;
            Shieldset = false;
        }
    }
    public void RoseRelicEnable()
    {
        if (RoseRelic.activeSelf == true && Roseset == false)
        {
            stats.ATK += 5 * round;
            stats.Armor += 5f * round;
            stats.ATKspd *= (1.1f * round);
            Roseset = true;
        }
        else if (RoseRelic.activeSelf == false && Roseset == true)
        {
            stats.ATK -= 5 * round;
            stats.Armor -= 5f * round;
            stats.ATKspd /= (1.1f * round);
            Roseset = false;
        }
    }
    public void BoxRelicEnable()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(1, 6);//수정 필요

        if (BoxRelic.activeSelf == true && Boxset == false)
        {
            //System.Random rand = new System.Random();
            //int index = rand.Next(1, 6);
            switch (index)
            {
                case (1): stats.Armor += 50; temp1.text = "armor"; break;
                case (2): stats.ATK *= 1.5f; temp1.text = "atk"; break;
                case (3): goldmanager.GoldColor += 1; temp1.text = "gold"; break;
                case (4): stats.ATKspd *= 1.5f; temp1.text = "spd"; break;
                case (5): InvokeRepeating("Regeneration", 0, 1); temp1.text = "regen"; break;
            }
            Boxset = true;
        }
        else if (BoxRelic.activeSelf == false && Boxset == true)
        {
            switch (index)
            {
                case (1): stats.Armor -= 50; break;
                case (2): stats.ATK /= 1.5f; break;
                case (3): goldmanager.GoldColor -= 1; break;
                case (4): stats.ATKspd /= 1.5f; break;
                case (5): CancelInvoke("Regeneration"); break;
            }
            Boxset = false;
        }
    }


    public void SwordRelicEnable()
    {
        if (SwordRelic.activeSelf == true && Swordset == false)
        {
            stats.ATK *= 2;
            Swordset = true;
        }
        else if (SwordRelic.activeSelf == false && Swordset == true)
        {
            stats.ATK *= 0.5f;
            Swordset = false;
        }

    }
    public void BoomerangEnable()
    {
        if (BoomerangRelic.activeSelf == true && Boomerangset == false)
        {
            stats.ATKspd *= 1.5f;
            Boomerangset = true;
        }
        else if (BoomerangRelic.activeSelf == false && Boomerangset == true)
        {
            stats.ATKspd /= 1.5f;
            Boomerangset = false;
        }

    }
    public void BookEnable()
    {
        if (BookRelic.activeSelf == true && Bookset == false)
        {
            lvmanager.ArcherCost *= 0.8f;
            Bookset = true;
        }
        else if (BookRelic.activeSelf == false && Bookset == true)
        {
            lvmanager.ArcherCost /= 0.8f;
            Bookset = false;
        }

    }
    public void DragonballRelicEnable()
    {
        if (DragonballRelic.activeSelf == true && Dragonballset == false)
        {
            stats.MaxHp *= 1.2f;
            stats.CurHp = stats.MaxHp;
            Dragonballset = true;
        }
        else if (DragonballRelic.activeSelf == false && Dragonballset == true)
        {
            stats.MaxHp /= 1.2f;
            Dragonballset = false;
        }

    }
    public void ThrowingStarEnable()
    {
        if (ThrowingStarRelic.activeSelf == true && ThrowingStarset == false)
        {
            stats.ATKspd *= 1.2f;
            stats.ATK += 10f;
            ThrowingStarset = true;
        }
        else if (ThrowingStarRelic.activeSelf == false && ThrowingStarset == true)
        {
            stats.ATKspd /= 1.2f;
            stats.ATK -= 10f;
            ThrowingStarset = false;
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
        if (ClockRelic.activeSelf == true)
            StarRelic.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.2f * Time.deltaTime;
        else
            StarRelic.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.1f * Time.deltaTime;
    }
    public void PotionRelicActive()
    {


        if (CanUse2 && IsActive2 == false)
        {
            IsActive2 = true;
            stats.CurHp += 300;
            Invoke("DisablePotionRelic", 0f);
        }
    }

    public void DisablePotionRelic()
    {
        IsActive2 = false;
        CanUse2 = false;
        PotionRelic.transform.GetChild(0).gameObject.SetActive(true);
        InvokeRepeating("CoolTime2", Time.deltaTime, Time.deltaTime);
    }

    public void CoolTime2()
    {
        if (PotionRelic.transform.GetChild(0).GetComponent<Image>().fillAmount == 0)
        {
            PotionRelic.transform.GetChild(0).gameObject.SetActive(false);
            PotionRelic.transform.GetChild(0).GetComponent<Image>().fillAmount = 1;
            CancelInvoke("CoolTime2");
            CanUse2 = true;
        }
        if (ClockRelic.activeSelf == true)
        { PotionRelic.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.2f * Time.deltaTime; }
        else
            PotionRelic.transform.GetChild(0).GetComponent<Image>().fillAmount -= 0.1f * Time.deltaTime;
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
        //stats = GameObject.Find("OurTeam").GetComponent<Stats>();
        lvmanager = GameObject.Find("Lv up Manager").GetComponent<LvupManager>();

    }

    // Update is called once per frame
    void Update()
    {
        DragonballRelicEnable();
        //ThrowingStarEnable();
        GoldRelicEnable();
        SwordRelicEnable();
        AppleRelicEnable();
        BoomerangEnable();
        TicketRelicEnable();
        BookEnable();
        ThrowingStarEnable();
        BoxRelicEnable();
        SpearRelicEnable();
        WandRelicEnable();
        ShieldRelicEnable();
        LeafRelicEnable();
        RoseRelicEnable();
    }
}