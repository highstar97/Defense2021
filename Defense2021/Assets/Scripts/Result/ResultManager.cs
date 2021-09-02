using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResultManager : MonoBehaviour
{
    public GameObject ResultWin;
    public GameObject ResultLose;

    void Start(){
        if(Result.IsWin){
            ResultWin.SetActive(true);
        }   
        else{
            ResultLose.SetActive(true);
        }     
    }
}
