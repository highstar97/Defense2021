using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : MonoBehaviour
{
    public GameObject DictionaryMenu;
    public GameObject SettingMenu;
    public GameObject DirectorMenu;
    public GameObject LvupMenu;
    public GameObject BuffStatus;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && DirectorMenu.activeSelf == true){
            DirectorMenu.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && SettingMenu.activeSelf == true){
            SettingMenu.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && DictionaryMenu.activeSelf == true){
            DictionaryMenu.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && LvupMenu.activeSelf == true){
            LvupMenu.SetActive(false);
        }
    }
    public void OpenDictionary(){
        DictionaryMenu.SetActive(true);
    }
    public void CloseDictionary(){
        DictionaryMenu.SetActive(false);
    }
    public void OpenSetting(){
        SettingMenu.SetActive(true);
    }
    public void CloseSetting(){
        SettingMenu.SetActive(false);
    }
    public void OpenDirector(){
        DirectorMenu.SetActive(true);
    }
    public void CloseDirector(){
        DirectorMenu.SetActive(false);
    }
    public void OpenLvup(){
        LvupMenu.SetActive(true);
    }
    public void CloseLvup(){
        LvupMenu.SetActive(false);
    }
    public void PushBuffButton(){
        if(BuffStatus.activeSelf == false){
            BuffStatus.SetActive(true);
        }
        else if(BuffStatus.activeSelf == true){
            BuffStatus.SetActive(false);
        }
    }
}
