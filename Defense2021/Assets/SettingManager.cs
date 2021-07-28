using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject DirectorMenu;

    void Update(){
        if(DirectorMenu.activeSelf == false && Input.GetKeyDown(KeyCode.Escape)){
            SettingMenu.SetActive(false);
        }
    }
    public void OpenSetting(){
        DirectorMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }
}
