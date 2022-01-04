using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCtrl : MonoBehaviour
{
    // Stage1에서의 차 컨트롤을 담당하는 스크립트

    Vector3 firstPos;       // 차와 플레이어가 닿으면 차가 원래 자리로 돌아가기 위해 위치를 저장하기 위한 변수

    void Start()
    {
        firstPos = transform.localPosition;         // 원래 위치를 transform.localPosition으로 저장해준다.
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 0.1f),Space.Self);        // Stage1이 시작되면 상대좌표를 통해 앞으로 이동하도록 함
    }

    private void OnCollisionEnter(Collision collision)      // 충돌이 일어나는 경우
    {
        if (collision.gameObject.CompareTag("Block"))   // 차가 블럭과 닿으면
        {
            transform.localPosition = firstPos;         // 원래 위치로 돌아갈 수 있도록 만들어줌
        }
    }
}
