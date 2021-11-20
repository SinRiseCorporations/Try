using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPart : MonoBehaviour
{
    [Header("Прогресс на эпизоде игры")]
    public int progressPart;

    [Header("Этапы которые будут открывате с прогрессом игры")]
    public SceenObject[] sceenObject;

    [Header("Компоненты загрузки.")]
    public GameObject character;
    public GameObject loadCanvas;


    [System.Serializable]
    public class SceenObject
    {
        public GameObject[] Object;
        public bool over;
    }

    void Awake() {

        character.SetActive(true);
        loadCanvas.SetActive(false);


        for(int i = 0 ; i < sceenObject.Length; i ++)
        {
            for(int j = 0 ; j < sceenObject[i].Object.Length; j ++)
            {
                sceenObject[i].Object[j].SetActive(false);
            }
            
        }

        for(int i = 0 ; i < sceenObject[0].Object.Length;i++)
        {
            sceenObject[progressPart].Object[i].SetActive(true);
        }
    }

    public void LogiChangeUpdate()
    {
        for(int i = 0 ; i < sceenObject.Length; i ++)
        {
            for(int j = 0 ; j < sceenObject[i].Object.Length; j ++)
            {
                if(sceenObject[i].over == false) sceenObject[i].Object[j].SetActive(false);
            }
            
        }

        for(int i = 0 ; i < sceenObject[progressPart].Object.Length;i++)
        {
            sceenObject[progressPart].Object[i].SetActive(true);
        }
    }

    public void LoadScens()
    {
        character.SetActive(false);
        loadCanvas.SetActive(true);
    }
}
