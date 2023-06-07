using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MHController : MonoBehaviour
{
  public List<Transform> cubes;

  public Animator animator;
  private Transform hip;
  private Transform leftUpperLeg;
  private Transform rightUpperLeg;
  private Transform leftLowerLeg;
  private Transform rightLowerLeg;
  //private Transform leftFoot;
  //private Transform rightFoot;
  private Transform spine;
  private Transform chest;
  private Transform neck;
  private Transform head;
  private Transform leftShoulder;
  private Transform rightShoulder;
  private Transform leftUpperArm;
  private Transform rightUpperArm;
  private Transform leftLowerArm;
  private Transform rightLowerArm;
  //private Transform leftHand;
  //private Transform rightHand;

  public Transform botBody;

  // Start is called before the first frame update
  void Start()
  {
    hip = animator.GetBoneTransform(HumanBodyBones.Hips);
    leftUpperLeg = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
    rightUpperLeg = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
    leftLowerLeg = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
    rightLowerLeg = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
    //leftFoot        = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
    //rightFoot       = animator.GetBoneTransform(HumanBodyBones.RightFoot);
    spine = animator.GetBoneTransform(HumanBodyBones.Spine);
    chest = animator.GetBoneTransform(HumanBodyBones.Chest);
    neck = animator.GetBoneTransform(HumanBodyBones.Neck);
    head = animator.GetBoneTransform(HumanBodyBones.Head);
    leftShoulder = animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
    rightShoulder = animator.GetBoneTransform(HumanBodyBones.RightShoulder);
    leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
    rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
    leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
    rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
    //leftHand        = animator.GetBoneTransform(HumanBodyBones.LeftHand);
    //rightHand       = animator.GetBoneTransform(HumanBodyBones.RightHand);
  }



  // Update is called once per frame
  void FixedUpdate()
  {
    if (cubes.Count > 16)
    {
      Debug.Log("hello");
      // hip - point 1,0,4
      // rotate 90 degree
      Vector3 temp = cubes[1].position - cubes[0].position;
      temp = Vector3.ProjectOnPlane(temp, hip.up);
      temp = Quaternion.AngleAxis(270, hip.up) * temp;
      hip.rotation = Quaternion.LookRotation(temp, hip.up);

      // right upper leg connect hip - point 1 2
      rightUpperLeg.rotation = Quaternion.LookRotation(rightUpperLeg.forward, cubes[2].position - cubes[1].position);

      // left upper leg connect hip - point 4 5
      leftUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, cubes[5].position - cubes[4].position);

      // right lower leg connet upper - point 2 3
      rightLowerLeg.rotation = Quaternion.LookRotation(rightLowerLeg.forward, cubes[3].position - cubes[2].position);

      // left lower leg connect upper - point 5 6
      leftLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, cubes[6].position - cubes[5].position);

      // spine and hip(lower body) - point 0 7
      spine.rotation = Quaternion.LookRotation(spine.forward, cubes[7].position - cubes[0].position);

      // chest and spine - point 7 8
      chest.rotation = Quaternion.LookRotation(chest.forward, cubes[8].position - cubes[7].position);

      // right shoulder - point 8 14
      rightShoulder.rotation = Quaternion.LookRotation(rightShoulder.forward, cubes[14].position - cubes[8].position);

      // left shoulder - point 8 11
      leftShoulder.rotation = Quaternion.LookRotation(leftShoulder.forward, cubes[11].position - cubes[8].position);

      // right upper arm - point 14 15
      temp = cubes[15].position - cubes[14].position;
      rightUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightUpperArm.right, temp), temp);

      // left upper arm - point 12 11
      temp = cubes[12].position - cubes[11].position;
      leftUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftUpperArm.right, temp), temp);

      // right lower arm - point 15 16
      temp = cubes[16].position - cubes[15].position;
      rightLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightLowerArm.right, temp), temp);

      // left lower arm - point 13 12
      temp = cubes[13].position - cubes[12].position;
      leftLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftLowerArm.right, temp), temp);

      // neck - point 9 8
      neck.rotation = Quaternion.LookRotation(neck.forward, cubes[9].position - cubes[8].position);

      // head - point 10 9
      head.rotation = Quaternion.LookRotation(head.forward);
    }
  }
  
}

