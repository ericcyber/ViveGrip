using UnityEngine;
using System.Collections;

public static class JointFactory {
  public static Vector3 defaultAnchor;

  public static void AddJointTo(GameObject gameObject, float attachedMass) {
    ConfigurableJoint joint = gameObject.AddComponent<ConfigurableJoint>();
    JointFactory.ConfigureBase(joint);
    JointFactory.SetDrive(joint, attachedMass);
  }

  private static void ConfigureBase(ConfigurableJoint joint) {
    ConfigurableJointMotion linearMotion = ConfigurableJointMotion.Limited;
    ConfigurableJointMotion angularMotion = ConfigurableJointMotion.Locked;
    joint.xMotion = linearMotion;
    joint.yMotion = linearMotion;
    joint.zMotion = linearMotion;
    joint.angularXMotion = angularMotion;
    joint.angularYMotion = angularMotion;
    joint.angularZMotion = angularMotion;
    joint.anchor = Vector3.zero;
    SoftJointLimit jointLimit = joint.linearLimit;
    jointLimit.limit = 10;
    joint.linearLimit = jointLimit;
  }

  private static void SetDrive(ConfigurableJoint joint, float mass) {
    float gripStrength = 3000f * mass;
    float gripSpeed = 10f * mass;
    JointDrive jointDrive = joint.xDrive;
    jointDrive.positionSpring = gripStrength;
    jointDrive.positionDamper = gripSpeed;
    joint.xDrive = jointDrive;
    jointDrive = joint.yDrive;
    jointDrive.positionSpring = gripStrength;
    jointDrive.positionDamper = gripSpeed;
    joint.yDrive = jointDrive;
    jointDrive = joint.zDrive;
    jointDrive.positionSpring = gripStrength;
    jointDrive.positionDamper = gripSpeed;
    joint.zDrive = jointDrive;
  }
}