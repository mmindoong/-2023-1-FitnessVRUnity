using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Mediapipe.Unity
{
  public class AngleClassfication : MonoBehaviour
  {
    public PointAnnotation[] annotation;
    public GameObject PointObject;

    public Animator animator;
    public Animator AnswerAnimator;

    public SkinnedMeshRenderer surface;
    public Material[] newMaterial;

    public Text text;

    public List<Vector3> movementPoints = new List<Vector3>(); // 3D 공간에서의 이동 경로를 나타내는 포인트들
    public float updateInterval = 5.0f; // 위치를 업데이트하는 시간 간격 (5초)
    public Transform AcitveJoint;
    public Camera mainCamera;
    public float smoothFactor = 0.5f;
    public Quaternion targetRotation; // 목표 회전을 저장할 변수
    public Quaternion initialRotation;
    public Vector3 initialPosition;
    private Vector3 targetPosition;

    private Transform hip;
    private Transform leftUpperLeg;
    private Transform rightUpperLeg;
    private Transform leftLowerLeg;
    private Transform rightLowerLeg;
    private Transform leftFoot;
    private Transform rightFoot;
    private Transform chest;
    private Transform neck;
    private Transform head;
    private Transform spine;
    private Transform leftShoulder;
    private Transform rightShoulder;
    private Transform leftUpperArm;
    private Transform rightUpperArm;
    private Transform leftLowerArm;
    private Transform rightLowerArm;
    private Transform leftHand;
    private Transform leftHandIndex;
    private Transform rightHand;
    private Transform rightHandIndex;
    private Transform leftFootToe;
    private Transform rightFootToe;
    private Transform UpperChest;


    private Transform Answerhip;
    private Transform AnswerleftUpperLeg;
    private Transform AnswerrightUpperLeg;
    private Transform AnswerleftLowerLeg;
    private Transform AnswerrightLowerLeg;
    private Transform AnswerleftFoot;
    private Transform AnswerrightFoot;
    private Transform Answerchest;
    private Transform Answerneck;
    private Transform Answerhead;
    private Transform Answerspine;
    private Transform AnswerleftShoulder;
    private Transform AnswerrightShoulder;
    private Transform AnswerleftUpperArm;
    private Transform AnswerrightUpperArm;
    private Transform AnswerleftLowerArm;
    private Transform AnswerrightLowerArm;
    private Transform AnswerleftHand;
    private Transform AnswerleftHandIndex;
    private Transform AnswerrightHand;
    private Transform AnswerrightHandIndex;
    private Transform AnswerleftFootToe;
    private Transform AnswerrightFootToe;
    private Transform AnswerUpperChest;

    
    /*
    void Assign()
    {
      Debug.Log("hellooooooooooooooo");
      for (int i = 0; i < PointObject.transform.childCount; i++)
      {
        PointAnnotation component = PointObject.transform.GetChild(i).GetComponent<PointAnnotation>();
        annotation[i] = component;
      }
      // LEFT(홀수, 주황)
      AnswerleftUpperLeg = annotation[23].GetTransform();
      AnswerrightUpperLeg = annotation[24].GetTransform();
      AnswerleftLowerLeg = annotation[25].GetTransform();
      AnswerrightLowerLeg = annotation[26].GetTransform();
      AnswerleftFoot = annotation[27].GetTransform();
      AnswerrightFoot = annotation[28].GetTransform();
      Answerchest = annotation[11].GetTransform();// + new Vector3(0.04f, 0.02f, 0.03f);
      Answerhip = Answerchest; // + new Vector3(0.0f, 0.02f, 0.00f);
      Answerspine = Answerchest; //+ new Vector3(0.0f, 0.02f, 0.00f);
      Answerhead = annotation[0].GetTransform();
      AnswerleftShoulder = annotation[11].GetTransform();
      AnswerrightShoulder = annotation[12].GetTransform();
      AnswerleftUpperArm = annotation[11].GetTransform();
    AnswerrightUpperArm = annotation[12].GetTransform();
      AnswerleftLowerArm = annotation[13].GetTransform();
      AnswerrightLowerArm = annotation[14].GetTransform();
      AnswerleftHand = annotation[15].GetTransform();
      AnswerrightHand = annotation[16].GetTransform();
      AnswerleftHandIndex = annotation[17].GetTransform();
      AnswerrightHandIndex = annotation[18].GetTransform();
      AnswerleftFootToe = annotation[31].GetTransform();
      AnswerrightFootToe = annotation[32].GetTransform();
     // AnswerUpperChest =
      Answerneck = annotation[10].GetTransform();
    }
    */

    void Start()
    {
      // 카메라의 초기 회전을 설정합니다.
      initialRotation = Quaternion.Euler(-360, 180, 180);
      initialPosition = mainCamera.transform.position;

      leftUpperLeg = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
      rightUpperLeg = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
      leftLowerLeg = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
      rightLowerLeg = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
      leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
      rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
      chest = animator.GetBoneTransform(HumanBodyBones.Chest);
      hip = animator.GetBoneTransform(HumanBodyBones.Hips);
      spine = animator.GetBoneTransform(HumanBodyBones.Spine);
      head = animator.GetBoneTransform(HumanBodyBones.Head);
      leftShoulder = animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
      rightShoulder = animator.GetBoneTransform(HumanBodyBones.RightShoulder);
      leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
      rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
      leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
      rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
      leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
      rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
      leftHandIndex = animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
      rightHandIndex = animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
      leftFootToe = animator.GetBoneTransform(HumanBodyBones.LeftToes);
      rightFootToe = animator.GetBoneTransform(HumanBodyBones.RightToes);
      UpperChest = animator.GetBoneTransform(HumanBodyBones.UpperChest);
      neck = animator.GetBoneTransform(HumanBodyBones.Neck);
      
      AnswerleftUpperLeg = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
      AnswerrightUpperLeg = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
      AnswerleftLowerLeg = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
      AnswerrightLowerLeg = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
      AnswerleftFoot = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftFoot);
      AnswerrightFoot = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightFoot);
      Answerchest = AnswerAnimator.GetBoneTransform(HumanBodyBones.Chest);
      Answerhip = AnswerAnimator.GetBoneTransform(HumanBodyBones.Hips);
      Answerspine = AnswerAnimator.GetBoneTransform(HumanBodyBones.Spine);
      Answerhead = AnswerAnimator.GetBoneTransform(HumanBodyBones.Head);
      AnswerleftShoulder = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftShoulder);
      AnswerrightShoulder = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightShoulder);
      AnswerleftUpperArm = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
      AnswerrightUpperArm = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm);
      AnswerleftLowerArm = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
      AnswerrightLowerArm = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightLowerArm);
      AnswerleftHand = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
      AnswerrightHand = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightHand);
      AnswerleftHandIndex = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
      AnswerrightHandIndex = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
      AnswerleftFootToe = AnswerAnimator.GetBoneTransform(HumanBodyBones.LeftToes);
      AnswerrightFootToe = AnswerAnimator.GetBoneTransform(HumanBodyBones.RightToes);
      AnswerUpperChest = AnswerAnimator.GetBoneTransform(HumanBodyBones.UpperChest);
      Answerneck = AnswerAnimator.GetBoneTransform(HumanBodyBones.Neck);


      StartCoroutine(PeriodicAreaCalculation());

    }

    IEnumerator PeriodicAreaCalculation()
    {
      while (true)
      {
        yield return new WaitForSeconds(updateInterval);

        // 1. 면적 계산
        float xyArea = CalculateProjectedArea(movementPoints, Axis.XY);
        float yzArea = CalculateProjectedArea(movementPoints, Axis.YZ);
        float xzArea = CalculateProjectedArea(movementPoints, Axis.XZ);
        Debug.Log("XY Area: " + xyArea + ", YZ Area: " + yzArea + ", XZ Area: " + xzArea);

        // 2. 면적 비율 계산 
        float totalArea = xyArea + yzArea + xzArea;
        float frontRatio = xyArea / totalArea;
        float sideRatio = yzArea / totalArea;
        float topRatio = xzArea / totalArea;

        // 3. 비율을 기반으로 수평 및 수직 방향의 카메라 각도 결정
        AdjustCameraAngle(frontRatio, sideRatio, topRatio);

        // 4.  리스트 초기화
        movementPoints.Clear();

        mainCamera.transform.rotation = initialRotation;
        mainCamera.transform.position = initialPosition;
      }
    }

    enum Axis { XY, YZ, XZ }
    // 각 평면에 대해 3D 움직임 데이터를 2D로 투영하고, 이 투영된 데이터를 기반으로 각 평면에서의 면적을 계산(연속된 포인트 사이의 사다리꼴 면적 계산)
    float CalculateProjectedArea(List<Vector3> points, Axis axis)
    {
      float area = 0f;
      for (int i = 0; i < points.Count - 1; i++)
      {
        Vector2 a = ProjectPoint(points[i], axis);
        Vector2 b = ProjectPoint(points[i + 1], axis);
        area += TrapezoidArea(a, b);
      }
      return Mathf.Abs(area);
    }
    Vector2 ProjectPoint(Vector3 point, Axis axis)
    {
      switch (axis)
      {
        case Axis.XY:
          return new Vector2(point.x, point.y);
        case Axis.YZ:
          return new Vector2(point.y, point.z);
        case Axis.XZ:
          return new Vector2(point.x, point.z);
        default:
          return Vector2.zero;
      }
    }
    float TrapezoidArea(Vector2 a, Vector2 b)
    {
      float h = b.x - a.x;
      float avgY = (a.y + b.y) / 2;
      return h * avgY;
    }

    void AdjustCameraAngle(float frontRatio, float sideRatio, float topRatio)
    {
      // 전체 비율 합계를 계산
      float totalRatio = frontRatio + sideRatio + topRatio;

      // 각도 계산을 위해 각 비율을 정규화
      float normalizedFrontRatio = frontRatio / totalRatio;
      float normalizedSideRatio = sideRatio / totalRatio;
      float normalizedTopRatio = topRatio / totalRatio;
      Debug.Log("XY Ratio " + normalizedFrontRatio + ", YZ Ratio: " + normalizedSideRatio + ", XZ Ratio: " + normalizedTopRatio);

      // 수평 회전 (Y 축)과 수직 회전 (X 축)을 계산
      float horizontalRotation = normalizedSideRatio * 180f - 90f; // -90도(왼쪽)에서 90도(오른쪽)까지
      float verticalRotation = normalizedTopRatio * 180f - 90f;   // -90도(아래)에서 90도(위)까지

      // 목표 회전을 계산
      Quaternion targetHorizontalRotation = Quaternion.Euler(0, horizontalRotation, 0);
      Quaternion targetVerticalRotation = Quaternion.Euler(verticalRotation, 0, 0);
      targetRotation = initialRotation * targetHorizontalRotation * targetVerticalRotation;
      Debug.Log("Target Rotation " + targetRotation);

      targetPosition = AcitveJoint.position - AcitveJoint.forward;
    }

    private void LateUpdate()
    {
      // 현재 회전에서 목표 회전으로 보간
      mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetRotation, Time.deltaTime * smoothFactor);
      mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * smoothFactor);
      Debug.Log("Camera Rotation " + mainCamera.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
      // 매 프레임마다 현재 오브젝트의 위치를 리스트에 추가
      movementPoints.Add(AcitveJoint.position);

      float leftShoulderAngle = CalculateJointAngle(leftUpperArm.position, leftShoulder.position, chest.position);
      float rightShoulderAngle = CalculateJointAngle(rightUpperArm.position, rightShoulder.position, chest.position);
      float leftUpperArmAngle = CalculateJointAngle(leftShoulder.position, leftUpperArm.position, leftLowerArm.position);
      float rightUpperArmAngle = CalculateJointAngle(rightShoulder.position, rightUpperArm.position, rightLowerArm.position);
      float leftForeArmAngle = CalculateJointAngle(leftUpperArm.position, leftLowerArm.position, leftHand.position);
      float rightForeArmAngle = CalculateJointAngle(rightUpperArm.position, rightLowerArm.position, rightHand.position);
      float leftHandAngle = CalculateJointAngle(leftLowerArm.position, leftHand.position, leftHandIndex.position);
      float rightHandAngle = CalculateJointAngle(rightLowerArm.position, rightHand.position, rightHandIndex.position);
      float leftLegAngle = 180 - CalculateJointAngle(hip.position, leftUpperLeg.position, leftLowerLeg.position);
      float rightLegAngle = 180 - CalculateJointAngle(hip.position, rightUpperLeg.position, rightLowerLeg.position);
      float leftlowerlegAngle = 180 - CalculateJointAngle(leftUpperLeg.position, leftLowerLeg.position, leftFoot.position);
      float rightlowerLegAngle = 180 - CalculateJointAngle(rightUpperLeg.position, rightLowerLeg.position, rightFoot.position);
      float leftFootAngle = 180 - CalculateJointAngle(leftLowerLeg.position, leftFoot.position, leftFootToe.position);
      float rightFootAngle = 180 - CalculateJointAngle(rightLowerLeg.position, rightFoot.position, rightFootToe.position);
      float HeadAnlge = CalculateJointAngle(head.position, neck.position, chest.position);
      float ChestAngle = CalculateJointAngle(UpperChest.position, chest.position, spine.position);

      
      float AnswerleftShoulderAngle = CalculateJointAngle(AnswerleftUpperArm.position, AnswerleftShoulder.position, Answerchest.position);
      float AnswerrightShoulderAngle = CalculateJointAngle(AnswerrightUpperArm.position, AnswerrightShoulder.position, Answerchest.position);
      float AnswerleftUpperArmAngle = CalculateJointAngle(AnswerleftShoulder.position, AnswerleftUpperArm.position, AnswerleftLowerArm.position);
      float AnswerrightUpperArmAngle = CalculateJointAngle(AnswerrightShoulder.position, AnswerrightUpperArm.position, AnswerrightLowerArm.position);
      float AnswerleftForeArmAngle = CalculateJointAngle(AnswerleftUpperArm.position, AnswerleftLowerArm.position, AnswerleftHand.position);
      float AnswerrightForeArmAngle = CalculateJointAngle(AnswerrightUpperArm.position, AnswerrightLowerArm.position, AnswerrightHand.position);
      float AnswerleftHandAngle = CalculateJointAngle(AnswerleftLowerArm.position, AnswerleftHand.position, AnswerleftHandIndex.position);
      float AnswerrightHandAngle = CalculateJointAngle(AnswerrightLowerArm.position, AnswerrightHand.position, AnswerrightHandIndex.position);
      float AnswerleftLegAngle = 180 - CalculateJointAngle(Answerhip.position, AnswerleftUpperLeg.position, AnswerleftLowerLeg.position);
      float AnswerleftlowerlegAngle = 180 - CalculateJointAngle(AnswerleftUpperLeg.position, AnswerleftLowerLeg.position, AnswerleftFoot.position);
      float AnswerrightLegAngle = 180 - CalculateJointAngle(Answerhip.position, AnswerrightUpperLeg.position, AnswerrightLowerLeg.position);
      float AnswerrightlowerLegAngle = 180 - CalculateJointAngle(AnswerrightUpperLeg.position, AnswerrightLowerLeg.position, AnswerrightFoot.position);
      float AnswerleftFootAngle = 180 - CalculateJointAngle(AnswerleftLowerLeg.position, AnswerleftFoot.position, AnswerleftFootToe.position);
      float AnswerrightFootAngle = 180 - CalculateJointAngle(AnswerrightLowerLeg.position, AnswerrightFoot.position, AnswerrightFootToe.position);
      float AnswerHeadAnlge = CalculateJointAngle(Answerhead.position, Answerneck.position, Answerchest.position);
      float AnswerChestAngle = CalculateJointAngle(AnswerUpperChest.position, Answerchest.position, Answerspine.position);
      /*
      float AnswerleftShoulderAngle = CalculateJointAngle(AnswerleftUpperArm, AnswerleftShoulder, Answerchest);
      float AnswerrightShoulderAngle = CalculateJointAngle(AnswerrightUpperArm, AnswerrightShoulder, Answerchest);
      float AnswerleftUpperArmAngle = CalculateJointAngle(AnswerleftShoulder, AnswerleftUpperArm, AnswerleftLowerArm);
      float AnswerrightUpperArmAngle = CalculateJointAngle(AnswerrightShoulder, AnswerrightUpperArm, AnswerrightLowerArm);
      float AnswerleftForeArmAngle = CalculateJointAngle(AnswerleftUpperArm, AnswerleftLowerArm, AnswerleftHand);
      float AnswerrightForeArmAngle = CalculateJointAngle(AnswerrightUpperArm, AnswerrightLowerArm, AnswerrightHand);
      float AnswerleftHandAngle = CalculateJointAngle(AnswerleftLowerArm, AnswerleftHand, AnswerleftHandIndex);
      float AnswerrightHandAngle = CalculateJointAngle(AnswerrightLowerArm, AnswerrightHand, AnswerrightHandIndex);
      float AnswerleftLegAngle = 180 - CalculateJointAngle(Answerhip, AnswerleftUpperLeg, AnswerleftLowerLeg);
      float AnswerleftlowerlegAngle = 180 - CalculateJointAngle(AnswerleftUpperLeg, AnswerleftLowerLeg, AnswerleftFoot);
      float AnswerrightLegAngle = 180 - CalculateJointAngle(Answerhip, AnswerrightUpperLeg, AnswerrightLowerLeg);
      float AnswerrightlowerLegAngle = 180 - CalculateJointAngle(AnswerrightUpperLeg, AnswerrightLowerLeg, AnswerrightFoot);
      float AnswerleftFootAngle = 180 - CalculateJointAngle(AnswerleftLowerLeg, AnswerleftFoot, AnswerleftFootToe);
      float AnswerrightFootAngle = 180 - CalculateJointAngle(AnswerrightLowerLeg, AnswerrightFoot, AnswerrightFootToe);
      float AnswerHeadAnlge = CalculateJointAngle(Answerhead, Answerneck, Answerchest);
      float AnswerChestAngle = CalculateJointAngle(AnswerUpperChest, Answerchest, Answerspine);
      */

      // 정답과 사용자 간 각도 비교
      // 왼/오 팔
      float leftShoulderAngleDifference = Mathf.Abs(AnswerleftShoulderAngle - leftShoulderAngle);
      float rightShoulderAngleDifference = Mathf.Abs(AnswerrightShoulderAngle - rightShoulderAngle);
      float leftUpperArmAngleDifference = Mathf.Abs(AnswerleftUpperArmAngle - leftUpperArmAngle);
      float rightUpperArmAngleDifferece = Mathf.Abs(AnswerrightUpperArmAngle - rightUpperArmAngle);
      float leftForeArmAngleDifference = Mathf.Abs(AnswerleftForeArmAngle - leftForeArmAngle);
      float rightForeArmAngleDifference = Mathf.Abs(AnswerrightForeArmAngle - rightForeArmAngle);
      float leftHandAngleDifference = Mathf.Abs(AnswerleftHandAngle - leftHandAngle);
      float rightHandAngleDifference = Mathf.Abs(AnswerrightHandAngle - rightHandAngle);
      // 왼/오 다리
      float leftLegAngleDifference = Mathf.Abs(AnswerleftLegAngle - leftLegAngle);
      float rightLegAngleDifference = Mathf.Abs(AnswerrightLegAngle - rightLegAngle);
      float leftlowerLegAngleDifference = Mathf.Abs(AnswerleftlowerlegAngle - leftlowerlegAngle);
      float rightlowerLegAngleDifference = Mathf.Abs(AnswerrightlowerLegAngle - rightlowerLegAngle);
      // 상체
      float SpineAngleDifference = Mathf.Abs(AnswerChestAngle - ChestAngle);
      float HeadAngleDifference = Mathf.Abs(AnswerHeadAnlge - HeadAnlge);


      string angletext = $@"
    Head: {HeadAnlge}
    Chest : {ChestAngle}
    Left UpperArm: {leftUpperArmAngle}
    Left LowerArm: {leftForeArmAngle}
    Left Wrist: {leftHandAngle}
    Right UpperArm: {rightUpperArmAngle}
    Right LowerArm: {rightForeArmAngle}
    Right Wrist: {rightHandAngle}
    Left UpperLeg: {leftLegAngle}
    Left LowerLeg: {leftlowerlegAngle}
    Left Foot: {AnswerleftFootAngle}
    Right UpperLeg: {rightLegAngle}
    Right LowerLeg: {rightlowerLegAngle}
    Right Foot: {AnswerrightFootAngle}";

      text.text = angletext;


      /*=======================팔 색상 변경 ============================*/


      // Left UpperArm
      if (leftUpperArmAngleDifference > 15)
      {
        Debug.Log("Left UpperArm Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[6] = newMaterial[0]; //M_LeftUpperarm = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < leftUpperArmAngleDifference && leftUpperArmAngleDifference < 15)
      {
        Debug.Log("Left UpperArm Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[6] = newMaterial[1]; //M_LeftUpperarm = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (leftUpperArmAngleDifference < 5)
      {
        Debug.Log("Left UpperArm Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[6] = newMaterial[2]; //M_LeftUpperarm = GREEN
            surface.materials = materials;
          }
        }
      }

      // Right UpperArm
      if (rightUpperArmAngleDifferece > 15)
      {
        Debug.Log("Right UpperArm Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[9] = newMaterial[0]; //M_RightUpperarm = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < rightUpperArmAngleDifferece && rightUpperArmAngleDifferece < 15)
      {
        Debug.Log("Right UpperArm Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[9] = newMaterial[1]; //M_RightUpperarm = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (rightUpperArmAngleDifferece < 5)
      {
        Debug.Log("Right UpperArm Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[9] = newMaterial[2]; //M_RightUpperarm = GREEN
            surface.materials = materials;
          }
        }
      }

      // Left FroeArm
      if (leftForeArmAngleDifference > 15)
      {
        Debug.Log("Left ForeArm Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[7] = newMaterial[0]; //M_LeftForeArm = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < leftForeArmAngleDifference && leftForeArmAngleDifference < 15)
      {
        Debug.Log("Left ForeArm Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[7] = newMaterial[1]; //M_LeftForeArm = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (leftForeArmAngleDifference < 5)
      {
        Debug.Log("Left ForeArm Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[7] = newMaterial[2]; //M_LeftForeArm = GREEN
            surface.materials = materials;
          }
        }
      }

      // Right Forearm
      if (rightForeArmAngleDifference > 15)
      {
        Debug.Log("Right ForeArm Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[10] = newMaterial[0]; //M_RightForeArm = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < rightForeArmAngleDifference && rightForeArmAngleDifference < 15)
      {
        Debug.Log("Right ForeArm Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[10] = newMaterial[1]; //M_RightForeArm = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (rightForeArmAngleDifference < 5)
      {
        Debug.Log("Right ForeArm Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[10] = newMaterial[2]; //M_RightForeArm = GREEN
            surface.materials = materials;
          }
        }
      }

      // Left Hand
      if (leftHandAngleDifference > 15)
      {
        Debug.Log("Left Hand Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[8] = newMaterial[0]; //M_LeftHand = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < leftHandAngleDifference && leftHandAngleDifference < 15)
      {
        Debug.Log("Left Hand Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[8] = newMaterial[1]; //M_LeftHand = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (leftHandAngleDifference < 5)
      {
        Debug.Log("Left Hand Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[8] = newMaterial[2]; //M_LeftHand = GREEN
            surface.materials = materials;
          }
        }
      }


      // Right Hand
      if (rightHandAngleDifference > 15)
      {
        Debug.Log("Right Hand Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[11] = newMaterial[0]; //M_rightHand = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < rightHandAngleDifference && rightHandAngleDifference < 15)
      {
        Debug.Log("Right Hand Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[11] = newMaterial[1]; //M_rightHand = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (rightHandAngleDifference < 5)
      {
        Debug.Log("Right Hand Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[11] = newMaterial[2]; //M_rightHand = GREEN
            surface.materials = materials;
          }
        }
      }



      /*=================다리 색상 변경 =====================*/

      // Left Upper LEG
      if (leftLegAngleDifference > 15)
      {
        Debug.Log("Left UpperLeg Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[3] = newMaterial[0]; //M_LeftUpperLeg = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < leftLegAngleDifference && leftLegAngleDifference < 15)
      {
        Debug.Log("Left UpperLeg Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[3] = newMaterial[1]; //M_LeftUpperLeg = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (leftLegAngleDifference < 5)
      {
        Debug.Log("Left UpperLeg Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[3] = newMaterial[2]; //M_LeftUpperLeg = GREEN
            surface.materials = materials;
          }
        }
      }

      // Right Upper Leg
      if (rightLegAngleDifference > 15)
      {
        Debug.Log("Right UpperLeg Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[14] = newMaterial[0]; //M_RightUpperLeg = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < rightLegAngleDifference && rightLegAngleDifference < 15)
      {
        Debug.Log("Right UpperLeg Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[14] = newMaterial[1]; //M_RightUpperLeg = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (rightLegAngleDifference < 5)
      {
        Debug.Log("Right UpperLeg Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[14] = newMaterial[2]; //M_RightUpperLeg = GREEN
            surface.materials = materials;
          }
        }
      }

      // Left Lower Leg
      if (leftlowerLegAngleDifference > 15)
      {
        Debug.Log("Left LowerLeg Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[5] = newMaterial[0]; //M_LeftLowerLeg = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < leftlowerLegAngleDifference && leftlowerLegAngleDifference < 15)
      {
        Debug.Log("Left LowerLeg Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[5] = newMaterial[1]; //M_LeftLowerLeg = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (leftlowerLegAngleDifference < 5)
      {
        Debug.Log("Left LowerLeg Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[5] = newMaterial[2]; //M_LeftLowerLeg = GREEN
            surface.materials = materials;
          }
        }
      }

      // Right Lower Leg
      if (rightlowerLegAngleDifference > 15)
      {
        Debug.Log("Right LowerLeg Color RED");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[13] = newMaterial[0]; //M_RightLowerLeg = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < rightlowerLegAngleDifference && rightlowerLegAngleDifference < 15)
      {
        Debug.Log("Right LowerLeg Color YELLOW");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[13] = newMaterial[1]; //M_RightLowerLeg = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (rightlowerLegAngleDifference < 5)
      {
        Debug.Log("Right LowerLeg Color GREEN");
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[13] = newMaterial[2]; //M_RightLowerLeg = GREEN
            surface.materials = materials;
          }
        }
      }

      /*상체 색상 변경*/
      // Chest
      if (SpineAngleDifference > 15)
      {
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[0] = newMaterial[0]; //M_Spine = RED
            materials[1] = newMaterial[0]; //M_Chest = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < SpineAngleDifference && SpineAngleDifference < 15)
      {
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[0] = newMaterial[1]; //M_Spine = YELLOW
            materials[1] = newMaterial[1]; //M_Chest = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (SpineAngleDifference < 5)
      {
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[0] = newMaterial[2]; //M_Spine = GREEN
            materials[1] = newMaterial[2]; //M_Chest = GREEN
            surface.materials = materials;
          }
        }
      }

      // Head
      if (HeadAngleDifference > 15)
      {
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[2] = newMaterial[0]; //M_Head = RED
            surface.materials = materials;
          }
        }
      }
      else if (5 < HeadAngleDifference && HeadAngleDifference < 15)
      {
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[2] = newMaterial[1]; //M_Head = YELLOW
            surface.materials = materials;
          }
        }
      }
      else if (HeadAngleDifference < 5)
      {
        if (surface != null && newMaterial != null)
        {
          Material[] materials = surface.materials;
          if (materials.Length > 0)
          {
            materials[2] = newMaterial[2]; //M_Head = GREEN
            surface.materials = materials;
          }
        }
      }



    }


    private float CalculateJointAngle(Vector3 A, Vector3 B, Vector3 C)
    {
      // 관절 사이의 벡터를 계산
      Vector3 AbVector;
      Vector3 BcVector;

      AbVector.x = B.x - A.x;
      AbVector.y = B.y - A.y;
      AbVector.z = B.z - A.z;

      BcVector.x = C.x - B.x;
      BcVector.y = C.y - B.y;
      BcVector.z = C.z - B.z;

      // 합 벡터의 방향을 정규화
      float AbNorm = (float)Mathf.Sqrt(AbVector.x * AbVector.x + AbVector.y * AbVector.y + AbVector.z * AbVector.z);
      float BcNorm = (float)Mathf.Sqrt(BcVector.x * BcVector.x + BcVector.y * BcVector.y + BcVector.z * BcVector.z);
      Vector3 AbVectorNorm;
      Vector3 BcVectorNorm;

      AbVectorNorm.x = AbVector.x / AbNorm;
      AbVectorNorm.y = AbVector.y / AbNorm;
      AbVectorNorm.z = AbVector.z / AbNorm;

      BcVectorNorm.x = BcVector.x / BcNorm;
      BcVectorNorm.y = BcVector.y / BcNorm;
      BcVectorNorm.z = BcVector.z / BcNorm;


      // 가운데 각도 계산
      float result = AbVectorNorm.x * BcVectorNorm.x + AbVectorNorm.y * BcVectorNorm.y + AbVectorNorm.z * BcVectorNorm.z;

      result = (float)Mathf.Acos(result) * 180.0f / 3.1415926535897f;
      return result;

    } 
  }
}
