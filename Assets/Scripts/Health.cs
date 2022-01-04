using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // 플레이어의 체력을 컨트롤 할 수 있는 스크립트

    float maxHealth = 100f;     // Player의 체력을 100으로 정해줌
    public static float health; // health를 static으로 설정하여 외부에서 접근할 수 있도록 해줌
    public Text hp;         // 체력을 Text로 보여줄 수 있는 UI 오브젝트
    public Image imgComp;   // 체력바를 Canvas내부 Image로 생성해주었으므로 이를 선언해줌

    void Start()
    {
        health = maxHealth; // maxHealth를 health로 대입하여 값을 정해줌
    }

    void Update()
    {
        imgComp.fillAmount = health / maxHealth;            // fillAmount를 사용해서 체력바가 점점 소모되도록 해줌
        hp.text = string.Format("HP {0} / 100", health);    // text에 HP가 표시되도록 하는 부분
    }
}
