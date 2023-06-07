using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleClassfication : MonoBehaviour
{
  public Animator animator;
  public Animator AnswerAnimator;

  public SkinnedMeshRenderer surface;
  public Material[] newMaterial;

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

  

  // Start is called before the first frame update


  void Start()
    {
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
    leftHandIndex =animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
    rightHandIndex = animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);

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


  }

    // Update is called once per frame
    void Update()
    {
      
    float leftShoulderAngle = CalculateJointAngle(leftUpperArm.position, leftShoulder.position, chest.position);
    float rightShoulderAngle = CalculateJointAngle(rightUpperArm.position, rightShoulder.position, chest.position);
    float leftUpperArmAngle = CalculateJointAngle(leftShoulder.position, leftUpperArm.position, leftLowerArm.position);
    float rightUpperArmAngle = CalculateJointAngle(rightShoulder.position, rightUpperArm.position, rightLowerArm.position);
    float leftForeArmAngle = CalculateJointAngle(leftUpperArm.position, leftLowerArm.position, leftHand.position);
    float rightForeArmAngle = CalculateJointAngle(rightUpperArm.position, rightLowerArm.position, rightHand.position);
    float leftHandAngle = CalculateJointAngle(leftLowerArm.position, leftHand.position, leftHandIndex.position);
    float rightHandAngle = CalculateJointAngle(rightLowerArm.position, rightHand.position, rightHandIndex.position);
    float leftLegAngle =  180 - CalculateJointAngle(hip.position, leftUpperLeg.position, leftLowerLeg.position);
    float rightLegAngle = 180- CalculateJointAngle(hip.position, rightUpperLeg.position, rightLowerLeg.position);
    float leftlowerlegAngle = 180 - CalculateJointAngle(leftUpperLeg.position, leftLowerLeg.position, leftFoot.position);
    float rightlowerLegAngle = 180 - CalculateJointAngle(rightUpperLeg.position, rightLowerLeg.position, rightFoot.position);


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


    // 정답과 사용자 간 각도 비교
    float leftShoulderAngleDifference = Mathf.Abs(AnswerleftShoulderAngle - leftShoulderAngle);
    float rightShoulderAngleDifference = Mathf.Abs(AnswerrightShoulderAngle - rightShoulderAngle);
    float leftUpperArmAngleDifference = Mathf.Abs(AnswerleftUpperArmAngle - leftUpperArmAngle);
    float rightUpperArmAngleDifferece = Mathf.Abs(AnswerrightUpperArmAngle - rightUpperArmAngle);
    float leftForeArmAngleDifference = Mathf.Abs(AnswerleftForeArmAngle - leftForeArmAngle);
    float rightForeArmAngleDifference = Mathf.Abs(AnswerrightForeArmAngle - rightForeArmAngle);
    float leftHandAngleDifference = Mathf.Abs(AnswerleftHandAngle - leftHandAngle);
    float rightHandAngleDifference = Mathf.Abs(AnswerrightHandAngle - rightHandAngle);
    float leftLegAngleDifference = Mathf.Abs(AnswerleftLegAngle - leftLegAngle);
    float rightLegAngleDifference = Mathf.Abs(AnswerrightLegAngle - rightLegAngle);
    float leftlowerLegAngleDifference = Mathf.Abs(AnswerleftlowerlegAngle - leftlowerlegAngle);
    float rightlowerLegAngleDifference = Mathf.Abs(AnswerrightlowerLegAngle - rightlowerLegAngle);


    /*=======================팔 색상 변경 ============================*/
    if (leftShoulderAngleDifference > 15)
    {
      Debug.Log("Left Shoulder Color RED");
      if(surface != null && newMaterial != null)
      {
        Material[] materials = surface.materials;
        if(materials.Length > 0)
        {
          materials[6] = newMaterial[0];
          surface.materials = materials;
        }
      }
    }
     
    else if (5 < leftShoulderAngleDifference && leftShoulderAngleDifference < 15)
      Debug.Log("Left Shoudler Color YELLOW");
    else if(leftShoulderAngleDifference < 5)
      Debug.Log("Left Shoudler Color GREEN");

    if (rightShoulderAngleDifference > 15)
      Debug.Log("Right Shoulder Color RED");
    else if (5 < rightShoulderAngleDifference && rightShoulderAngleDifference < 15)
      Debug.Log("Right Shoudler Color YELLOW");
    else if (rightShoulderAngleDifference < 5)
      Debug.Log("Right Shoudler Color GREEN");

    if (leftUpperArmAngleDifference > 15)
      Debug.Log("Left UpperArm Color RED");
    else if(5 < leftUpperArmAngleDifference && leftUpperArmAngleDifference < 15)
      Debug.Log("Left UpperArm Color YELLOW");
    else if(leftUpperArmAngleDifference < 5)
      Debug.Log("Left UpperArm Color GREEN");

    if (rightUpperArmAngleDifferece > 15)
      Debug.Log("Right UpperArm Color RED");
    else if (5 < rightUpperArmAngleDifferece && rightUpperArmAngleDifferece < 15)
      Debug.Log("Right UpperArm Color YELLOW");
    else if (rightUpperArmAngleDifferece < 5)
      Debug.Log("Right UpperArm Color GREEN");

    if(leftForeArmAngleDifference > 15)
      Debug.Log("Left ForeArm Color RED");
    else if(5 < leftForeArmAngleDifference && leftForeArmAngleDifference < 15)
      Debug.Log("Left ForeArm Color YELLOW");
    else if (leftForeArmAngleDifference < 5)
      Debug.Log("Left ForeArm Color GREEN");

    if(rightForeArmAngleDifference > 15)
      Debug.Log("Right ForeArm Color RED");
    else if(5 < rightForeArmAngleDifference && rightForeArmAngleDifference < 15)
      Debug.Log("Right ForeArm Color YELLOW");
    else if (rightForeArmAngleDifference < 5)
      Debug.Log("Right ForeArm Color GREEN");

    if (leftHandAngleDifference > 15)
      Debug.Log("Left Hand Color RED");
    else if(5 < leftHandAngleDifference && leftHandAngleDifference<15)
      Debug.Log("Left Hand Color YELLOW");
    else if(leftHandAngleDifference < 5)
      Debug.Log("Left Hand Color GREEN");

    if(rightHandAngleDifference > 15)
      Debug.Log("Right Hand Color RED");
    else if(5 < rightHandAngleDifference && rightHandAngleDifference < 15)
      Debug.Log("Right Hand Color YELLOW");
    else if (rightHandAngleDifference < 5)
      Debug.Log("Right Hand Color GREEN");


    /*=================다리 색상 변경 =====================*/
    if (leftLegAngleDifference > 15)
      Debug.Log("Left UpperLeg Color RED");
    else if(5 < leftLegAngleDifference && leftLegAngleDifference < 15)
      Debug.Log("Left UpperLeg Color YELLOW");
    else if(leftLegAngleDifference < 5)
      Debug.Log("Left UpperLeg Color GREEN");

    if (rightLegAngleDifference > 15)
      Debug.Log("Right UpperLeg Color RED");
    else if (5 < rightLegAngleDifference && rightLegAngleDifference < 15)
      Debug.Log("Right UpperLeg Color YELLOW");
    else if (rightLegAngleDifference < 5)
      Debug.Log("Right UpperLeg Color GREEN");

    if(leftlowerLegAngleDifference > 15)
      Debug.Log("Left LowerLeg Color RED");
    else if(5 < leftlowerLegAngleDifference && leftlowerLegAngleDifference < 15)
      Debug.Log("Left LowerLeg Color YELLOW");
    else if(leftlowerLegAngleDifference < 5)
      Debug.Log("Left LowerLeg Color GREEN");

    if(rightlowerLegAngleDifference > 15)
      Debug.Log("Right LowerLeg Color RED");
    else if(5 < rightlowerLegAngleDifference && rightlowerLegAngleDifference < 15)
      Debug.Log("Right LowerLeg Color YELLOW");
    else if(rightlowerLegAngleDifference < 5)
      Debug.Log("Right LowerLeg Color GREEN");







    /*
    // Check if it is the T pose.
    //Check if the both arms are straight.
    if (leftShoulderAngle > 80 && leftShoulderAngle < 110 && rightShoulderAngle > 80 && rightShoulderAngle < 110)
    {
      // Check if both legs are straight
      if (leftKneeAngle > 160 && leftKneeAngle < 195 && rightKneeAngle > 160 && rightKneeAngle < 195)
        Debug.Log("T-Pose");
    }
    */




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

    // 합 벡터의 방향을 정규화함
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
