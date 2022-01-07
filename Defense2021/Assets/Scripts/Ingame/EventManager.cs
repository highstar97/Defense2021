using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    int count = 0;
    int NumofEvent = 12;
    [SerializeField] Text Title;
    [SerializeField] Text Situation;
    [SerializeField] GameObject Choice1;
    [SerializeField] GameObject Choice2;
    [SerializeField] GameObject Choice3;
    EventSituation[] EventSituations;
    void Start(){
        EventSituations = new EventSituation[NumofEvent];
        for(int i=0; i<NumofEvent; i++){
            EventSituations[i] = new EventSituation();
        }
        string[] options = new string[3] {"대중들을 위해 창고 있는 식량을 모두 푼다.", "병사들의 식량도 부족하기 때문에 어쩔 없지만 나누어주지 못한다.", "마법사의 마법으로 자연의 순리를 거스르고 비를 내리게 한다. ( 마법사 3턴간 사용 금지 )"};
        EventSituations[0].MakeEvent("가뭄 발생", "가뭄이 발생했다. 성의 온도는 50도를 웃돌고 화재가 끊이지 않고 성 안의 나무는 모두 말라 바렸다. 시민들은 식량난에 허덕이며 굶어죽는 시민들이 발생했다. 창고에는 소량의 식량만이 남아있다. 왕인 당신은 어떤 선택을 할 것인가?", 3, options);
        options = new string[3] {"K-방역을 도입해서 거리두기 시킨다.", "자연적으로 면역 체계가 생기도록 둔다.", "사제가 혹사당하더라도 많은 시민들을 살리는 것이 우선이다. ( 사제 3턴간 사용 금지 )"};
        EventSituations[1].MakeEvent("역병 발생", "역병이 발생했다. 성 안은 죽은 쥐의 시체가 들끓었고 시민들 역시 고통에 시달리고 있다. 왕인 당신은 어떤 선택을 할 것인가?", 3, options);
        options = new string[3] {"대의를 위해 하나쯤이야...", "사용하지 말고 없애자", "마법을 재해석해 현대식으로 바꾸어본다.\n( 마법사 Lv 5 필요 )"};
        EventSituations[2].MakeEvent("고대의 마법서 발견", "한 병사가 주변을 탐색하던 도중 고대의 마법서를 발견했다. 마법서에 적힌 마법은 고대 다크엘프문명의 마법이었다. 다크엘프문명의 마법은 강력하기로 유명했지만 시전자의 생명을 갉아먹어 금지되 사라진 마법이었다. 악마를 물리치기 위해 당신은 이 마법을 사용할 것인가?", 3, options);
        options = new string[2] {"돈을 투자하고 탐험", "탐험하지 않는다."};
        EventSituations[3].MakeEvent("동굴 탐험1", "성 지하 공사를 하던 도중 동굴을 발견했다. 동굴을 탐험하는데는 비용이 들지만 무엇이 나올지는 모릅니다. 왕인 당신은 어떤 선택을 하시겠습니까?",2,options);
        options = new string[2] {"돈을 투자하고 탐험", "탐험하지 않는다."};
        EventSituations[4].MakeEvent("동굴 탐험2", "성 지하 공사를 하던 도중 동굴을 발견했다. 동굴을 탐험하는데는 비용이 들지만 무엇이 나올지는 모릅니다. 왕인 당신은 어떤 선택을 하시겠습니까?",2,options);
        options = new string[2] {"돈을 투자하고 연구를 진행", "연구를 막는다"};
        EventSituations[5].MakeEvent("유적 발견1", "내부 공사를 하던 도중 심상치 않은 장소를 발견했다. 고고학자들은 이곳을 더 연구하면 유적이 나올 것 같다고 한다. 하지만 전쟁 중인 지금 고고학에 투자를 해야할까? 신하들의 의견도 엇갈린다. 신하들과 고고학자들은 당신의 선택을 기다린다. 왕인 당신의 선택은 무엇입니까?",2,options);
        options = new string[2] {"돈을 투자하고 연구를 진행", "연구를 막는다"};
        EventSituations[6].MakeEvent("유적 발견2", "내부 공사를 하던 도중 심상치 않은 장소를 발견했다. 고고학자들은 이곳을 더 연구하면 유적이 나올 것 같다고 한다. 하지만 전쟁 중인 지금 고고학에 투자를 해야할까? 신하들의 의견도 엇갈린다. 신하들과 고고학자들은 당신의 선택을 기다린다. 왕인 당신의 선택은 무엇입니까?",2,options);
        options = new string[3] {"사제를 통해 듣는다. ( 사제 5턴간 사용 금지 )", "일반인을 통해 듣는다.", "신탁을 무시한다"};
        EventSituations[7].MakeEvent("신탁", "신전에서 신탁이 내려왔습니다. 신탁은 5일간 진행됩니다. 신탁을 들으시겠습니까?",3,options);
        options = new string[2] {"감사히 축복을 받는다", "뭔가 찜찜하다... 받지 않는다"};
        EventSituations[8].MakeEvent("대천사 강림", "대천사 '가브리엘'이 강림했다. 천사들을 대신해 싸우고 있는 영웅들을 축복해주기 위해서 내려왔다는데...",2,options);
        options = new string[2] {"궁수에게 준다", "이런건 왕인 내꺼지~"};
        EventSituations[9].MakeEvent("엘프여왕의 활", "악마들을 쓰러트리고 사체를 정리하던 중 전리품을 발견했습니다. 발견한 전리품은 '엘프여왕의 활'. 이 전리품은 어떻게 사용하시겠습니까?",2,options);
        options = new string[3] {"불의 전령에게 준다", "얼음의 정령에게 준다", "땅의 정령에게 준다"};
        EventSituations[10].MakeEvent("피닉스의 깃털", "악마들을 쓰러트리고 사체를 정리하던 중 전리품을 발견했습니다. 발견한 전리품은 '피닉스의 깃털'. 이 전리품은 어떻게 사용하시겠습니까?",3,options);
        options = new string[2] {"분명 있다... 수색!", "나는 믿는다 고로 넘어간다"};
        EventSituations[11].MakeEvent("내통자", "성 안에 악마와 결탁한 배신자가 있다는 소문이 들려온다. 왕인 당신은 소문을 어떻게 처리하시겠습니까?",2,options);
    }
    public void EventOccur(){
        int x;
        if(count == NumofEvent)
        {
            print("All Event Used!");
            return;
        }
        do{
            x = Random.Range(0,NumofEvent); // [0,NumofEvent)
        }while(EventSituations[x].GetIsUsed());
        EventSituations[x].SetIsUsedTrue();
        Title.text = EventSituations[x].GetTitle();
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
        count++;
    }
}