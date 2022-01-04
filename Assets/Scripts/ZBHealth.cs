using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZBHealth : MonoBehaviour
{
    // Stage4에서 좀비의 체력을 보여주기 위한 스크립트 

    float maxHealth = 100f; // 좀비의 체력을 100으로 정해줌
    public static float zbhealth; // zbhealth를 static으로 설정하여 외부에서 접근할 수 있도록 해줌
    public Text hp;        // 좀비의 체력을 보여줄 수 있는 텍스트 UI 선언
    public Image imgComp;  // 체력바를 Canvas내부 Image로 생성해주었으므로 이를 선언해줌
    
    void Start()
    {
        zbhealth = maxHealth; // maxHealth를 zbhealth로 대입하여 값을 정해줌
    }

    void Update()
    {
        imgComp.fillAmount = zbhealth / maxHealth;  //fillAmount를 사용해서 체력바가 점점 소모되도록 해줌
        hp.text = string.Format("ZB HP {0} / 100", zbhealth);   // 텍스트가 표시될 수 있도록, 0은 바뀌는 zbhealth의 값이 나오도록 함
    }
}
