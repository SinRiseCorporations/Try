using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Setting/SettingOptionCamera")]
public class SettingOptionsCamera : ScriptableObject
{
    public float pivotPosX;
    public float pivotPosY;
    public float pivotPosZ;
        
    public float CameraPosZ;

    public float RotX;
    public float RotY;
    public float RotZ;

    public float smothigCamera;
}
