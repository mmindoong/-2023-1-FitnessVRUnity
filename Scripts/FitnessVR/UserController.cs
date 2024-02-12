using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediapipe.Unity
{
  public class UserController : MonoBehaviour
  {
    public Animator animator;
    public PointAnnotation[] annotation;

    public GameObject PointObject;

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
    private Transform upperChest;

    public bool IsStarted = false;
    void Assign()
    {
      
      for (int i = 0; i < PointObject.transform.childCount; i++)
      {
        PointAnnotation component = PointObject.transform.GetChild(i).GetComponent<PointAnnotation>();
        annotation[i] = component;
      }
    }
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

      Invoke("Assign", 2); // 2초뒤 함수 호출

    }

    public void ClickStartButton()
    {
      IsStarted = true;
    }
      // Update is called once per frame
      void Update()
    {
      //Input.GetKeyUp(KeyCode.Escape)
      //annotation.Length > 33
      if (IsStarted)
      {

        for (int i = 0; i < annotation.Length; i++)
        {

          // hip - point RightUpeerLeg, Hip
          // rotate 90 degree
          Vector3 hipMediapipe = (((annotation[11].GetTransform() + annotation[23].GetTransform()) / 2.0f) + ((annotation[12].GetTransform() + annotation[24].GetTransform()) / 2.0f)) / 2.0f;
          Vector3 temp2 = annotation[24].GetTransform() - hipMediapipe;
          temp2 = Vector3.ProjectOnPlane(temp2, hip.up);
          temp2 = Quaternion.AngleAxis(270, hip.up) * temp2;
          hip.rotation = Quaternion.LookRotation(temp2, hip.up);
          hip.position = (annotation[11].gameObject.transform.position);
          hip.position += new Vector3(2, 0, 0);
          
          head.rotation = Quaternion.LookRotation(head.forward, annotation[0].GetTransform() - (annotation[9].GetTransform()+annotation[10].GetTransform())/2 );

          //Vector3 direction = new Vector3(-90, 0, 0); // 이 벡터를 향하도록 객체를 회전시킵니다.
          //hip.rotation = Quaternion.LookRotation(direction);

          // spine and hip(lower body) - point Hip, Spine
          Vector3 ChestMediapipe = (annotation[11].GetTransform() + annotation[12].GetTransform()) / 2.0f;
          chest.rotation = Quaternion.LookRotation(chest.forward, ChestMediapipe - hipMediapipe);
          spine.rotation = Quaternion.LookRotation(spine.forward, ChestMediapipe - hipMediapipe);

          // LEFT(홀수, 주황)
          // Left Leg
          // left upper leg connect hip - point LeftUpperLeg, LeftLowerLeg
          leftUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, annotation[25].GetTransform() - annotation[23].GetTransform());
          // left lower leg connect upper - point LeftLowerLeg, LeftFoot
          leftLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, annotation[27].GetTransform() - annotation[25].GetTransform());
          leftFoot.rotation = Quaternion.LookRotation(leftFoot.forward, annotation[31].GetTransform() - annotation[27].GetTransform());
          leftFootToe.position = (annotation[31].gameObject.transform.position);


          // left shoulder - point 8 11
          leftShoulder.rotation = Quaternion.LookRotation(leftShoulder.forward, annotation[11].GetTransform() - annotation[12].GetTransform());
          // left upper arm - point 12 11
          Vector3 temp = annotation[13].GetTransform() - annotation[11].GetTransform();
          leftUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftUpperArm.right, temp), temp);

          // left lower arm - point 13 12
          temp = annotation[15].GetTransform() - annotation[13].GetTransform();
          leftLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(leftLowerArm.right, temp), temp);
          // Right(짝수, 파랑)
          // Right Leg
          // right upper leg connect hip - point righttUpperLeg, rightLowerLeg
          rightUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, annotation[26].GetTransform() - annotation[24].GetTransform());
          // right lower leg connect upper - point rightLowerLeg, rightFoot
          rightLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, annotation[28].GetTransform() - annotation[26].GetTransform());
          rightFoot.rotation = Quaternion.LookRotation(rightFoot.forward, annotation[32].GetTransform() - annotation[28].GetTransform());
          rightFootToe.position = (annotation[32].gameObject.transform.position);

          // right shoulder - point 8 14
          rightShoulder.rotation = Quaternion.LookRotation(rightShoulder.forward, annotation[12].GetTransform() - annotation[11].GetTransform());

          // right upper arm - point 14 15
          temp = annotation[14].GetTransform() - annotation[12].GetTransform();
          rightUpperArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightUpperArm.right, temp), temp);
          // right lower arm - point 15 16
          temp = annotation[16].GetTransform() - annotation[14].GetTransform();
          rightLowerArm.rotation = Quaternion.LookRotation(Vector3.Cross(rightLowerArm.right, temp), temp);


        }
      }
    }
  }
}
