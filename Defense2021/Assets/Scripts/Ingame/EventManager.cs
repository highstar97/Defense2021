using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] Text Situation;
    [SerializeField] GameObject Choice1;
    [SerializeField] GameObject Choice2;
    [SerializeField] GameObject Choice3;
    EventSituation[] EventSituations;
    void Start(){
        EventSituations = new EventSituation[3];
        for(int i=0; i<3; i++){
            EventSituations[i] = new EventSituation();
        }
        string[] options = new string[3] {"불의 정령에게 준다", "물의 정령에게 준다", "땅의 정령에게 준다"};
        EventSituations[0].MakeEvent("피닉스의 날개를 발견했습니다.", 3, options);
        options = new string[3] {"이딴게 신탁?", "알잘딱하자~", "응 아니야~"};
        EventSituations[1].MakeEvent("신탁을 들었습니다", 3, options);
        options = new string[1] {"OK"};
        EventSituations[2].MakeEvent("돈을 주웠습니다. 가지겠습니까?", 1, options);
    }
    public void EventOccur(){
        int x;
        do{
            x = Random.Range(0,3); // [0,3)
        }while(EventSituations[x].GetIsUsed());
        EventSituations[x].SetIsUsedTrue();
        Situation.text = EventSituations[x].GetSituation();
        if(EventSituations[x].GetNumofOptions() == 3){
            Choice1.SetActive(true);
            Choice2.SetActive(true);
            Choice3.SetActive(true);
            Choice1.transform.GetChild(0).GetComponent<Text>().text = EventSituations[x].GetOption()[0];
            Choice2.transform.GetChild(0).GetComponent<Text>().text = EventSituations[x].GetOption()[1];
            Choice3.transform.GetChild(0).GetComponent<Text>().text = EventSituations[x].GetOption()[2];
        }
        else if(EventSituations[x].GetNumofOptions() == 2){
            Choice1.SetActive(true);
            Choice2.SetActive(true);
            Choice3.SetActive(false);
            Choice1.transform.GetChild(0).GetComponent<Text>().text = EventSituations[x].GetOption()[0];
            Choice2.transform.GetChild(0).GetComponent<Text>().text = EventSituations[x].GetOption()[1];
        }
        else if(EventSituations[x].GetNumofOptions() == 1){
            Choice1.SetActive(false);
            Choice2.SetActive(true);
            Choice3.SetActive(false);
            Choice2.transform.GetChild(0).GetComponent<Text>().text = EventSituations[x].GetOption()[0];
        }
    }
}