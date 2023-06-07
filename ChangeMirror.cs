using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMirror : MonoBehaviour
{
   public Camera MirrorFront;
  public Camera MirrorRight;
  public Camera MirrorTop;
  public Camera MirrorLeft;
   public Animator animator;

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
  private Transform upperChest;
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
    chest = animator.GetBoneTransform(HumanBodyBones.Chest);
    upperChest = animator.GetBoneTransform(HumanBodyBones.UpperChest);
    hip = animator.GetBoneTransform(HumanBodyBones.Hips);
    neck = animator.GetBoneTransform(HumanBodyBones.Neck);
    head = animator.GetBoneTransform(HumanBodyBones.Head);
    leftShoulder = animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
    rightShoulder = animator.GetBoneTransform(HumanBodyBones.RightShoulder);
    spine = animator.GetBoneTransform(HumanBodyBones.Spine);

    leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
    rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
    leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
    rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);

  }

    // Update is called once per frame
    void Update()
    {
      // 판정하는 2차원 좌표축
      // Front(정면) : XY, Back(후면) : XY
      // RightSide (측면) : YZ, LeftSize (좌측면) :YZ
      // TOP (항공) : ZX 
      if(Input.GetKeyUp(KeyCode.Space))
      {
        
      // Joint Position x, y, z for LeftLowerLeg,LeftFoot,LeftUpperLeg
      float LeftLowerLegX = leftLowerLeg.transform.position.x;
      float LeftLowerLegY = leftLowerLeg.transform.position.y;
      float LeftLowerLegZ = leftLowerLeg.transform.position.z;
      float LeftFootX = leftFoot.transform.position.x;
      float LeftFootY = leftFoot.transform.position.y;
      float LeftFootZ = leftFoot.transform.position.z;
      float LeftUpperLegX = leftUpperLeg.transform.position.x;
      float LeftUpperLegY = leftUpperLeg.transform.position.y;
      float LeftUpperLegZ = leftUpperLeg.transform.position.z;
      // 판정하는 부위(1) : LEFT LEG
      // 같은 부위에 대해 총 3가지 view Projection(XY, ZY, XZ)으로 거리를 구함
      float XYProjLeftLowerLegToFootDistance = Mathf.Abs((Mathf.Pow((LeftLowerLegX - LeftFootX), 2) - Mathf.Pow((LeftLowerLegY - LeftFootY), 2))) * 100;
      float ZYProjLeftLowerLegToFootDistnace = Mathf.Abs((Mathf.Pow((LeftLowerLegZ - LeftFootZ), 2) - Mathf.Pow((LeftLowerLegY - LeftFootY), 2))) * 100;
      float XZProjLeftLowerLegToFootDistance = Mathf.Abs((Mathf.Pow((LeftLowerLegX - LeftFootX), 2) - Mathf.Pow((LeftLowerLegZ - LeftFootZ), 2))) * 100;
      float XYProjLeftUpperLegToLowerLegDistance = Mathf.Abs(Mathf.Pow((LeftUpperLegX - LeftLowerLegX), 2) - Mathf.Pow((LeftUpperLegY - LeftLowerLegY), 2)) * 100;
      float ZYProjLeftUpperLegToLowerLegDistance = Mathf.Abs(Mathf.Pow((LeftUpperLegZ - LeftLowerLegZ), 2) - Mathf.Pow((LeftUpperLegY - LeftLowerLegY), 2)) * 100;
      float XZProjLeftUpperLegToLowerLegDistance = Mathf.Abs(Mathf.Pow((LeftUpperLegX - LeftLowerLegX), 2) - Mathf.Pow((LeftUpperLegZ - LeftLowerLegZ), 2)) * 100;

      // Joint Position x, y, z for RightLowerLeg,RightFoot,RightUpperLeg
      float RightLowerLegX = rightLowerLeg.transform.position.x;
      float RightLowerLegY = rightLowerLeg.transform.position.y;
      float RightLowerLegZ = rightLowerLeg.transform.position.z;
      float RightFootX = rightFoot.transform.position.x;
      float RightFootY = rightFoot.transform.position.y;
      float RightFootZ = rightFoot.transform.position.z;
      float RightUpperLegX = rightUpperLeg.transform.position.x;
      float RightUpperLegY = rightUpperLeg.transform.position.y;
      float RightUpperLegZ = rightUpperLeg.transform.position.z;
      // 판정하는 부위(2) : RIGHT LEG
      float XYProjRightLowerToFootDistance = Mathf.Abs((Mathf.Pow((RightLowerLegX - RightFootX), 2) - Mathf.Pow((RightLowerLegY - RightFootY), 2))) * 100;
      float ZYProjRightLowerLegToFootDistnace = Mathf.Abs((Mathf.Pow((RightLowerLegZ - RightFootZ), 2) - Mathf.Pow((RightLowerLegY - RightFootY), 2))) * 100;
      float XZProjRightLowerLegToFootDistance = Mathf.Abs((Mathf.Pow((RightLowerLegX - RightFootX), 2) - Mathf.Pow((RightLowerLegZ - RightFootZ), 2))) * 100;
      float XYProjRightUpperLegToLowerLegDistance = Mathf.Abs(Mathf.Pow((RightUpperLegX - RightLowerLegX), 2) - Mathf.Pow((RightUpperLegY - RightLowerLegY), 2)) * 100;
      float ZYProjRightUpperLegToLowerLegDistance = Mathf.Abs(Mathf.Pow((RightUpperLegZ - RightLowerLegZ), 2) - Mathf.Pow((RightUpperLegY - RightLowerLegY), 2)) * 100;
      float XZProjRightUpperLegToLowerLegDistance = Mathf.Abs(Mathf.Pow((RightUpperLegX - RightLowerLegX), 2) - Mathf.Pow((RightUpperLegZ - RightLowerLegZ), 2)) * 100;

      // Joint Position x, y, z for UpperChest, chest, spine
      float SpineX = spine.transform.position.x;
      float SpineY = spine.transform.position.y;
      float SpineZ = spine.transform.position.z;
      float ChestX = chest.transform.position.x;
      float ChestY = chest.transform.position.y;
      float ChestZ = chest.transform.position.z;
      float UpperChestX = upperChest.transform.position.x;
      float UpperChestY = upperChest.transform.position.y;
      float UpperChestZ = upperChest.transform.position.z;
      // 판정하는 부위(3) : CHEST
      float XYProjUpperChestToChestDistance = Mathf.Abs(Mathf.Pow((UpperChestX - ChestX) , 2) - Mathf.Pow((UpperChestY - ChestY) , 2)) * 100;
      float ZYProjUpperChestToChestDistance = Mathf.Abs(Mathf.Pow((UpperChestZ - ChestZ), 2) - Mathf.Pow((UpperChestY - ChestY), 2)) * 100;
      float XZProjUpperChestToChestDistance = Mathf.Abs(Mathf.Pow((UpperChestX - ChestX), 2) - Mathf.Pow((UpperChestZ - ChestZ), 2)) * 100;
      float XYProjChestToSpineDistance = Mathf.Abs(Mathf.Pow((ChestX - SpineX), 2) - Mathf.Pow((ChestY - SpineY), 2)) * 100;
      float ZYProjChestToSpineDistance = Mathf.Abs(Mathf.Pow((ChestZ - SpineZ), 2) - Mathf.Pow((ChestY - SpineY), 2)) * 100;
      float XZProjChestToSpineDistance = Mathf.Abs(Mathf.Pow((ChestX - SpineX), 2) - Mathf.Pow((ChestZ - SpineZ), 2)) * 100;

      // Joint Position x, y, z for LeftShoudler, LeftUpperArm, LeftLowerArm
      float LeftShoulderX = leftShoulder.transform.position.x;
      float LeftShoulderY = leftShoulder.transform.position.y;
      float LeftShoulderZ = leftShoulder.transform.position.z;
      float LeftUpperArmX = leftUpperArm.transform.position.x;
      float LeftUpperArmY = leftUpperArm.transform.position.y;
      float LeftUpperArmZ = leftUpperArm.transform.position.z;
      float LeftLowerArmX = leftLowerArm.transform.position.x;
      float LeftLowerArmY = leftLowerArm.transform.position.y;
      float LeftLowerArmZ = leftLowerArm.transform.position.z;
      // 판정하는 부위(4) : LEFT ARM
      float XYProjLeftShoulderToLeftUpperArmDistance = Mathf.Abs(Mathf.Pow((LeftShoulderX - LeftUpperArmX), 2) - Mathf.Pow((LeftShoulderY - LeftUpperArmY), 2)) * 100;
      float ZYProjLeftShoulderToLeftUpperArmDistance = Mathf.Abs(Mathf.Pow((LeftShoulderZ - LeftUpperArmZ), 2) - Mathf.Pow((LeftShoulderY - LeftUpperArmY), 2)) * 100;
      float XZProjLeftShoulderToLeftUpperArmDistance = Mathf.Abs(Mathf.Pow((LeftShoulderX - LeftUpperArmX), 2) - Mathf.Pow((LeftShoulderZ - LeftUpperArmZ), 2)) * 100;
      float XYProjLeftUpperArmToLeftLowerArmDistance = Mathf.Abs(Mathf.Pow((LeftUpperArmX - LeftLowerArmX), 2) - Mathf.Pow((LeftUpperArmY - LeftLowerArmY), 2)) * 100;
      float ZYProjLeftUpperArmToLeftLowerArmDistance = Mathf.Abs(Mathf.Pow((LeftUpperArmZ - LeftLowerArmZ), 2) - Mathf.Pow((LeftUpperArmY - LeftLowerArmY), 2)) * 100;
      float XZProjLeftUpperArmToLeftLowerArmDistance = Mathf.Abs(Mathf.Pow((LeftUpperArmX - LeftLowerArmX), 2) - Mathf.Pow((LeftUpperArmZ - LeftLowerArmZ), 2)) * 100;


      // Joint Position x, y, z for RightShoudler, RightUpperArm, RightLowerArm
      float RightShoulderX = rightShoulder.transform.position.x;
      float RightShoulderY = rightShoulder.transform.position.y;
      float RightShoulderZ = rightShoulder.transform.position.z;
      float RightUpperArmX = rightUpperArm.transform.position.x;
      float RightUpperArmY = rightUpperArm.transform.position.y;
      float RightUpperArmZ = rightUpperArm.transform.position.z;
      float RightLowerArmX = rightLowerArm.transform.position.x;
      float RightLowerArmY = rightLowerArm.transform.position.y;
      float RightLowerArmZ = rightLowerArm.transform.position.z;
      // 판정하는 부위(5) : RIGHT ARM
      float XYProjRightShoulderToRightUpperArmDistance = Mathf.Abs(Mathf.Pow((RightShoulderX - RightUpperArmX), 2) - Mathf.Pow((RightShoulderY - RightUpperArmY), 2)) * 100;
      float ZYProjRightShoulderToRightUpperArmDistance = Mathf.Abs(Mathf.Pow((RightShoulderZ - RightUpperArmZ), 2) - Mathf.Pow((RightShoulderY - RightUpperArmY), 2)) * 100;
      float XZProjRightShoulderToRightUpperArmDistance = Mathf.Abs(Mathf.Pow((RightShoulderX - RightUpperArmX), 2) - Mathf.Pow((RightShoulderZ - RightUpperArmZ), 2)) * 100;
      float XYProjRightUpperArmToRightLowerArmDistance = Mathf.Abs(Mathf.Pow((RightUpperArmX - RightLowerArmX), 2) - Mathf.Pow((RightUpperArmY - RightLowerArmY), 2)) * 100;
      float ZYProjRightUpperArmToRightLowerArmDistance = Mathf.Abs(Mathf.Pow((RightUpperArmZ - RightLowerArmZ), 2) - Mathf.Pow((RightUpperArmY - RightLowerArmY), 2)) * 100;
      float XZProjRightUpperArmToRightLowerArmDistance = Mathf.Abs(Mathf.Pow((RightUpperArmX - RightLowerArmX), 2) - Mathf.Pow((RightUpperArmZ - RightLowerArmZ), 2)) * 100;

      //float  = Mathf.Abs(Mathf.Pow( (), 2) - Mathf.Pow( (), 2)) * 100;


      // 최종 결정 - 1. Distance
      int FrontXYCount = 0;
      int SideZYCount = 0;
      int TopXZCount = 0;
      //Debug.Log("[Front XY 왼하체]" + (XYProjLeftLowerLegToFootDistance + XYProjLeftUpperLegToLowerLegDistance));
      //Debug.Log("[Side ZY 왼하체]" + (ZYProjLeftLowerLegToFootDistnace + ZYProjLeftUpperLegToLowerLegDistance));
      //Debug.Log("[Top XZ 왼하체]" + (XZProjLeftLowerLegToFootDistance + XZProjLeftUpperLegToLowerLegDistance));
      float a = XYProjLeftLowerLegToFootDistance + XYProjLeftUpperLegToLowerLegDistance;
      float b = ZYProjLeftLowerLegToFootDistnace + ZYProjLeftUpperLegToLowerLegDistance;
      float c = XZProjLeftLowerLegToFootDistance + XZProjLeftUpperLegToLowerLegDistance;
      float MaxLeftLeg = Mathf.Max(a,
        b,
        c);
      //Debug.Log(MaxLeftLeg);
      if (MaxLeftLeg == a)
        FrontXYCount++;
      else if (MaxLeftLeg == b)
        SideZYCount++;
      else if (MaxLeftLeg == c)
        TopXZCount++;
      else
        Debug.Log("NULL MaxLefTLeg");

      //Debug.Log("[Front XY 오하체]" + (XYProjRightLowerToFootDistance + XYProjRightUpperLegToLowerLegDistance));
      //Debug.Log("[Side ZY 오하체]" + (ZYProjRightLowerLegToFootDistnace + ZYProjRightUpperLegToLowerLegDistance));
      //Debug.Log("[Top XZ 오하체]" + (XZProjRightLowerLegToFootDistance + XZProjRightUpperLegToLowerLegDistance));
      //Debug.Log(MaxRightLeg);
      float MaxRightLeg = Mathf.Max(XYProjRightLowerToFootDistance + XYProjRightUpperLegToLowerLegDistance,
        ZYProjRightLowerLegToFootDistnace + ZYProjRightUpperLegToLowerLegDistance,
        XZProjRightLowerLegToFootDistance + XZProjRightUpperLegToLowerLegDistance);
      float a_ = XYProjRightLowerToFootDistance + XYProjRightUpperLegToLowerLegDistance;
      float b_ = ZYProjRightLowerLegToFootDistnace + ZYProjRightUpperLegToLowerLegDistance;
      float c_ = XZProjRightLowerLegToFootDistance + XZProjRightUpperLegToLowerLegDistance;
      if (MaxRightLeg == a_)
        FrontXYCount++;
      else if (MaxRightLeg == b_)
        SideZYCount++;
      else if (MaxRightLeg == c_)
        TopXZCount++;
      else
        Debug.Log("NULL MaxRightLeg");

      float MaxChest = Mathf.Max(XYProjUpperChestToChestDistance + XYProjChestToSpineDistance,
        ZYProjUpperChestToChestDistance + ZYProjChestToSpineDistance,
        XZProjUpperChestToChestDistance + XZProjChestToSpineDistance);
      float aa = XYProjUpperChestToChestDistance + XYProjChestToSpineDistance;
      float bb = ZYProjUpperChestToChestDistance + ZYProjChestToSpineDistance;
      float cc = XZProjUpperChestToChestDistance + XZProjChestToSpineDistance;
      Debug.Log(MaxChest);
      if (MaxChest == aa)
        FrontXYCount++;
      else if (MaxChest == bb)
        SideZYCount++;
      else if (MaxChest == cc)
        TopXZCount++;
      else
        Debug.Log("NULL MaxChest");

      float MaxLeftArm = Mathf.Max(XYProjLeftShoulderToLeftUpperArmDistance + XYProjLeftUpperArmToLeftLowerArmDistance,
       ZYProjLeftShoulderToLeftUpperArmDistance + ZYProjLeftUpperArmToLeftLowerArmDistance,
       XZProjLeftShoulderToLeftUpperArmDistance + XZProjLeftUpperArmToLeftLowerArmDistance);
      float aaa = XYProjLeftShoulderToLeftUpperArmDistance + XYProjLeftUpperArmToLeftLowerArmDistance;
      float bbb = ZYProjLeftShoulderToLeftUpperArmDistance + ZYProjLeftUpperArmToLeftLowerArmDistance;
      float ccc = XZProjLeftShoulderToLeftUpperArmDistance + XZProjLeftUpperArmToLeftLowerArmDistance;
      if (MaxLeftArm == aaa)
        FrontXYCount++;
      else if (MaxLeftArm == bbb)
        SideZYCount++;
      else if (MaxLeftArm ==ccc)
        TopXZCount++;
      else
      {
        Debug.Log("NULL MaxLeftArm");
      }

      float MaxRightArm = Mathf.Max(XYProjRightShoulderToRightUpperArmDistance + XYProjRightUpperArmToRightLowerArmDistance,
        ZYProjRightShoulderToRightUpperArmDistance + ZYProjRightUpperArmToRightLowerArmDistance,
        XZProjRightShoulderToRightUpperArmDistance + XZProjRightUpperArmToRightLowerArmDistance);
      float aaaa = XYProjRightShoulderToRightUpperArmDistance + XYProjRightUpperArmToRightLowerArmDistance;
      float bbbb = ZYProjRightShoulderToRightUpperArmDistance + ZYProjRightUpperArmToRightLowerArmDistance;
      float cccc = XZProjRightShoulderToRightUpperArmDistance + XZProjRightUpperArmToRightLowerArmDistance;
      if (MaxRightArm ==aaaa)
        FrontXYCount++;
      else if (MaxRightArm == bbbb)
        SideZYCount++;
      else if (MaxRightArm == cccc)
        TopXZCount++;
      else
        Debug.Log("NULL MaxRightArm");


      // 2. 좌우간격 판정 - 왼/오 다리, 왼/오 팔
      float LeftRightForupperlegSide = Mathf.Abs(Mathf.Pow((LeftUpperLegZ - RightUpperLegZ), 2) - Mathf.Pow((LeftUpperLegY - RightUpperLegY), 2)) * 100;
      float LeftRightForupperlegFront = Mathf.Abs(Mathf.Pow((LeftUpperLegX - RightUpperLegX), 2) - Mathf.Pow((LeftUpperLegY - RightUpperLegY), 2)) * 100;
      float LeftRightForlowerlegSide = Mathf.Abs(Mathf.Pow((LeftUpperLegZ - RightUpperLegZ),2) - Mathf.Pow((LeftLowerLegY - RightLowerLegY), 2)) * 100;
      float LeftRightForlowerlegFront = Mathf.Abs(Mathf.Pow((LeftUpperLegX - RightUpperLegX), 2) - Mathf.Pow((LeftLowerLegY - RightLowerLegY), 2)) *100;
      float LeftRightFrofootSide = Mathf.Abs(Mathf.Pow((LeftFootZ - RightFootZ), 2) - Mathf.Pow((LeftFootY - RightFootY), 2)) * 100;
      float LeftRightFrofootFront= Mathf.Abs(Mathf.Pow((LeftFootX - RightFootX), 2) - Mathf.Pow((LeftFootY - RightFootY), 2)) * 100;

     float LeftRightForshoulderSide = Mathf.Abs(Mathf.Pow((LeftShoulderZ - RightShoulderZ), 2) - Mathf.Pow((LeftShoulderY - RightShoulderY), 2)) * 100;
      float LeftRightForshoulderFront = Mathf.Abs(Mathf.Pow((LeftShoulderX - RightShoulderX), 2) - Mathf.Pow((LeftShoulderY - RightShoulderY), 2)) * 100;
      float LeftRightForupperarmSide = Mathf.Abs(Mathf.Pow((LeftUpperArmZ - RightUpperArmZ), 2) - Mathf.Pow((LeftUpperArmY - RightUpperArmY), 2)) * 100;
      float LeftRightForupperarmFront = Mathf.Abs(Mathf.Pow((LeftUpperArmX - RightUpperArmX), 2) - Mathf.Pow((LeftUpperArmY - RightUpperArmY), 2)) * 100;
      float LeftRightForlowerarmSide = Mathf.Abs(Mathf.Pow((LeftLowerArmZ - RightLowerArmZ), 2) - Mathf.Pow((LeftLowerArmY - RightLowerArmY), 2)) * 100;
      float LeftRightForlowerarmFront = Mathf.Abs(Mathf.Pow((LeftLowerArmX - RightLowerArmX), 2) - Mathf.Pow((LeftLowerArmY - RightLowerArmY), 2)) * 100;



      //Mathf.Abs(Mathf.Pow((), 2) - Mathf.Pow((), 2)) *100;

      float legSide = (LeftRightForupperlegSide + LeftRightForlowerlegSide + LeftRightFrofootSide);
      
      float legFront = LeftRightForupperlegFront + LeftRightForlowerlegFront + LeftRightFrofootFront;
      float armSide = LeftRightForshoulderSide + LeftRightForupperarmSide + LeftRightForlowerarmSide;
      float armFront = LeftRightForshoulderFront + LeftRightForupperarmFront + LeftRightForlowerarmFront;
      Debug.Log("왼오다리 간격(측면) :" + legSide);
      Debug.Log("왼오다리 간격(정면) :" + legFront);

      Debug.Log("왼오팔 간격(측면) : " + (LeftRightForshoulderSide + LeftRightForupperarmSide + LeftRightForlowerarmSide));
      Debug.Log("왼오팔 간격(정면) : " + (LeftRightForshoulderFront + LeftRightForupperarmFront + LeftRightForlowerarmFront));


      int XYcnt = 0;
      int ZYCnt = 0;
      int XZCnt = 0;
      float Max1 = Mathf.Max(legFront, legSide);

      if (legSide > legFront)
        Debug.Log("legside가 더 크다");
      if (Max1 == legSide)
      {
        Debug.Log("왼오다리 간격 Max는 측면입니다.");
        ZYCnt++;
      }
      else if (Max1 == legFront)
      {
        Debug.Log("왼오다리 간격 Max는 정면입니다.");
        XYcnt++;
      }
       

      float Max2 = Mathf.Max(armSide, armFront);
      if (Max2 == armSide)
      {
        Debug.Log("왼오팔 간격 Max는 측면입니다.");
        ZYCnt++;
      }
      else if (Max2 == armFront)
      {
        Debug.Log("왼오팔 간격 Max는 정면입니다.");
        XYcnt++;
      }


      // 측면인 경우 Left인지, Right인지 판정 -> 움직인 부위가 Left가 많은지 Right가 많은지
      float FirstMax = Mathf.Max(FrontXYCount, SideZYCount, TopXZCount);
      float SecondMax = Mathf.Max(XYcnt, ZYCnt, XZCnt);
      Debug.Log("[First]" + "XY " + FrontXYCount + ", ZY " + SideZYCount + ", XZ " + TopXZCount);
      Debug.Log("[Second]" + "XY " + XYcnt + ", ZY " + ZYCnt + ", XZ " + XZCnt);
      Debug.Log("First : " + FirstMax + ", Second : " + SecondMax);
      
      // 움직인 총 거리가 정면이 가장 많을 때
      if(FirstMax == FrontXYCount)
      {
        if(SecondMax == XYcnt)
        {
          MirrorFront.gameObject.SetActive(true);
          Debug.Log("Mirror Front 활성화");
        }
        else
        {
          if(FirstMax >= SecondMax)
          {
            MirrorFront.gameObject.SetActive(true);
            Debug.Log("Mirror Front 활성화 (간격은 다른 뷰지만 움직인 총 거리가 더 길다)");
          }
          else
          {
            Debug.Log("움직인 총 거리는 정면, 간격은 다른 뷰");
          }
        }
      }
      // 움직인 총 거리가 측면이 가장 많을 때 -> 왼오카메라 판정도 해주어야함.
      else if (FirstMax == SideZYCount)
      {
        if (SecondMax == ZYCnt)
        {
          MirrorRight.gameObject.SetActive(true);
          Debug.Log("Mirror Side 활성화");
         
        }
        else
        {
          if (FirstMax >= SecondMax)
          {
            MirrorRight.gameObject.SetActive(true);
            Debug.Log("Mirror Side 활성화 (간격은 다른 뷰지만 움직인 총 거리가 더 길다)");
          }
          else
          {
            Debug.Log("움직인 총 거리는 측면, 간격은 다른 뷰");
          }
        }
      }
      // 움직인 총 거리가 항공이 가장 많을 때
      else if(FirstMax == TopXZCount)
      {

      }


    }








  }
}
