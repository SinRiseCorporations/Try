using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCharacter : MonoBehaviour
{
    [Header("Компонент канвас с элементами меню(заполнять)")]
    public AllComponentsCanvas canvas;

    [Header("Класс смены локации)")]
    [Space(20)]
    public ChangeLocal changeLocal;

    [System.Serializable]
    public class ChangeLocal
    {
        [Header("Переменные смены локации(Вызывать)")]
        public bool changeLocations;

        [Header("Скорость смены локации(заполнять)")]
        public float speedChange;

        [Header("Время задержки фона для смены локации(заполнять)")]
        public float timeOfBack;

        [Header("Цвет фона для смены локации(не заполнять)")]
        public Color color;
        
        [Header("Тип состояния смены локации(не заполнять)")]
        public int typeColorChangeImage;

        [Header("Секундомер(не заполнять)")]
        public float secontTime = 0;
        [HideInInspector]
        public bool workChange;
    }
    
    [Header("Настройка черного экрана")]
    [Space(20)]
    public BlackScrinn blackScrinn;

    [System.Serializable]
    public class BlackScrinn
    {   
        [Header("Состояние черного экрана")]
        public bool black;

        [Header("Скорость смены экрана (заполнять)")]
        public float speedChange;

        [Header("Цвет фона альфы (не заполнять)")]
        public Color color;
        [HideInInspector]
        public bool workBlack;

    }

    [Header("Переменная альфа канала(не заполнять)")]
    [Space(20)]
    public float colorAlphaChangeLocal;

    [Header("Текстовая строка субтитров(Заполнять внешне)")]
    [Space(20)]
    public string subtibleText;
    public float timeClearSubtibleText;

    public float secontTimer;

    void Update() {

        ScrinUpdate();

        SubtibleUpdate();
    }

    void ScrinUpdate()
    {
        if(!blackScrinn.workBlack)ChangeLocationUpdate();
        if(!changeLocal.workChange)BlackScrinnUpdate();

        colorAlphaChangeLocal = canvas.changeLocalImage.color.a;
        colorAlphaChangeLocal = Mathf.Clamp(colorAlphaChangeLocal,0,1);
    }

    void ChangeLocationUpdate()
    {
        
        if( changeLocal.changeLocations)
        {
            changeLocal.workChange = true;

                if( colorAlphaChangeLocal != 1f &&  changeLocal.typeColorChangeImage == 0 )
                {
                    
                    Debug.Log("work");
                    changeLocal.color = canvas.changeLocalImage.color;
                    changeLocal.color.a += Time.deltaTime *  changeLocal.speedChange;
                    canvas.changeLocalImage.color =  changeLocal.color;
                }
                else if(colorAlphaChangeLocal == 1f &&  changeLocal.typeColorChangeImage == 0)
                {
                     changeLocal.typeColorChangeImage = 1;
                }
                else if (colorAlphaChangeLocal != 0f &&  changeLocal.typeColorChangeImage == 1)
                {
                     changeLocal.secontTime += Time.deltaTime;
                    if( changeLocal.secontTime >  changeLocal.timeOfBack)
                    {
                        Debug.Log("work_Back");
                         changeLocal.color = canvas.changeLocalImage.color;
                         changeLocal.color.a -= Time.deltaTime *  changeLocal.speedChange;
                        canvas.changeLocalImage.color =  changeLocal.color;
                    }
                }
                else if (colorAlphaChangeLocal == 0f &&  changeLocal.typeColorChangeImage == 1)
                {
                     changeLocal.typeColorChangeImage = 0;
                     changeLocal.changeLocations = false;
                     changeLocal.secontTime = 0;
                }
            
        }
        else changeLocal.workChange = false;
    }

    void BlackScrinnUpdate()
    {
        
        if(blackScrinn.black)
        {
            blackScrinn.workBlack = true;
            if( colorAlphaChangeLocal != 1f){
            Debug.Log("DuBlackScrin");
            blackScrinn.color = canvas.changeLocalImage.color;
            blackScrinn.color.a += Time.deltaTime *  blackScrinn.speedChange;
            canvas.changeLocalImage.color =  blackScrinn.color;
            }
        }

        if(!blackScrinn.black)
        {
            blackScrinn.workBlack = false;
            if( colorAlphaChangeLocal != 0f){
            Debug.Log("ClearBlackScrin");
            blackScrinn.color = canvas.changeLocalImage.color;
            blackScrinn.color.a -= Time.deltaTime *  blackScrinn.speedChange;
            canvas.changeLocalImage.color =  blackScrinn.color;
            }
        }
        
    }

    void SubtibleUpdate()
    {
        canvas.textTalking.text = subtibleText;

        if(subtibleText != null)
        {
            secontTimer += Time.deltaTime;
            if(secontTimer > timeClearSubtibleText)
            {
                canvas.textTalking.text = null;
                subtibleText = null;
                timeClearSubtibleText = 0;
                secontTimer = 0;
            }
        }
    }
}
