﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticCharacter : MonoBehaviour
{
    [Header("Компонент канвас с элементами меню(заполнять)")]
    public AllComponentsCanvas canvas;

    [Header("Класс смены локации)")]
    [Space(20)]
    public ChangeLocal changeLocal;

    [Header("Класс нажатия кнопок персонажа")]
    [Space(20)]
    public InputCharacter inputCharacter;

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
    [Header("Время для закрытия субтитров")]
    [Space(20)]
    public float timeClearSubtibleText;
    [Header("Секундомер")]
    [Space(20)]
    public float secontTimer;

    [Header("Осмотр записок и изображений")]
    [Space(10)]
    public bool writeBoolAction;
    [Header("Изоброжение самой записки")]
    [Space(10)]
    public Sprite spriteWrite;
    [Header("Поле текста по поводу записки")]
    [Space(10)]
    public string textWriteng;

    private int IdBattonWriteText;

    void Update() {

        ScrinUpdate();

        SubtibleUpdate();

        PauseWindowUpdate();

        UpdateWindowForWriteText();
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
            blackScrinn.color = canvas.changeLocalImage.color;
            blackScrinn.color.a += Time.deltaTime *  blackScrinn.speedChange;
            canvas.changeLocalImage.color =  blackScrinn.color;
            }
        }

        if(!blackScrinn.black)
        {
            blackScrinn.workBlack = false;
            if( colorAlphaChangeLocal != 0f){
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

    void PauseWindowUpdate()
    {
        if(inputCharacter.pauseID == 0)
        {
            canvas.pauseAction = false;
        }
        else if (inputCharacter.pauseID == 1)
        {
            canvas.pauseAction = true;
        }
    }

    void UpdateWindowForWriteText()
    {
        IdBattonWriteText = Mathf.Clamp(IdBattonWriteText,0,1);
        if(writeBoolAction)
        {
            canvas.writeTextPlane.SetActive(true);
            if(spriteWrite != null)
            {
                canvas.imageWrite.sprite = spriteWrite;
                canvas.imageWrite.color = new Color(1f,1f,1f,1f);

                if(textWriteng != null)
                {
                    canvas.battonOpenWriteText.SetActive(true);
                    canvas.textForWriteWindow.text = textWriteng;
                }
                else 
                {
                    canvas.battonOpenWriteText.SetActive(false);
                }
            }
            else 
            {
                canvas.imageWrite.color = new Color(0f,0f,0f,0f);
            }
        }
        else 
        {
            canvas.imageWrite.sprite = null;
            textWriteng = null;
        }

    }

    public void ClosetWindowForWriteText()
    {
        spriteWrite = null;
        canvas.writeTextPlane.SetActive(false);
        writeBoolAction = false;
    }

    public void Open_Closet_WriteTextWindow()
    {   
        if(IdBattonWriteText == 0)
        {
            canvas.textWriteWindowInside.SetActive(true);
            IdBattonWriteText += 1;
        }
        else 
        {
            canvas.textWriteWindowInside.SetActive(false);
            IdBattonWriteText -= 1;
        }
    }


}
