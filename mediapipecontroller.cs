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
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyUp(KeyCode.Escape))
      {
        
        for (int i=0; i< annotation.Length; i++)
        {

          // hip - point RightUpeerLeg, Hip
          // rotate 90 degree
          Vector3 hipMediapipe = (((annotation[11].GetTransform() + annotation[23].GetTransform())/2.0f) + ((annotation[12].GetTransform() + annotation[24].GetTransform())/2.0f)) / 2.0f;
          //Vector3 temp = annotation[23].GetTransform() - hipMediapipe;
          //temp = Vector3.ProjectOnPlane(temp, hip.up);
          //hip.rotation = Quaternion.LookRotation(hip.right, hipMediapipe);

          Vector3 direction = new Vector3(-90, 0, 0); // 이 벡터를 향하도록 객체를 회전시킵니다.
          hip.rotation = Quaternion.LookRotation(direction);


          
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
    }
  }
}
