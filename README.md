<a name="readme-top"></a>
# FitnessVR
3D Pose Analysis and Feedback Architecture

<!-- TABLE OF CONTENTS -->
<details>
  <summary>목차</summary>
  <ol>
    <li>
      <a href="#about-the-project">About the Project</a>
      <ul>
        <li><a href="#built-with">Built with</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#application-contents">Application Contents</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

## About the Project
<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/33aef95f-babe-4892-ad99-14c812c1eae3 width="400"></div> 

<h4 align="center">Azure Kinect Motion Capture & MediaPipe Pose Classification <br/></h4>

- Azure Kinect Motion Capture로 실시간 Depth Pose Detection을 수행한다. 이는 몸체의 각도가 카메라와 정면이 이루고 있지 않아도 Detection이 수행되도록 한다. 
- 사용자 트레이닝을 위한 전문가 동작 샘플 이미지, 비디오를 수집하고 MediaPipe API를 이용해 샘플로부터 Pose Estimation 및 포즈 랜드마크를 획득한다.

<h4 align="center">VR Virtual Screen Layout <br/></h4>

- Trainer와 User의 포즈를 확인할 수 있도록 Virtual Screen Layout Design
- Layout에는 에러 보정 핸들링, 카메라 회전 알고리즘 등이 포함되어 설계된다.

## Motivation
* 동작 인식 기반 게임은 게임 산업과 헬스케어와 같은 다른 산업과 결합할 수 있는 분야로 다양한 콘솔 게임기에서 모션 인식 게임을 지원하고 있다. 
* 하지만 기존 동작 인식 게임은 사용자가 실제로 필요로 하거나 원하는 부위 및 원하는 순서로 편집된 운동 트레이닝은 불가능하다는 문제가 있었다.
* 따라서 기존의 동작 인식 기반 게임에 모션 분석 시스템을 더해 사용자에게 맞춤형 서비스를 제공하도록 한다.
* 또한, VR Virtual Screen Layout을 설계함으로써 제공된 데이터를 바탕으로 맞춤형 연습과 트레이닝 가이드를 제공하도록 한다.


## Built with
* [![Unity][Unity]][Unity-url] **(2021.3.11f1 LTS)**
* [![Oculus][Oculus]][Oculus-url]
* [![C#][C#]][C#-url]
* [![Visual Studio][Visual Studio]][VS-url]
* [![Github][Github]][Github-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Flow Diagram
<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/acb1c9db-b8e0-459f-8b31-481f78728ac9 width="900"></div> 
1. Image & Depth Camera Pose Tracking </br>
2. Pose Estimation & Character Pose Mapping </br>
3. 획득한 포즈 랜드마크로 에러 계산 및 시각화 </br>
4. 변화량 계산을 통한 뷰 선택 (Discrete) </br>
5. 최종 피드백 화면 출력 </br>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Implement
### 1. Image & Depth Camera Pose Tracking
<center>

|<center>MediaPipe</center>|<center>Azure Kinect</center>|
|:--------|:--------:|
|<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/eda4e59d-545b-46c9-837d-9739510b0399 width="150"></div> |<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/60ea94e1-0dd0-4df1-95e8-e4715dbad349 width="150"></div>|
</center>

* 자세 교정을 위해 Instructor Pose와 User Pose가 필요합니다.
    * Instructor Pose (GT) : MediaPipe로부터 Pose Estimation
    * User Pose (Input) : Azure Kinect로 실시간 Depth Camera Detect
* MediaPipe Plugin 사용
    * 구글에서 얼굴 인식, 포즈, 객체 감지, 모션감지 등 AI 기능을 제공하는 라이브러리
    * MediaPipe C++ Code를 C#으로 포트하여 유니티에서 쓸 수 있도록 한 플러그인
* Azure Kinect Plugin 사용
    * 마이크로소프트 Azure Kinect Depth Camera Detet를 위한 플러그인

### 2. Pose Estimation & Character Pose Mapping
</br>
<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/45a4852b-3c6d-4210-9cb6-0bd3da23e89b
width="400"></div>
<h4 align="center">MediaPipe Skeleton/Azure Kinect Skeleton <br/></h4>

* MediaPipe와 Azure Kinect는 Skeleton 구조가 다르기 때문에 이를 통일된 Skeleton에 맵핑하는 과정이 필요합니다.
* Mixamo Skeleton으로 통일시켜, 스켈레톤 계층 구조에 따라 특정 관절의 상대적 회전값을 계산할 수 있습니다.

### 3. Pose Error Calculation & Visualization
</br>
<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/1dda3929-614d-4ba3-bc5e-dd25a060db01
width="400"></div>

* 사용자의 자세와 참조 자세(정답 자세) 간의 관절 각도 차이를 계산하여 에러값을 얻어낼 수 있습니다. 
* 이에 따라 사용자에게 자세의 어떤 부분을 수정해야 하는지에 대한 시각적 피드백을 제공합니다.
* 몰입감 있는 경험을 제공하기 위해 시스템을 VR 디스플레이와 통합시키도록 합니다.

### 4. View Selection
</br>
<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/82001104-e732-44a1-aa69-379fb4ec3025
width="400"></div>

* 사용자의 동작을 전면 (XY), 상단 (XZ), 측면 (YZ)의 세 가지 다른 평면에 투영시킬 수 있는데, 해당 캐릭터는 2차원에 대해 판정 부위, Joint Position에 따른 Distance을 가지게 됩니다.
* 시스템은 사용자의 동작을 전면 (XY), 상단 (XZ), 측면 (YZ)의 세 가지 다른 평면에 투영함으로써 적절한 뷰 선택을 위한 알고리즘을 구현하여 사용자의 현재 자세와 목표 자세에 따라 시스템은 전면, 상단 또는 측면 뷰를 표시할 수 있습니다.

## Result
</br>
<div align="center"><img src=https://github.com/mmindoong/-2023-1-FitnessVRUnity/assets/70145314/b3b4e514-b75d-430f-8811-efc6e10e2826
width="400"></div>

<center>

|<center>자세 이름</center>|<center>동작 설명</center>|<center>동작 분석</center>|<center>피드백 방식</center>|
|:--------|:--------:|:--------:|:--------:|
|독수리 자세|양발을 모으고 양팔을 벌려준 채, 오른팔이 왼팔 밑으로 하며 팔꿈치를 꼬는 동작|1. 밧줄처럼 양팔을 비틀 때, 양손 바닥이 완벽히 맞닿지 않음.</br>2. 허리는 펴고, 다리의 무릎이 굽혀야 지탱할 수 있다.</br> 3.오른팔이 왼팔 밑으로 팔꿈치를 꼬았는지 확인해야 한다. |정면과 측면을 고려하여 동작을 수행해야 한다. |
|전사 자세|골반이 정렬을 맞춘 상태에서 한쪽은 무릎을 펴고, 한쪽은 무릎을 굽혀 두 팔은 뻗고 다리를 지지하는 동작|1. 골반은 항상 정면을 바라보도록하고, 뒷다리 무릎을 펴야 한다. </br>2. 두 다리가 골반 넓이로 벌려야 한다. 측면으로 보았을 때, 한쪽다리는 수직으로 무릎을 굽히도록 한다</br> 3.측면 기준으로 길게 뻗는 발끝은 정면을 향하도록 한다. </br> 4. 상체는 골반 정렬과 일직선이 되도록 팔을 뻗고 있는지 확인한다. |정면과 측면을 고려하여 동작을 수행해야 한다. |
</center>

## Conclusion
시스템은 사용자의 자세를 추적하고 실시간 피드백을 제공하는 방법을 성공적으로 구현함으로써 동작 인식 기반에 모션 분석 시스템을 더해 사용자 맞춤형 아키텍쳐를 구축하였다. 시스템은 사용자와 강의자의 모션을 인식하고 매핑할 수 있고, 사용자의 동작을 전면, 상단 및 측면 세 가지 다른 평면으로 투영하고, 사용자의 동작을 기반으로 관절 각도를 업데이트하는 과정을 통해 분석할 수 있다. 또한 시스템은 이미지 소스 및 감지를 위한 사용자 인터페이스와 사용자의 시선을 따라가는 VR 스크린을 포함하여 사용자에게 피드백을 제공할 수 있다.
### 기대 효과
* 시스템은 사용자의 자세에 대한 정확하고 실시간의 피드백을 제공하여 사용자가 자세 형성을 개선하는 데 도움이 될 것으로 기대된다. 특히 정확한 자세 형성이 중요한 요가와 같은 활동에 유용할 수 있다. 이후 시스템이 다양한 각도에서 연속적인 피드백을 제공하고 동시에 두 개의 뷰를 표시할 수 있도록 개선한다면, 사용자에게 보다 종합적인 피드백을 제공할 수 있을 것이다.
### 활용 방안
* 실제로 현재 게임 산업은 개인화가 핵심 경쟁력이다. 하나의 게임도 사용자들이 각자의 수준에 맞게 즐길 수 있도록 만드는 것을 목표로 한다. 게임을 너무 어렵게 만들면 초보자들은 즐기기가 어렵고 너무 쉬우면 마니아들은 금방 싫증을 내기 때문이다. 이처럼 사용자 맞춤형으로 컨텐츠를 진행함으로써 난이도 수준을 실시간으로 조절할 수 있다. 제공된 데이터를 바탕으로 맞춤형 연습과 트레이닝 가이드를 제공함으로써 게임과 헬스케어의 결합을 더 향상시킬 수 있다.


<!-- MARKDOWN LINKS & IMAGES -->

[Unity]: https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=Unity&logoColor=white
[Unity-url]: https://unity.com/
[C#]:https://img.shields.io/badge/C%20Sharp-239120?style=for-the-badge&logo=C%20sharp&logoColor=white
[C#-url]: https://en.wikipedia.org/wiki/C_Sharp_(programming_language)
[Oculus]: https://img.shields.io/badge/Oculus-1C1E20?style=for-the-badge&logo=Oculus&logoColor=white
[Oculus-url]: https://www.oculus.com/experiences/quest/
[Visual Studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=Visual%20Studio&logoColor=white
[VS-url]: https://visualstudio.microsoft.com/ko/
[Github]: https://img.shields.io/badge/Github-5C2D91?style=for-the-badge&logo=Github&logoColor=white
[Github-url]: https://github.com/ssw03270/Moon-Greeting-Festival

