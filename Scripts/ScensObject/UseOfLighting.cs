using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseOfLighting : MonoBehaviour
{
    [Header("Класс с помещёнными мешами освещения")]
    public LightMapsConnect lightType;

    [Header("Переменная активности света")]
    [Space(10)]
    public int idWorkLight = 0;

    [Header("Проверка на совестимость карт")]
    [Space(10)]
    public bool debogCompatibility;
    public bool useLight;
    private int openActive = 0;
    private float seconTimeOfOpen;


    private bool stayInTrugger;
    private InputCharacter inputCharacter;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Character")
        {
            stayInTrugger = true;
            inputCharacter = other.gameObject.GetComponent<InputCharacter>();
        }
    }

    private void OnTriggerStay(Collider other) {
                if(other.tag == "Character")
        {
            stayInTrugger = true;
            inputCharacter = other.gameObject.GetComponent<InputCharacter>();
        }
    }

    private void OnTriggerExit(Collider other) {
                if(other.tag == "Character")
        {
            stayInTrugger = false;
            inputCharacter = null;
        }
    }

    private void Start() {

        if(idWorkLight == 0)
        {
            lightType.roomWithLight.SetActive(false);
        }
        else if (idWorkLight == 1)
        {
            lightType.roomWithLight.SetActive(true);
        }

    }


    void Update()
    {
        idWorkLight = Mathf.Clamp(idWorkLight,0,1);

        if(stayInTrugger){
            if(inputCharacter.actionEvent)
            {
                openActive += 1;
            }
        }

        if(openActive != 0)
        {
            seconTimeOfOpen += Time.deltaTime;
            if(idWorkLight == 0)
            {
                lightType.roomWithLight.SetActive(true);

                if(debogCompatibility) lightType.roomWithOutLight.SetActive(false);
                
                idWorkLight = 1;

                if(seconTimeOfOpen < 0.3)
                {
                    openActive = 0;
                    seconTimeOfOpen = 0;
                }
            }

            else if (idWorkLight == 1)
            {
                lightType.roomWithLight.SetActive(false);
                if(debogCompatibility) lightType.roomWithOutLight.SetActive(true);

                idWorkLight = 0;

                if(seconTimeOfOpen < 0.3)
                {
                    openActive = 0;
                    seconTimeOfOpen = 0;
                }
            }
        }
    }
}
