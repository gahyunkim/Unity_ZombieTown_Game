using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCtrl : MonoBehaviour
{
    // 좀비 프리팹을 컨트롤 하는 스크립트

    void Start()
    {
        
    }

    void Update()
    {
        // 상대 좌표를 사용해서 앞으로 이동하도록 함
        transform.Translate(new Vector3(0, 0, 0.07f),Space.Self);
    }

    private void OnCollisionEnter(Collision collision)   // 충돌시에 나타나는 일을 보여줌
    {
        if (collision.gameObject.CompareTag("Player"))   // 좀비 프리팹이 플레이어와 닿으면
        {
            Destroy (gameObject);      // 현재 게임 오브젝트인 좀비를 삭제하도록 함
        }
    }
}
