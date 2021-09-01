using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
                this.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            GetComponent<ParticleSystem>().Play();
        }
    }
}
