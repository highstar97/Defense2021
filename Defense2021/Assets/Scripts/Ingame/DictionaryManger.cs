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
    public GameObject BackGround_Dictioanry;
    public GameObject Dictionary_King;
    public GameObject Dictionary_OurUnit;

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
    
    public void TurnOff(int IndexOn){
        Dictionary.transform.GetChild(IndexOn+3).GetComponent<Image>().color = new Color(110/255.0f,135/255.0f,255/255.0f);
        Dictionary.transform.GetChild(IndexOn+3).transform.GetChild(0).GetComponent<Text>().color = new Color(0,0,0);
        BackGround_Dictioanry.transform.GetChild(IndexOn).gameObject.SetActive(false);
    }
}
