using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Car1 : MonoBehaviour
{
    // Stage3에서의 car들을 컨트롤 하는 스크립트

    public GameObject block;    // block으로  태그 Block과 닿으면 다시 돌아갈 위치를 표시함

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 0.1f), Space.Self);       // 0.1f만큼 상대좌표 값으로 이동할 수 있도록 함
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))   // Stage3에서 움직이는 차들이 태그 블럭과 닿으면
        {
            transform.position = block.transform.position;      // 지정한 위치인 block의 위치로 돌아가서 다시 시작될 수 있도록 함 
        }
    }
}
