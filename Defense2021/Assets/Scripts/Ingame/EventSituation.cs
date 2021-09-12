using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSituation
{
    bool IsUsed = false;
    int NumofOptions;
    string Situation;
    string[] option;
    public EventSituation(){
        this.IsUsed = false;
        this.Situation = "제발";
        this.NumofOptions = 3;
        string[] a = {"1","2","3"};
        this.option = a;
    }
    public EventSituation MakeEvent(string Situation, int NumofOptions, string[] option){
        this.IsUsed = false;
        this.Situation = Situation;
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
    public string GetSituation(){
        return this.Situation;
    }
    public string[] GetOption(){
        return this.option;
    }
    public void SetIsUsedTrue(){
        this.IsUsed = true;
    }
}