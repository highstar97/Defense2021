using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject DirectorMenu;
    void Update(){
        if(DirectorMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape)){
            DirectorMenu.SetActive(false);
        }
        else if(DirectorMenu.activeSelf == false && Input.GetKeyDown(KeyCode.Escape)){
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
