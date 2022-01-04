using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState   // 게임 스테이트를 적용하기 위한 부분
{
    Ready,
    Begin,
    End,
}

public class GameMng : MonoBehaviour
{
    // 게임의 전반적인 부분을 담당하는 스크립트 

    static public GameMng instance;     // GameMng 즉 이 스크립트에서 만든 함수들을 다른 스크립트에서 사용할수 있도록 함
    public GameObject[] stages;         // 스테이지가 바뀔 수 있도록 스테이지들을 넣어주는 배열
    int curStage = 0;                   // 배열 내의 스테이지는 0부터 시작함

    public Text stateText;              // 이미지를 인식해달라는 텍스트를 보여주는 UI
    public Text info;                   // 텍스트 색을 다르게해서 정보를 전달하기 위한 UI

    public bool check = true;           // 
    public int i = 0;

    // 사용하려고 하는 게임 오브젝트를 모두 선언함
    public GameObject hero;
    public GameObject car;
    public GameObject car2;
    public GameObject hp;
    public GameObject hp1;
    public GameObject hp_text;
    public GameObject zombie;
    public GameObject bosszombie;
    public GameObject zbhp;
    public GameObject zbhp1;
    public GameObject zbhp_text;
    public GameObject replayBtn;
    public GameObject diereplayBtn;


    public GameState gameState = GameState.Ready;       // 현재 게임 스테이트를 Ready로 고정해줌

    AudioSource ads;        // Audio를 사용하기 위해서 선엄함

    void Start()
    {
        if(instance == null)        // 만약 instance가 없다면 현재 this임을 알려주는 과정
        {
            instance = this;
        }

        ads = GetComponent<AudioSource>();      // audioSource를 사용하기 위해 불러옴

        Invoke("Stage1", 20.0f);        // Stage1이 시작되고 나서 20초가 지나면 메시지를 출력하도록 함

        // 처음에 시작할 때 setActive가 false가 되어야 하는 부분들을 선언해줌
        hero.SetActive(false);
        car.SetActive(false);
        car2.SetActive(false);
        hp1.SetActive(false);
        hp.SetActive(false);
        hp_text.SetActive(false);
        zbhp1.SetActive(false);
        zbhp.SetActive(false);
        zbhp_text.SetActive(false);
        replayBtn.SetActive(false);
        diereplayBtn.SetActive(false);
    }

    void Update()
    {
        if (Health.health <= 0)     // 플레이어의 체력이 0과 같거나 작아지면 
        {
            gameState = GameState.End;  // stage를 begin에서 end로 바꿔주고

            // 게임이 멈추기 위해서 해당 스테이지에서 setActive(true)로 되어있던 것들 중에서 골라서 (false)로 바꿔줌
            zombie.SetActive(false);
            hero.SetActive(false);
            car.SetActive(false);
            car2.SetActive(false);
            hp1.SetActive(false);
            hp.SetActive(false);
            hp_text.SetActive(false);
            zbhp1.SetActive(false);
            zbhp.SetActive(false);
            zbhp_text.SetActive(false);
            replayBtn.SetActive(false);
            diereplayBtn.SetActive(true);
            bosszombie.SetActive(false);
        }
        else if (ZBHealth.zbhealth <= 0)        // 좀비보스의 체력이 0과 같거나 작아지면
        {
            gameState = GameState.End;      // stage를 begin에서 end로 바꿔주고

            // 게임이 멈추기 위해서 해당 스테이지에서 setActive(true)로 되어있던 것들 중에서 골라서 (false)로 바꿔줌
            zombie.SetActive(false);
            hero.SetActive(false);
            car.SetActive(false);
            car2.SetActive(false);
            hp1.SetActive(false);
            hp.SetActive(false);
            hp_text.SetActive(false);
            zbhp1.SetActive(false);
            zbhp.SetActive(false);
            zbhp_text.SetActive(false);
            replayBtn.SetActive(false);
            replayBtn.SetActive(true);
            bosszombie.SetActive(false);
        }
    }

    public void GoNextStage()       // 다음스테이지로 넘어가도록 하는 함수
    {
        StartCoroutine(ChangeStage());      // Coroutine을 이용해서 스테이지를 바꿔준다
    }

    public void PopupMsg(string msg, int time)      // 정보를 제공하기 위한 popupMessage 부분
    {
        StartCoroutine(ShowMsg(msg, time));         // 조금 시간 지연을 주는 부분
    }

    IEnumerator ShowMsg(string msg,int time)        // 팝업에서 메세지를 보이도록 도와주는 부분 (흰색 텍스트)
    {
        stateText.text = msg;                       // 매개변수로 들어오는 텍스트를 msg로 받아서 넣어주기
        yield return new WaitForSeconds(time);      // 지정한 시간동안 텍스트를 보여주도록 하는 부분    
        stateText.text = "";                        // ShowMsg를 할 때 다시 원래대로 돌려놓음
    }

    public void PopupMsg1(string msg, int time)     // 정보를 제공하기 위한 popupMessage 부분
    {
        StartCoroutine(ShowMsg1(msg, time));        // 조금 시간 지연을 주는 부분
    }

    IEnumerator ShowMsg1(string msg, int time)      // 팝업에서 메세지를 보이도록 도와주는 부분 (빨간색 텍스트)
    {
        info.text = msg;                            // 매개변수로 들어오는 텍스트를 msg로 받아서 넣어주기
        yield return new WaitForSeconds(time);      // 지정한 시간동안 텍스트를 보여주도록 하는 부분
        info.text = "";                             // ShowMsg를 할 때 다시 원래대로 돌려놓음
    }

    void Stage1()       // Stage 1에서 미션을 전달하는 부분
    {
        PopupMsg(" 미션1 : 경찰관을 찾아가세요!", 8);      // 메시지 출력
    }

    public void DestroyClone()          // instantiate 해서 생성된 좀비 클론들이 다음 스테이지로 넘어갔을 때는 존재하지 않도록 삭제해주는 함수
    {
        GameObject[] clone = GameObject.FindGameObjectsWithTag("Zombie");       // 좀비 프리팹으로 부터 생성된 클론들을 배열에 차례대로 넣어줌

        for (int i = 0; i < clone.Length; i++)      // 클론이 생성된 개수를 바탕으로 좀비 클론을 삭제함
        {
            Destroy(clone[i]);  // 좀비 클론들을 차례대로 삭제해주는 부분
        }
    }

    public void OnDetected()         // 이미지를 카메라가 인식한 경우에
    {
        if(gameState == GameState.Ready)        // ready 상태인 경우에 
        {
            gameState = GameState.Begin;        // state를 begin으로 바꿔주고
            hero.SetActive(true);               // 각각의 gameObject들이 카메라에 이미지가 인식되었을 때 실행될 수 있도록 함
            car.SetActive(true);
            car2.SetActive(true);
            hp.SetActive(true);
            hp_text.SetActive(true);
            hp1.SetActive(true);
            zombie.SetActive(true);
            PopupMsg("상하좌우로 캐릭터를 움직여보세요!        " +
                "        스페이스바로 점프도 해보세요!", 7);     // 실행된 후에 popupMessage를 통해 정보를 제공함
        }
    }

    public void OnClickReplay()     // replay 버튼을 누르면 가장 처음으로 돌아가도록 하는 버튼
    {
        SceneManager.LoadScene("Game");     // replay버튼 누르면 Game 씬을 다시 보여주도록 함
    }

    IEnumerator ChangeStage()       // 스테이지를 바꿔주는 역할을 하는 함수
    {
        stages[curStage].SetActive(false);      // 여러 스테이지들을 false로 만들어줌

        ++curStage;         // 배열에 Stage개수를 늘릴 때 사용함
        if(curStage<stages.Length)       // 만약에 curStage가 각 스테이지 배열의 길이보다 작다면
        {
            yield return new WaitForSeconds(0.5f);      // 0.5초 기다렸다가
            stages[curStage].SetActive(true);           // 선택한 curstage를 true로 만들어 보여지도록 만든다
        }
        else        // 아니라면
        {
            SceneManager.LoadScene("Game");     // 다시 시작하려면 원래 게임 씬으로 돌아오도록 함
        }

        if (curStage == 1)      // Stage2로 이동했을 때
        {
            ads.Play();      // Stage2로 이동하면 경찰관의 무전기 소리가 나오도록 함
            PopupMsg1("치직..치지직.. 좀비가 나타났...다!!!! 다들 도망가!!", 6);     // 메시지 출력
        }
        else if (curStage == 2)     // Stage3로 이동했을 때
        {
            zombie.SetActive(false);    // 좀비를 위에서 setActive해줬기 때문에 Stage3에서는 false로 만들어줌
            DestroyClone();         // zombie를 복제해서 만들어진 클론들을 배열에 넣고 삭제해주는 과정

            PopupMsg(" 미션3 : 자동차들과 구멍을 피해 탈출구로 이동하세요!", 8);     // 메시지 출력
        }
        else if (curStage == 3)     // Stage4로 이동했을 때
        {
            PopupMsg(" 미션4 : 엄청 큰 보스 좀비가 나타났습니다! 마우스 오른쪽을 클릭해 공을 던져 좀비를 물리치세요!", 8);        // 메시지 출력
            zbhp1.SetActive(true);      // 좀비의 체력바가 나타날 수 있도록 함
            zbhp.SetActive(true);
            zbhp_text.SetActive(true);
        }
    }
}
