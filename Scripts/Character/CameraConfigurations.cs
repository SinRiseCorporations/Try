using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfigurations : MonoBehaviour
{
    
    [Header("Setting for camera")]
    [Space(10)]
    public SettingOptionsCamera setting;

    [Header("GameObject of camera")]
    [Space(10)]
    public Transform cameraHolder;
    public Transform cameraPivot;

    public Transform cameraCharacter;
    

    [Header("GameObject of Character")]
    [Space(10)]
    public Transform characterTransform;
    
    void Update()
    {
        cameraHolder.position = Vector3.Slerp(cameraHolder.position , characterTransform.position,Time.deltaTime * setting.smothigCamera);
        
        cameraPivot.localPosition = new Vector3(setting.pivotPosX,setting.pivotPosY,setting.pivotPosZ);

        cameraCharacter.localPosition = new Vector3(0,0,setting.CameraPosZ);

        cameraPivot.rotation = Quaternion.Euler(setting.RotX,setting.RotY,setting.RotZ);

        cameraHolder.rotation = Quaternion.Euler(0,setting.RotY,0);
    }
}
