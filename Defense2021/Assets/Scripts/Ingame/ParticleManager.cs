using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            this.transform.position = Input.mousePosition;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
