using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkObject : MonoBehaviour
{
    [Header("Переменная отвечающая за не воспрпоизведения скрипта повторно")]
    public int wasTalk = 0;

    [Header("Компонент для подписи объектов")]
    [Space(10)]
    public AllComponentsForTarget target;

    [Header("Имя объекта")]
    [Space(10)]
    public string nameObject;

    [Header("Тип объкта")]
    public bool plot;
    public LogicPart logic;

    public List<StaticCharacter.SubTitlesClass> talk = new List<StaticCharacter.SubTitlesClass>();

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
    
    private void Start() {
        target.textPlane.text = "";
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

                    if(talk.Count!=0)
                    {
                        Debug.Log("Work");
                        for (int i =0; i < talk.Count;i++)
                        {
                            subTible.subTitles.Add(talk[i]);
                            
                            wasTalk = 1;

                            if(i == talk.Count) gameObject.SetActive(false);
                        }
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
}