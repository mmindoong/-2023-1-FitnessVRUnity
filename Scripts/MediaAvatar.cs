using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mplt = Mediapipe.LocationData.Types;
using System.Text;

namespace Mediapipe.Unity
{
  public class MediaAvatar : MonoBehaviour
  {
    public PoseLandmarkListAnnotation MediaPipeLandmark;
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

    public GameObject RootPosition;
    public Transform CharacterRootTransform;
    public float OffsetY;
    public float OffsetZ;

    private List<List<Vector3>> points = new List<List<Vector3>>();
    List<Vector3> frame;
    private int frameIndex = 0;
    private int frameNum;
    private void Start()
    {
      animator = GetComponent<Animator>();
      Transform _rootJointTransform = CharacterRootTransform;
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



      for (int i = 0; i < (int)MediaPipeLandmark.GetLandmarkCount(); i++)
      {
        List<Vector3> frame = new List<Vector3>();

      }
      
      void FixedUpdate()
      { 
        // hip - point 1,0,4
        // rotate 90 degree
        Vector3 temp = frame[1] - frame[0];
        temp = Vector3.ProjectOnPlane(temp, hip.up);
        temp = Quaternion.AngleAxis(270, hip.up) * temp;
        hip.rotation = Quaternion.LookRotation(temp, hip.up);

        // right upper leg connect hip - point 1 2
        rightUpperLeg.rotation = Quaternion.LookRotation(rightUpperLeg.forward, frame[2] - frame[1]);

        // left upper leg connect hip - point 4 5
        leftUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, frame[5] - frame[4]);

        // right lower leg connet upper - point 2 3
        rightLowerLeg.rotation = Quaternion.LookRotation(rightLowerLeg.forward, frame[3] - frame[2]);

        // left lower leg connect upper - point 5 6
        leftLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, frame[6] - frame[5]);

        // spine and hip(lower body) - point 0 7
        spine.rotation = Quaternion.LookRotation(spine.forward, frame[7] - frame[0]);

        // chest and spine - point 7 8
        chest.rotation = Quaternion.LookRotation(chest.forward, frame[8] - frame[7]);

        // right shoulder - point 8 14
        rightShoulder.rotation = Quaternion.LookRotation(rightShoulder.forward, frame[14] - frame[8]);

        // left shoulder - point 8 11
        leftShoulder.rotation = Quaternion.LookRotation(leftShoulder.forward, frame[11] - frame[8]);

        // right upper arm - point 14 15
        temp = frame[15] - frame[14];
        rightUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightUpperArm.right, temp), temp);

        // left upper arm - point 12 11
        temp = frame[12] - frame[11];
        leftUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftUpperArm.right, temp), temp);

        // right lower arm - point 15 16
        temp = frame[16] - frame[15];
        rightLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightLowerArm.right, temp), temp);

        // left lower arm - point 13 12
        temp = frame[13] - frame[12];
        leftLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftLowerArm.right, temp), temp);

        // neck - point 9 8
        neck.rotation = Quaternion.LookRotation(neck.forward, frame[9] - frame[8]);

        // head - point 10 9
        head.rotation = Quaternion.LookRotation(head.forward);

        frameIndex++;
        if (frameIndex == frameNum)
        {
          frameIndex = 0;
        }
      }
      
    }
  }
}
