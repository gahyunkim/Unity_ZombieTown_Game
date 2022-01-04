using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    // Stage2에서 특정 위히에 좀비들이 등장할 수 있도록 Instantiate해주는 스크립트

    public GameObject zombie;       // 생성하고자하는 좀비 게임오브젝트를 선언함

    void Start()
    {
        InvokeRepeating("Spawn", 15.0f, 0.5f);      // Stage2가 실행되고 15초 후에 0.5초마다 좀비가 Spawn되도록 함
        Invoke("Stage2", 8.0f);     // Stage2가 실행되고나서 8초 후에 Stage2(), popupMessage를 출력할 수 있도록 함
    }
    
    void Update()
    {
       
    }

    void Stage2()
    {
        // 팝업 메시지 출력하기
        GameMng.instance.PopupMsg(" 미션2 : 좀비들을 피해                                        탈출구를 찾으세요!                                        3개의 탈출구 중 2개는 다시 원래 자리로 돌아오게 만듭니다", 8);
    }

    void Spawn()    // 좀비 프리팹을 이용해서 복제하는 함수
    {
        GameObject obj = Instantiate(zombie);   // Instantiate로 좀비 프리팹을 복제함

        Vector3 randPos;        // Vector3로 randPos 생성
        randPos.x = Random.Range(-0.2f, 0.2f);      // x축에서 랜덤한 방향으로 이동하도록
        randPos.y = 0;                              // y축에서의 이동은 없기 때문에 0
        randPos.z = Random.Range(-0.2f, 0.2f);      // z축에서 랜덤한 방향으로 이동하도록

        float randDeg = Random.Range(0, 360);       // 랜덤하게 회전방향을 가지고 복제될 수 있도록 함

        obj.transform.position = transform.position + randPos;          // transform되는 position에서 randPos를 만들어 랜덤하게 복제될 수 있도록 함
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);       // 랜덤한 방향으로 돌아갈 수 있도록 만들어줌

        Destroy(obj, 5);    // 생성되고 나면 5초 후에 생성된 obj가 삭제되도록 함
    }
}
