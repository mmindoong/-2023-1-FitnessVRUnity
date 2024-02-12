using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediapipe.Unity
{
  public class mediapipecontroller : MonoBehaviour
  {
    public Animator animator;
    public PointAnnotation[] annotation;

    public GameObject PointObject;
    public Vector3 sPos = new Vector3(0.0f, -44.31f, 84.96f);
    private Transform hip;
    private Transform leftUpperLeg;
    private Transform rightUpperLeg;
    private Transform leftLowerLeg;
    private Transform rightLowerLeg;
    private Transform leftFoot;
    private Transform rightFoot;
    private Transform chest;
    private Transform spine;
  
    private Transform neck;
    private Transform head;

    private Transform leftShoulder;
    private Transform rightShoulder;
    private Transform leftUpperArm;
    private Transform rightUpperArm;
    private Transform leftLowerArm;
    private Transform rightLowerArm;

    void Assign()
    {
      Debug.Log("Num Of Children " + PointObject.transform.childCount);
      Vector3 offset = new Vector3(0.0f, -91.81f, 174.96f);
      for (int i = 0; i < PointObject.transform.childCount; i++)
      {
        PointAnnotation component = PointObject.transform.GetChild(i).GetComponent<PointAnnotation>();
        annotation[i] = component;
      }
      PointObject.transform.position += sPos;
      //PointObject.transform.position = offset;

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
      spine = animator.GetBoneTransform(HumanBodyBones.Spine);

      chest = animator.GetBoneTransform(HumanBodyBones.Chest);
      hip = animator.GetBoneTransform(HumanBodyBones.Hips);

      head = animator.GetBoneTransform(HumanBodyBones.Head);
      leftShoulder = animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
      rightShoulder = animator.GetBoneTransform(HumanBodyBones.RightShoulder);

      leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
      rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
      leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
      rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);

      Invoke("Assign", 2); // 2초뒤 함수 호출
    }

    public void ClickPoseDetection()
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

       // Vector3 direction = new Vector3(-90, 0, 0); // 이 벡터를 향하도록 객체를 회전시킵니다.
       // hip.rotation = Quaternion.LookRotation(direction);

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
    // Update is called once per frame
    void Update()
    {
     
        //Input.GetKeyUp(KeyCode.Escape)
        //annotation.Length > 33
        if (Input.GetKeyUp(KeyCode.Escape))
      {
        
        for (int i=0; i< annotation.Length; i++)
        {

          // hip - point RightUpeerLeg, Hip
          // rotate 90 degree
          Vector3 hipMediapipe = (((annotation[11].GetTransform() + annotation[23].GetTransform())/2.0f) + ((annotation[12].GetTransform() + annotation[24].GetTransform())/2.0f)) / 2.0f;
          Vector3 temp2 = annotation[24].GetTransform() - hipMediapipe;
          temp2 = Vector3.ProjectOnPlane(temp2, hip.up);
          temp2 = Quaternion.AngleAxis(270, hip.up) * temp2;
          hip.rotation = Quaternion.LookRotation(temp2, hip.up);
          hip.position = (annotation[11].gameObject.transform.position);

          

          // spine and hip(lower body) - point Hip, Spine
          //Vector3 ChestMediapipe = (annotation[11].GetTransform() + annotation[12].GetTransform()) / 2.0f;
          //chest.rotation = Quaternion.LookRotation(chest.forward, ChestMediapipe - hipMediapipe);
          //spine.rotation = Quaternion.LookRotation(spine.forward, ChestMediapipe - hipMediapipe);
          //Vector3 direction = new Vector3(90, 0, 0); // 이 벡터를 향하도록 객체를 회전시킵니다.
          //hip.rotation = Quaternion.LookRotation(direction);
          // LEFT(홀수, 주황)
          // Left Leg
          // left upper leg connect hip - point LeftUpperLeg, LeftLowerLeg
          leftUpperLeg.rotation = Quaternion.LookRotation(leftUpperLeg.forward, annotation[25].GetTransform() - annotation[23].GetTransform());
          // left lower leg connect upper - point LeftLowerLeg, LeftFoot
          leftLowerLeg.rotation = Quaternion.LookRotation(leftLowerLeg.forward, annotation[27].GetTransform() - annotation[25].GetTransform());
          leftFoot.rotation = Quaternion.LookRotation(leftFoot.forward, annotation[31].GetTransform() - annotation[27].GetTransform());

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
