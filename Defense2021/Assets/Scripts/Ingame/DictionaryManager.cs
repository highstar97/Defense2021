using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryManager : MonoBehaviour
{
    public GameObject DictionaryMenu;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            DictionaryMenu.SetActive(false);
        }
    }
    public void OpenDictionary(){
        DictionaryMenu.SetActive(true);
    }
}
