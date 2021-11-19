using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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
    private bool useLight;
    private int openActive = 0;
    private float seconTimeOfOpen;

    [Header("Префам с подсветкой и текстом к объекту")]
    [Space(10)]
    public AllComponentsForTarget target;

    [Header("Имя объекта")]
    [Space(10)]
    public string nameObject;

    private bool stayInTrugger;
    private InputCharacter inputCharacter;

    [Header("Звук необходиммый воспроизвести при использовании")]
    [Space(10)]
    public AudioClip useClip;
    private AudioSource audioSource;

    [Header("Тип объкта")]
    public bool plot;
    public LogicPart logic;

    public int playBefor = 0;

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

        audioSource = gameObject.GetComponent<AudioSource>();

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
                if(useClip != null)
                {
                    audioSource.volume = PlayerPrefs.GetFloat("EffectSound");
                    audioSource.PlayOneShot(useClip);
                }
                openActive += 1;

                LogicUpdate();
            }

            target.textPlane.text = nameObject;
        }

        else if (!stayInTrugger)
        {
            target.textPlane.text = "";
        }

        if(openActive != 0)
        {
            seconTimeOfOpen += Time.deltaTime;
            if(idWorkLight == 0)
            {
                lightType.roomWithLight.SetActive(true);

                if(debogCompatibility) lightType.roomWithOutLight.SetActive(false);


                idWorkLight = 1;

 
                openActive = 0;
                seconTimeOfOpen = 0;
            }

            else if (idWorkLight == 1)
            {
                lightType.roomWithLight.SetActive(false);
                if(debogCompatibility) lightType.roomWithOutLight.SetActive(true);

                idWorkLight = 0;

                openActive = 0;
                seconTimeOfOpen = 0;
            }
        }
    }

        void LogicUpdate()
    {
        if(plot)
        {
            if(playBefor == 0)
            {
                if(logic != null)
                {
                    logic.progressPart = logic.progressPart  + 1;
                    logic.LogiChangeUpdate();
                    playBefor = playBefor + 1;
                }
            }
            
        }
    }
}
