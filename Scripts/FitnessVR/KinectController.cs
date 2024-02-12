using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Mediapipe.Unity
{
  public class KinectController : MonoBehaviour
  {
    public Animator animator;
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
    private Transform leftShoulder;
    private Transform rightShoulder;
    private Transform leftUpperArm;
    private Transform rightUpperArm;
    private Transform leftLowerArm;
    private Transform rightLowerArm;
    private Transform leftHand;
    private Transform rightHand;
    private Transform leftHandIndex;
    private Transform rightHandIndex;
    private Transform leftFootToe;
    private Transform rightFootToe;
    private Transform upperChest;


    public GameObject KinectTracker;
    public Transform Kinecthip;
    public Transform KinectleftUpperLeg;
    public Transform KinectrightUpperLeg;
    public Transform KinectleftLowerLeg;
    public Transform KinectrightLowerLeg;
    public Transform KinectleftFoot;
    public Transform KinectrightFoot;
    public Transform Kinectspine;
    public Transform Kinectchest;
    public Transform Kinectneck;
    public Transform Kinecthead;
    public Transform KinectleftShoulder;
    public Transform KinectrightShoulder;
    public Transform KinectleftUpperArm;
    public Transform KinectrightUpperArm;
    public Transform KinectleftLowerArm;
    public Transform KinectrightLowerArm;
    public Transform KinectleftHand;
    public Transform KinectrightHand;
    public Transform KinectleftHandIndex;
    public Transform KinectrightHandIndex;
    public Transform KinectleftFootToe;
    public Transform KinectrightFootToe;
    public Transform KinectupperChest;

    public bool IsStarted = false;
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
      leftHandIndex = animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
      rightHandIndex = animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
      leftFootToe = animator.GetBoneTransform(HumanBodyBones.LeftToes);
      rightFootToe = animator.GetBoneTransform(HumanBodyBones.RightToes);
      upperChest = animator.GetBoneTransform(HumanBodyBones.UpperChest);
      neck = animator.GetBoneTransform(HumanBodyBones.Neck);
    }

    public void ClickStartButton()
    {
      IsStarted = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (IsStarted)
      {
        //leftUpperLeg.position = KinectleftUpperLeg.position;
        //rightUpperLeg.position = KinectrightUpperLeg.position;
        //leftLowerLeg.position = KinectleftLowerLeg.position;
        //rightLowerLeg.position = KinectrightLowerLeg.position;
        //leftFoot.position = KinectleftFoot.position;
        //rightFoot.position = KinectrightFoot.position;
        //chest.position = Kinectchest.position;
        //hip.position = Kinecthip.position;
        //spine.position = Kinectspine.position;
        //head.position = Kinecthead.position;
        //leftShoulder.position = KinectleftShoulder.position;
        //rightShoulder.position = KinectrightShoulder.position;
        //leftUpperArm.position = KinectleftUpperArm.position;
        //rightUpperArm.position = KinectrightUpperArm.position;
        //leftLowerArm.position = KinectleftLowerArm.position;
        //rightLowerArm.position = KinectrightLowerArm.position;
        //leftHand.position = KinectleftHand.position;
        //rightHand.position = KinectrightHand.position;
        //leftHandIndex.position = KinectleftHandIndex.position;
       // rightHandIndex.position = KinectrightHandIndex.position;
       // leftFootToe.position = KinectleftFootToe.position;
       // rightFootToe.position = KinectrightFootToe.position;
        //upperChest.position = KinectupperChest.position;
        //neck.position = Kinectneck.position;



        // hip - point 1,0,4
        // rotate 90 degree
        Vector3 temp = KinectrightUpperLeg.position - Kinecthip.position;
        temp = Vector3.ProjectOnPlane(temp, hip.up);
        temp = Quaternion.AngleAxis(270, hip.up) * temp;
        hip.rotation = Quaternion.LookRotation(temp, hip.up);
        hip.position = Kinecthip.position;

        // 왼다리
        
        leftFoot.position = KinectleftFoot.position;

        leftUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, KinectleftLowerLeg.position - KinectleftUpperLeg.position);
        leftLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, KinectleftFoot.position - KinectleftLowerLeg.position);
        leftFoot.rotation = Quaternion.LookRotation(leftLowerLeg.forward, KinectleftFootToe.position - KinectleftFoot.position);
        

        // 오른 다리
       
        rightFoot.position = KinectrightFoot.position;
        rightUpperLeg.rotation = Quaternion.LookRotation(rightUpperLeg.forward, KinectrightLowerLeg.position - KinectrightUpperLeg.position);
        rightLowerLeg.rotation = Quaternion.LookRotation(rightLowerLeg.forward, KinectrightFoot.position - KinectrightLowerLeg.position);
        rightFoot.rotation = Quaternion.LookRotation(rightLowerLeg.forward, KinectrightFootToe.position - KinectrightFoot.position);


        // 상체
        spine.rotation = Quaternion.LookRotation(spine.forward, Kinectspine.position - Kinecthip.position);
        chest.rotation = Quaternion.LookRotation(chest.forward, Kinectchest.position - Kinectspine.position);
        neck.rotation = Quaternion.LookRotation(neck.forward, Kinectneck.position - Kinectchest.position);
        head.rotation = Quaternion.LookRotation(head.forward, Kinecthead.position - Kinectneck.position);
        spine.position = Kinectspine.position;
        chest.position = Kinectchest.position;

        // 오른 팔
        rightShoulder.rotation = Quaternion.LookRotation(rightShoulder.forward, KinectrightShoulder.position - KinectleftShoulder.position);
        temp = KinectrightLowerArm.position - KinectrightUpperArm.position;
        rightUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightUpperArm.right, temp), temp);
        temp = KinectrightHand.position - KinectrightLowerArm.position;
        rightLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightLowerArm.right, temp), temp);
        temp = KinectrightHandIndex.position - KinectrightHand.position;
        rightHand.rotation = Quaternion.LookRotation(Vector3.Cross(rightHand.right, temp), temp);

        // 왼팔
        leftShoulder.rotation = Quaternion.LookRotation(leftShoulder.forward, KinectleftShoulder.position - KinectrightShoulder.position);
        temp = KinectleftLowerArm.position - KinectleftUpperArm.position;
        leftUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftUpperArm.right, temp), temp);
        temp = KinectleftHand.position - KinectleftLowerArm.position;
        leftLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftLowerArm.right, temp), temp);
        temp = KinectleftHandIndex.position - KinectleftHand.position;
        leftHand.rotation = Quaternion.LookRotation(Vector3.Cross(leftHand.right, temp), temp);


        

      }
    }
  }
}

