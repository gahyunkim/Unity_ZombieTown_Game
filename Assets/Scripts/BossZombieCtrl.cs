using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZombieCtrl : MonoBehaviour
{
    // Stage4에서 좀비 보스의 컨트롤을 담당하는 부분
    
    public float speed;     // 속도를 가져오는 변수
    Vector3 moveDir;        // 이동하고자 하는 좌표를 저장하는 변수

    void Start()
    {

    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");     // 플레이어 태그를 가진 hero를 찾음

        moveDir = player.transform.position - transform.position;       // 좀비가 플레이어를 따라가도록하는 이동을 보여줌
        moveDir.y = 0;      // y축에서의 변화는 없음

        float angle = Vector3.SignedAngle(transform.forward, moveDir.normalized, Vector3.up);   // angle을 찾는 과정

        transform.Rotate(0, angle, 0);  // 플레이어가 이동하는 방향에 따라서 회전하도록 만들어줌

        Vector3 deltaPos = Vector3.forward * speed * Time.deltaTime;        // 좀비가 이동하는 과정 
        transform.Translate(deltaPos, Space.Self);      // 상대좌표를 사용해서 이동할 수 있도록 함
    }

    private void OnCollisionEnter(Collision collision)  // 충돌이 일어났을 때
    {
        if (collision.gameObject.CompareTag("Ball"))   // 플레이어가 던진 공에 맞으면
        {
            ZBHealth.zbhealth -= 10f;    // 좀비의 체력이 줄어들도록 만들어 줌
        }
    }
}
