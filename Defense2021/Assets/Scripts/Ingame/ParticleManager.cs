using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManager : MonoBehaviour
{
    float time = 0.1f;
    GameObject Star;

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)){
                this.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                Star.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            //Star.GetComponent<Image>().color = new Color(1,1,1,time/3);
            GetComponent<ParticleSystem>().Play();
            /*while(time != 3){
                time += Time.deltaTime;
                Star.GetComponent<Image>().color = new Color(1,1,1,time/3);
            }
            while(time == 0){
                time -= Time.deltaTime;
                Star.GetComponent<Image>().color = new Color(1,1,1,time/3);
            }*/
        }
    }

    void Start(){
        Star = transform.GetChild(0).GetChild(0).gameObject;
    }
}
