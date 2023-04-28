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
<div align="center"><img src=https://user-images.githubusercontent.com/70145314/234440107-1394bdca-ce59-4618-bb4d-ab041f4078a0.png width="500"></div> 



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

