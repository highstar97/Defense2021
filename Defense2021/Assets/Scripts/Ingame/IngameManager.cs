using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameManager : MonoBehaviour
{
    public GameObject BackGroundPanel;
    public GameObject DictionaryMenu;
    public GameObject SettingMenu;
    public GameObject DirectorMenu;
    public GameObject LvupMenu;
    public GameObject BuffStatus;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && DirectorMenu.activeSelf == true){
            CloseDirector();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && SettingMenu.activeSelf == true){
            CloseSetting();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && DictionaryMenu.activeSelf == true){
            CloseDictionary();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && LvupMenu.activeSelf == true){
            CloseLvup();
        }
    }
    public void OpenDictionary(){
        BackGroundPanel.SetActive(true);
        DictionaryMenu.SetActive(true);
    }
    public void CloseDictionary(){
        BackGroundPanel.SetActive(false);
        DictionaryMenu.SetActive(false);
    }
    public void OpenSetting(){
        BackGroundPanel.SetActive(true);
        SettingMenu.SetActive(true);
    }
    public void CloseSetting(){
        BackGroundPanel.SetActive(false);
        SettingMenu.SetActive(false);
    }
    public void OpenDirector(){
        DirectorMenu.SetActive(true);
    }
    public void CloseDirector(){
        DirectorMenu.SetActive(false);
    }
    public void OpenLvup(){
        BackGroundPanel.SetActive(true);
        LvupMenu.SetActive(true);
    }
    public void CloseLvup(){
        BackGroundPanel.SetActive(false);
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
