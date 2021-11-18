using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfigurations : MonoBehaviour
{
    
    [Header("Настройки камеры")]
    [Space(10)]
    public SettingOptionsCamera setting;

    [Header("Игровые объекты камеры согласно их названия")]
    [Space(10)]
    public Transform cameraHolder;
    public Transform cameraPivot;

    public Transform cameraCharacter;
    

    [Header("игровой объект персонажа")]
    [Space(10)]
    public Transform characterTransform;
    
    void FixedUpdate()
    {
        cameraHolder.position = Vector3.Slerp(cameraHolder.position , characterTransform.position,Time.deltaTime * setting.smothigCamera);
        
        cameraPivot.localPosition = new Vector3(setting.pivotPosX,setting.pivotPosY,setting.pivotPosZ);

        cameraCharacter.localPosition = new Vector3(0,0,setting.CameraPosZ);

        cameraPivot.rotation = Quaternion.Euler(setting.RotX,setting.RotY,setting.RotZ);

        cameraHolder.rotation = Quaternion.Euler(0,setting.RotY,0);
    }
}
