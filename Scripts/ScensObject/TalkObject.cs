using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkObject : MonoBehaviour
{
    [Header("Переменная отвечающая за не воспрпоизведения скрипта повторно")]
    public int wasTalk = 0;

    [Header("Текс который неообходимо персонажу сказать")]
    [Space(10)]
    public string texttalk;

    [Header("Время которе будет висеть данный текст")]
    [Space(10)]
    public float time;

    [Header("Компонент для подписи объектов")]
    [Space(10)]
    public AllComponentsForTarget target;

    [Header("Имя объекта")]
    [Space(10)]
    public string nameObject;

    [Header("Тип объкта")]
    public bool plot;
    public LogicPart logic;

    [Header("Звук необходиммый воспроизвести")]
    [Space(10)]
    public AudioClip clip;

    private AudioSource source;

    private bool stay;

    private StaticCharacter subTible;
    private InputCharacter input;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Character")
        {
            stay = true;
            subTible = other.gameObject.GetComponent<StaticCharacter>();
            input = other.gameObject.GetComponent<InputCharacter>();
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Character")
        {
            stay = true;
            subTible = other.gameObject.GetComponent<StaticCharacter>();
            input = other.gameObject.GetComponent<InputCharacter>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Character")
        {
            stay = false;
            subTible = null;
            input = null;
        }
    }
    
    
    void Update()
    {
        if(stay)
        {   
            if(nameObject != null) target.textPlane.text = nameObject;

            if(wasTalk == 0)
            {
                if (input.actionEvent){

                    LogicUpdate();

                    if(texttalk != null)
                    {
                        subTible.subtibleText = texttalk;
                        subTible.timeClearSubtibleText = time;
                        
                        wasTalk = 1;

                        SoundPlay();

                        gameObject.SetActive(false);
                    }
                }
            }
        }

        else target.textPlane.text = "";

    }

    void LogicUpdate()
    {
        if(plot)
        {
            if(logic != null)
            {
                logic.progressPart = logic.progressPart  + 1;
                logic.LogiChangeUpdate();
            }
        }
    }

    void SoundPlay()
    {
        if(source!= null)
        {
            if(clip != null)
            {
                source.PlayOneShot(clip);
            }
        }
    }
}