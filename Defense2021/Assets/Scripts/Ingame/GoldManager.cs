using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    float span = 0.1f;
    float delta = 0;
    public float gold = 0;
    public GameObject text_gold;
    public int GoldColor = 0;
    public float Enemyprice = 100f;
    RelicsManager relicsmanager;


    public void AddGold(){
        float increase = 1;
        if (GameObject.Find("Buff Manager").GetComponent<BuffManager>().IsActive){
            increase *= 5;
        }
        if (relicsmanager.Goldset)
        {
            increase *= 2;
        }

        gold += increase;
    }
    void Start(){
        text_gold = GameObject.Find("Text Gold");
        relicsmanager = GameObject.Find("Relics Manager").GetComponent<RelicsManager>();
    }
    void Update(){
        this.delta += Time.deltaTime;
        if(this.delta > this.span){
            this.delta = 0;
            AddGold();
        }
        if(GoldColor==0)
            text_gold.GetComponent<Text>().text = "Gold : " + gold.ToString();
        else if (GoldColor > 0)
            text_gold.GetComponent<Text>().text = "Gold : " + "<color=#0000ff>" + gold.ToString()+ "</color>";
    }
}


