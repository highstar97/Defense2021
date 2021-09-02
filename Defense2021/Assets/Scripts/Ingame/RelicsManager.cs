using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicsManager : MonoBehaviour
{

    public GameObject GoldRelic;
    GoldManager goldmanager;
    public bool Goldset = false;


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

    // Start is called before the first frame update
    void Start()
    {
        goldmanager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();


    }

    // Update is called once per frame
    void Update()
    {
        GoldRelicEnable();
    }
}
