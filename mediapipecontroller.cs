using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediapipe.Unity
{
  public class mediapipecontroller : MonoBehaviour
  {
    public Animator animator;
    public PointAnnotation[] annotation;
    private Transform hip;
    private Transform leftUpperLeg;
    private Transform rightUpperLeg;
    private Transform leftLowerLeg;
    private Transform rightLowerLeg;
    private Transform leftFoot;
    private Transform rightFoot;
    private Transform spine;
    private Transform chest;
    private Transform neck;
    private Transform head;

    private Transform leftUpperArm;
    private Transform rightUpperArm;
    private Transform leftLowerArm;
    private Transform rightLowerArm;
    private Transform leftHand;
    private Transform rightHand;



    // Start is called before the first frame update
    void Start()
    {
      
      leftUpperLeg = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
      rightUpperLeg = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
      leftLowerLeg = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
      rightLowerLeg = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
      leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
      rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
      

      head = animator.GetBoneTransform(HumanBodyBones.Head);
      leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
      rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
      leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
      rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
      leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
      rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);

    }

    // Update is called once per frame
    void Update()
    {
      if (annotation.Length > 33)
      { 
        for (int i=0; i< annotation.Length; i++)
        {
          // LEFT(짝수)
          // Left Leg
          leftUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, annotation[23].GetTransform() - annotation[25].GetTransform());
          leftLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, annotation[25].GetTransform() - annotation[27].GetTransform() );

          // Left Arm
          //Vector3 temp = annotation[12].GetTransform() - annotation[14].GetTransform();
          //leftUpperArm.rotation = Quaternion.LookRotation(leftUpperArm.forward, temp);

          Vector3 temp = annotation[14].GetTransform() - annotation[16].GetTransform();
          leftLowerArm.rotation = Quaternion.LookRotation(leftLowerArm.forward, temp);

          //temp = annotation[16].GetTransform() - annotation[14].GetTransform();
          //leftHand.rotation = Quaternion.LookRotation(leftHand.forward, temp);

          // RIGHT(홀수)
          // Right Leg
          rightUpperLeg.rotation = Quaternion.LookRotation(rightUpperLeg.forward , annotation[24].GetTransform() - annotation[26].GetTransform());
          rightLowerLeg.rotation = Quaternion.LookRotation(rightLowerLeg.forward, annotation[26].GetTransform() - annotation[28].GetTransform() );

          // Right Arm 
          // 자기꺼 - 타겟꺼 => 타겟에서 자신에게향하는 벡터
          temp = annotation[11].GetTransform() - annotation[13].GetTransform();
          rightUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightUpperArm.right, temp), temp);
          
          //temp = annotation[13].GetTransform() - annotation[15].GetTransform();
          //rightLowerArm.rotation = Quaternion.LookRotation(rightLowerArm.forward, temp);

          //temp = annotation[13].GetTransform() - annotation[15].GetTransform();
          //rightHand.rotation = Quaternion.LookRotation(rightHand.forward,  temp);
          
        }
      }
    }
  }
}
