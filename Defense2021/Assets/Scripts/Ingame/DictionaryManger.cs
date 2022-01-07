using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryManger : MonoBehaviour
{
    int IndexOn = 0;
    public GameObject Dictionary;
    public GameObject Tag_King;
    public GameObject Tag_OurUnit;
    public GameObject Tag_Devil;
    public GameObject Tag_EnemyUnit;
    public GameObject Tag_Relics;
    public GameObject BackGround_Dictioanry;
    public GameObject Dictionary_King;
    public GameObject Dictionary_OurUnit;
    public GameObject Dictionary_Devil;
    public GameObject Dictionary_EnemyUnit;
    public GameObject Dictionary_Relics;

    public void TurnOnKing(){
        TurnOff(IndexOn);

        Tag_King.GetComponent<Image>().color = new Color(255/255.0f,200/255.0f,0);
        Tag_King.transform.GetChild(0).GetComponent<Text>().color = new Color(255/255.0f,0,0);
        Dictionary_King.SetActive(true);
        IndexOn = 0;
    }

    public void TurnOnOurUnit(){
        TurnOff(IndexOn);

        Tag_OurUnit.GetComponent<Image>().color = new Color(255/255.0f,200/255.0f,0);
        Tag_OurUnit.transform.GetChild(0).GetComponent<Text>().color = new Color(255/255.0f,0,0);
        Dictionary_OurUnit.SetActive(true);
        IndexOn = 1;
    }
    
    public void TurnOnDevil(){
        TurnOff(IndexOn);

        Tag_Devil.GetComponent<Image>().color = new Color(255/255.0f,200/255.0f,0);
        Tag_Devil.transform.GetChild(0).GetComponent<Text>().color = new Color(255/255.0f,0,0);
        Dictionary_Devil.SetActive(true);
        IndexOn = 2;
    }

    public void TurnOnEnemyUnit(){
        TurnOff(IndexOn);

        Tag_EnemyUnit.GetComponent<Image>().color = new Color(255/255.0f,200/255.0f,0);
        Tag_EnemyUnit.transform.GetChild(0).GetComponent<Text>().color = new Color(255/255.0f,0,0);
        Dictionary_EnemyUnit.SetActive(true);
        IndexOn = 3;
    }

    public void TurnOnRelics(){
        TurnOff(IndexOn);

        Tag_Relics.GetComponent<Image>().color = new Color(255/255.0f,200/255.0f,0);
        Tag_Relics.transform.GetChild(0).GetComponent<Text>().color = new Color(255/255.0f,0,0);
        Dictionary_Relics.SetActive(true);
        IndexOn = 4;
    }

    public void TurnOff(int IndexOn){
        Dictionary.transform.GetChild(IndexOn+3).GetComponent<Image>().color = new Color(110/255.0f,135/255.0f,255/255.0f);
        Dictionary.transform.GetChild(IndexOn+3).transform.GetChild(0).GetComponent<Text>().color = new Color(0,0,0);
        BackGround_Dictioanry.transform.GetChild(IndexOn).gameObject.SetActive(false);
    }
}
