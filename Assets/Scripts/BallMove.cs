using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed;     // 공의 속도를 알려주는 변수
    Vector3 direction;      // direction을 통해 위치를 정해줌

    void Start()
    {

    }

    void Update()
    {
        Vector3 deltaPos = direction * speed * Time.deltaTime;      // 앞으로 나아가는 힘을 제공함
        transform.Translate(deltaPos);      // deltaPos로 위치를 이동시켜준다
    }

    // 공이 발사되는 지점과 방향을 알려주기 위한 함수
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;       // pos로 포지션을 이동함
        direction = dir;    // 공이 날아가는 방향을 제공함
    }

    private void OnCollisionEnter(Collision collision)  // 공중에서 두번 점프가 불가능 하도록 만들어줌 
    {
        if (collision.gameObject.CompareTag("Zombie"))   // hero가 바닥에 닿으면
        {
            Destroy(gameObject);    // 점프를 할 수 있도록 만들어 줌
        }
    }
}
