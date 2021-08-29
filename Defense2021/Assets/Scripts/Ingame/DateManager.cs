using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public int date = 1;
    public GameObject text_date;
    void Start(){
        text_date = GameObject.Find("Text Date");
        text_date.GetComponent<Text>().text = date.ToString() + " 일차...";
    }
    void Update(){
        //text_date.GetComponent<Text>().text = date.ToString() + " 일차...";
    }
}
