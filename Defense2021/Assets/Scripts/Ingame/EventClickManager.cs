using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventClickManager : MonoBehaviour
{
    float distance;
    Vector3 Base;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject Select;
    public GameObject ChoiceActiveAnimation;

    public void ClickChoice1(){
        ChoiceActiveAnimation.transform.position = new Vector3(Base.x,Base.y,Base.z);
        ChoiceActiveAnimation.SetActive(true);
    }
    public void ClickChoice2(){
        ChoiceActiveAnimation.transform.position = new Vector3(Base.x,Base.y+distance,Base.z);
        ChoiceActiveAnimation.SetActive(true);
    }
    public void ClickChoice3(){
        ChoiceActiveAnimation.transform.position = new Vector3(Base.x,Base.y+2*distance,Base.z);
        ChoiceActiveAnimation.SetActive(true);
    }
    public void ClickSelect(){
        ChoiceActiveAnimation.SetActive(false);
    }
    void Start(){
        distance = Choice2.transform.position.y - Choice1.transform.position.y;
        Base = ChoiceActiveAnimation.transform.position;
    }
}
