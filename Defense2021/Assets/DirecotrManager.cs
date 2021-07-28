using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirecotrManager : MonoBehaviour
{
    public GameObject DirectorMenu;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            DirectorMenu.SetActive(false);
        }
    }
    public void OpenDirector(){
        DirectorMenu.SetActive(true);
    }
}
