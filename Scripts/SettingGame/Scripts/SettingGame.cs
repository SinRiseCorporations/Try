using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Setting/TipeGame")]
public class SettingGame : ScriptableObject
{
    [Header("Какой тип платформы будет выбран в процессе игры.")]
    [Space(5)]
    public bool android;
    
}
