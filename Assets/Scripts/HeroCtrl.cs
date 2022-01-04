using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroCtrl : MonoBehaviour
{
    // Player의 컨트롤을 담당하는 스크립트

    private Rigidbody rigid;        // rigidbody를 사용하기 때문에 Rigidbody를 생성함
    public GameObject ballObj;      // Stage4에서 좀비를 공격하는 공을 복제하기 위한 프리팹을 넣는 변수

    public float rotateSpeed = 10.0f;  // 회전하는 속도를 지정해서 속도만큼 회전하도록 만들어줌
    
    Vector3 firstPos;       // 특정 오브젝트와 닿았을 때 처음의 Player가 처음의 위치로 돌아가도록 함

    public int JumpPower;       // 점프하는 힘을 정해주는 변수
    public int Movespeed;       // hero가 움직이는 속도를 정해주는 변수

    private bool isJumping;     // 점프 할 수 있는지 없는지 확인하는 변수
    Animation ani;
    AudioSource ads;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();      // 사용하고자 하는 Rigidbody, Audio, Animation등을 불러옴
        ads = GetComponent<AudioSource>();
        ani = GetComponent<Animation>();

        firstPos = transform.localPosition;     // 원래의 위치로 돌아가기 위해서 localPositionㅇ르 이용해서 원래 위치를 저장함
        isJumping = false;                      // 공중에서 두번 점프를 못하게 하기 위해서 현재 점프중인지 확인하는 bool형 변수 => 현재는 안뛰고 있기 때문에 false
    }

    void Update()
    {
        Move();     // Move 함수를 실행하도록 함 = 이동과 회전을 담당하는 부분
        Jump();     // Jump 함수를 실행하도록 함

        if (Input.GetMouseButtonDown(1))    // 마우스 오른쪽을 누르면 Stage4에서 공을 던질 수 있도록 하는 부분
        {
            Shot(transform.forward);        // Shot 함수를 이용해 공을 앞으로 던지도록 함
        }
    }

    void Shot(Vector3 dir)      // Shot함수를 이용해 공을 던질 수 있도록 함
    {
        GameObject obj = Instantiate(ballObj);      // 던지고자 하는 공을 복제함
        Vector3 shotPos = transform.position + transform.up * 4f;       // 공을 어느 위치에서 던질 것인지 결정함
            
        obj.GetComponent<BallMove>().SetPosDir(shotPos, dir);           // 복제된 공을 BallMove에서 만들어놓은 SetPosDir을 호출해 dir과 shotPos를 설정해서 사용
        Destroy(obj, 8);       // 만들어진 공은 8초가 지나면 사라지도록 함
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");  // 좌,우로 이동이 가능하도록 함
        float v = Input.GetAxis("Vertical");    // 위,아래로 이동이 가능하도록 함

        Vector3 dir = new Vector3(h, 0, v);     // dir을 통해 이동하는 위치를 만들어줌

        if (!(h == 0 && v == 0))
        {   
            // 이동을 관리하는 부분으로 speed와 시간당 이동하는 것으로 만들어줌
            transform.position += -dir * Movespeed * Time.deltaTime; // dir을 -로 해주어 보는 방향으로 잘 이동할 수 있도록 함
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-dir), Time.deltaTime * rotateSpeed);
            // Lerp를 이용해 부드럽게 회전할 수 있도록 만들어줌
        }
    }

    void Jump()         // 플레이어의 점프를 동작하도록 하는 함수
    {
        if(Input.GetKeyDown(KeyCode.Space))     // 스페이스바를 누르면 뛸 수 있도록
        {
            ads.Play();         // Jump를 누르면 플레이어로부터 점프 소리를 출력할 수 있도록 함
            if(!isJumping)      // 바닥과 닿아 있으면 점프 가능.
            {
                isJumping = true;       // 점프 가능함
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                // 질량의 힘을 받으면서 짧은 시간에 힘을 가하도록 해서 점프할 수 있도록 만들어줌
            }
            else    // 떠있는 상태라면 점프하지 못하도록 함
            {
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)  // 공중에서 두번 점프가 불가능 하도록 만들어줌 
    {
        if (collision.gameObject.CompareTag("Ground"))   // hero가 바닥에 닿으면
        {
            isJumping = false;      // 점프를 할 수 있도록 만들어 줌
        }
        else if (collision.gameObject.CompareTag("Car"))   // 차와 닿으면 발생하도록 함
        {
            transform.localPosition = firstPos;       // 차와 닿으면 원래 위치로 돌아가도록 함
            GameMng.instance.PopupMsg("차와 닿으면 원래 위치로 돌아가고 체력이 줄어듭니다! 주의하세요!", 7);       // 메시지 출력
            Health.health -= 5f;        // 차와 닿으면 체력 줄어들도록
        }
        else if (collision.gameObject.CompareTag("Magic"))      // 경찰관을 찾은 경우 다음 스테이지로 이동
        {
            GameMng.instance.GoNextStage();     // 다음 스테이지로 이동하는 함수를 사용하기 위해 GameMng로부터 가져옴
        }
        else if (collision.gameObject.CompareTag("Zombie"))     // 좀비와 닿은 경우 체력이 감소함
        {
            GameMng.instance.PopupMsg("좀비와 닿으면 체력이 줄어듭니다! 주의하세요!", 7);      // 메시지 출력
            Health.health -= 10f;       // 플레이어의 체력을 줄여줌
        }
        else if (collision.gameObject.CompareTag("Aura"))   // 매직 아우라 3개중 두 곳과 닿으면 플레이어가 원래 위치로 돌아오게 된다.
        {
            GameMng.instance.PopupMsg("탈출구가 아닙니다. 다른 탈출구를 찾으세요! 캐릭터는 원래 위치로 돌아갑니다", 5);     // 메시지 출력
            transform.localPosition = firstPos;    // 옳지 않은 탈출구를 찾으면 원래 자리로 돌아가도록 함
        }
        else if (collision.gameObject.CompareTag("Aura1"))  // 탈출구를 찾은 경우
        {
            GameMng.instance.PopupMsg("안전한 마을로 가기위한 탈출구를 찾았습니다!", 7);       // 메시지 출력
            GameMng.instance.GoNextStage();     // 다음 스테이지로 이동할 수 있도록 함
        }
        else if (collision.gameObject.CompareTag("Hole"))   // Stage3에서 구멍으로 떨어졌을 때
        {
            GameMng.instance.PopupMsg("바닥으로 떨어지면 체력이 줄어듭니다! 캐릭터는 원래 위치로 이동합니다!", 5);        // 메시지 출력
            transform.localPosition = firstPos; // 원래 위치로 이동하게 됨
            Health.health -= 5f;        // 바닥과 닿았기 때문에 체력 줄어들음
        }
    }
}
