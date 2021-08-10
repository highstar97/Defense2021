using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject DirectorMenu;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && DirectorMenu.activeSelf == true){
            DirectorMenu.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && SettingMenu.activeSelf == true){
            SettingMenu.SetActive(false);
        }
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
}
