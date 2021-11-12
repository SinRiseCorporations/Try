using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    public Transform CameraTransform;
    [HideInInspector] public float vertical;
    [HideInInspector] public float horizontal;
    public float moveAmount;

    public float smothinkRotation;

    public Vector3 rotationDirection;
    public Vector3 moveDirection;
    
    public void MoveUpdate()
    {
        MoveAmount();
        RotationCharacter();
    }

    void MoveAmount()
    {
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));
    }
    

    void RotationCharacter()
    {
        Vector3 moveDir = CameraTransform.forward * vertical;
        moveDir += CameraTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection = CameraTransform.forward;

        rotationDirection = moveDirection;

        Vector3 targetDir = rotationDirection;
        targetDir.y =0;

        if(targetDir == Vector3.zero) targetDir = transform.forward;

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation,lookDir, Time.deltaTime * smothinkRotation);
        transform.rotation = targetRot;
    }

    
}
