# Unity_ZombieTown_Game

## 게임 소개

뷰포리아를 이용한 게임으로 타겟을 인식하면 시작되는 게임을 제작함.   
평화롭던 한 마을에 갑자기 좀비들이 나타나게 되고 좀비를 피해 다른 마을로 이동하는 과정에서 
일어나는 일들(미션들) 을 해결하는 게임.

## 게임 기획

- 주인공: 좀비들을 피해 미션을 수행하고 안전한 마을로 이동하는 캐릭터
- 좀비: 플레이어(주인공)의 미션 수행을 방해하는 캐릭터
- 경찰: 스테이지 1에서 플레이어가 경찰관을 찾아가는 미션을 할 때 등장하는 캐릭터

움직이는 차를 피해라 - 데미지 5  
좀비를 피해라 - 데미지 10  
구멍을 피해라 - 데미지 10  
공을 던져서 좀비를 물리쳐라 - 좀비 데미지 10  
각 스테이지에서 제공하는 미션을 수행하라 - 다음 스테이지로 이동  

## 게임 구성

스테이지는 4개의 스테이지가 존재하고, 각각의 스테이지에서 제공하는 미션을 클리어해야함.    
방향키를 이용해서 주인공을 움직이고, 장애물과 닿으면 각각의 데미지에 따라 하단의 체력바가 깎임.  
플레이어가 모두 체력을 유지하고 좀비를 피하거나 모두 물리치게 되면 스테이지 클리어  

__스테이지 소개__
> 미션 1 : 경찰관을 찾아가세요!  
> 미션 2 : 좀비들을 피해 탈출구를 찾으세요!  
> 미션 3 : 자동차들과 구멍을 피해 탈출구로 이동하세요!  
> 미션 4 : 엄청 큰 보스 좀비가 나타났습니다! 마우스 오른쪽을 클릭해 공을 던져 좀비를 물리치세요!  

## 게임 플레이 방법
- 이미지를 인식하라는 화면이 나오고 이미지 인식하면 게임 시작  
( 뷰포리아를 이용한 이미지 타겟 인식으로 게임 시작 )  
- 스테이지 1에서 팝업 메시지로 기본적인 캐릭터 이동방식을 설명함  
( 1에서 요구하는 미션을 성공하면 다음 스테이지로 이동 )  
- 스테이지 2에서도 팝업 메시지로 미션을 제공함.  
( 좀비들을 피해 탈출구를 찾으면 스테이지 이동 )  
- 스테이지 3에서도 팝업 메시지로 미션을 제공함.   
( 움직이는 차들을 피해 탈출구로 이동하면 스테이지 이동)
- 스테이지 4에서 보스 좀비를 물리치면 게임 클리어
- 모든 스테이지를 클리어하고 체력 100에서 0이 되지 않았다면 게임 클리어
- 스테이지를 진행하는 과정에서 플레이어의 체력이 0이 된다면 게임 오버

## 게임 관련 이미지 및 게임 플레이 영상

- 게임 진행 과정 이미지  
<img src ="https://user-images.githubusercontent.com/68581876/148669013-5e79448b-7ff2-4d7d-a63b-836afe78bd79.png" width="30%" height="30%"> <img src = "https://user-images.githubusercontent.com/68581876/148668920-25358dec-670c-43bb-9442-0a2568acf320.png" width="30%" height ="30%"> <img src ="https://user-images.githubusercontent.com/68581876/148669038-914e6bcb-51b0-4e22-9e47-26de8e9bd31f.png" width="30%" height="30%">  
<img src ="https://user-images.githubusercontent.com/68581876/148669054-7787e751-3533-4ad3-aad4-5a2ed53109e2.png" width="30%" height="30%"> <img src ="https://user-images.githubusercontent.com/68581876/148669077-b23c79ba-e15a-488a-88ac-ba8e37eb4b30.png" width="30%" height="30%"> <img src ="https://user-images.githubusercontent.com/68581876/148669101-ae18ef8f-a8b4-4f1c-95f1-beb68e85b976.png" width="30%" height="30%">  
<img src ="https://user-images.githubusercontent.com/68581876/148669134-65125197-e4fb-47ad-bed4-bdf7ce227bab.png" width="30%" height="30%"> <img src ="https://user-images.githubusercontent.com/68581876/148669149-352d0977-1b78-4b01-80f5-5070169b4ffe.png" width="30%" height="30%">
<img src ="https://user-images.githubusercontent.com/68581876/148669169-7c7452b8-3a7c-4934-9097-380e5e82430c.png" width="30%" height="30%"> <img src = "https://user-images.githubusercontent.com/68581876/148669192-c0e0f612-42e6-43a0-8ce6-68a989ef5362.png" width="30%" height="30%">

- 게임 플레이 과정 (게임 클리어 버전) - 영상 크기가 커서 나눠서 올림 + 클릭하면 영상 보임  
1)<img src = "https://user-images.githubusercontent.com/68581876/148669366-7fb86e9f-af26-42df-94bf-11761d9315ac.mp4" width="30%" height="30%"> 2)<img src ="https://user-images.githubusercontent.com/68581876/148669415-558266f6-d9f0-494d-acd8-ce09e9e58fb5.mp4" width="30%" height="30%"> 3)<img src ="https://user-images.githubuse
rcontent.com/68581876/148669464-f0283539-4545-48ba-8f03-3a3075effaa7.mp4" width="30%" height="30%">  
4)<img src = "https://user-images.githubusercontent.com/68581876/148669489-d00e6b1d-3b76-4355-97d6-06ff4eda8a8c.mp4" width="30%" height="30%">  

## 게임에 사용된 에셋 및 사운드 출처

게임에 사용된 모든 에셋과 사운드들은 무료입니다.
- 전체적인 배경 에셋 (유니티 에셋 스토어)  
https://assetstore.unity.com/packages/3d/environments/urban/toony-tiny-city-demo-176087
- 캐릭터 에셋 (유니티 에셋 스토어)  
https://assetstore.unity.com/packages/3d/characters/toony-tiny-people-demo-113188
- Stage 3에서의 차 모델들 (유니티 에셋 스토어)  
https://assetstore.unity.com/packages/3d/vehicles/land/simple-cars-pack-97669
- 폰트 사용  
http://levelup.nexon.com/font/index.aspx  
- Stage 2에서의 경찰관 효과음  
https://effectdown.tistory.com/entry/%EC%9D%91%EA%B8%89%EC%82%AC%EC%9A%B4%EB%93%9C-%ED%9A%A8%EA%B3%BC%EC%9D%8C-%EB%AA%A8%EC%9D%8C7?category=824578#google_vignette
- 주인공 점프 효과음  
https://opengameart.org/content/soundpack-04
- Stage 1,3 배경음악  
https://opengameart.org/content/medieval-town
- Stage 2,4 배경음악  
https://opengameart.org/content/cannon-tube
- 공 던지면 나는 효과음  
https://opengameart.org/content/wind-hit-time-morph

