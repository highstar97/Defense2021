using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    float span = 0.1f;
    float delta = 0;
    public int gold = 0;
    public GameObject text_gold;

    void AddGold(){
        int increase = 100;
        if(GameObject.Find("Buff Manager").GetComponent<BuffManager>().IsActive){
            increase *= 5;
        }
        gold += increase;
    }
    void Start(){
        text_gold = GameObject.Find("Text Gold");
    }
    void Update(){
        this.delta += Time.deltaTime;
        if(this.delta > this.span){
            this.delta = 0;
            AddGold();
        }
        text_gold.GetComponent<Text>().text = "Gold : " + gold.ToString();
    }
}
