using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSituation
{
    bool IsUsed = false;
    int NumofOptions;
    string title;
    string situation;
    string[] option;
    public EventSituation(){
        this.IsUsed = false;
        this.situation = "제발";
        this.NumofOptions = 3;
        string[] a = {"1","2","3"};
        this.option = a;
    }
    public EventSituation MakeEvent(string title, string Situation, int NumofOptions, string[] option){
        this.IsUsed = false;
        this.title = title;
        this.situation = Situation;
        this.NumofOptions = NumofOptions;
        this.option = option;
        return this;
    }
    public bool GetIsUsed(){
        return this.IsUsed;
    }
    public int GetNumofOptions(){
        return this.NumofOptions;
    }
    public string GetTitle(){
        return this.title;
    }
    public string GetSituation(){
        return this.situation;
    }
    public string[] GetOption(){
        return this.option;
    }
    public void SetIsUsedTrue(){
        this.IsUsed = true;
    }
}