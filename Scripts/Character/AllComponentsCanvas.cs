using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AllComponentsCanvas : MonoBehaviour
{
    [Header("Картинка затемнения экрана.")]
    public Image changeLocalImage;

    [Header("Текст субтитров.")]
    [Space(10)]
    public TextMeshProUGUI textTalking;

    [Header("Окно паузы.")]
    [Space(10)]
    public GameObject PauseWindow;
    [Header("Переменная активности меню паузы.")]
    [Space(10)]
    public bool pauseAction;
    
    [Header("Джойстик игры с конваса.")]
    [Space(10)]
    public DynamicJoystick joystick;

    [Header("окно чтение записок")]
    [Space(10)]
    public GameObject writeTextPlane;  
    public Image imageWrite; 
    public GameObject textWriteWindowInside;
    public GameObject battonOpenWriteText;
    public TextMeshProUGUI textForWriteWindow; 
}
