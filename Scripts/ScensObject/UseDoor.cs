using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UseDoor : MonoBehaviour
{
    [Header("Точка для перемещения")]
    public Transform point;

    [Header("Комната в которую переходим")]
    [Space(10)]
    public GameObject nextRoom;

    [Header("Комнота из которой переходим")]
    [Space(10)]
    public GameObject lastRoom;

    [Header("Префам с подсветкой и текстом к объекту")]
    [Space(10)]
    public AllComponentsForTarget target;

    [Header("Имя объекта")]
    [Space(10)]
    public string nameObject;

    [Header("Звук необходиммый воспроизвести при использовании")]
    [Space(10)]
    public AudioClip useClip;
    private AudioSource audioSource;


    //Компоненты для тригера необходимые для перемещения
    private bool stayInTrugger; // Переменная отслеживающая нахождения персонажа в тригере 
    private InputCharacter inputCharacter; //переменная принемающая на себя скрипт упровления персонажа
    private GameObject character;// игровой объект персонажа
    private StaticCharacter staticCharacter;

    //Метод добавления персонажа в тригер и удаление его соответственно 
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Character")
        {
            stayInTrugger = true;
            inputCharacter = other.gameObject.GetComponent<InputCharacter>();
            character = other.gameObject;
            staticCharacter = other.gameObject.GetComponent<StaticCharacter>();
        }
    }

    private void OnTriggerStay(Collider other) {
                if(other.tag == "Character")
        {
            stayInTrugger = true;
            inputCharacter = other.gameObject.GetComponent<InputCharacter>();
            character = other.gameObject;
            staticCharacter = other.gameObject.GetComponent<StaticCharacter>();
        }
    }

    private void OnTriggerExit(Collider other) {
                if(other.tag == "Character")
        {
            stayInTrugger = false;
            inputCharacter = null;
            character = null;
            staticCharacter = null;
        }
    }

    private void Start() {

        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(stayInTrugger) //Проверка находиться ли персонаж в колайдере двери
        {

            target.textPlane.text = nameObject;

            if(inputCharacter.actionEvent) // обработка нажатия на взаимодействие
            {

                staticCharacter.changeLocal.changeLocations = true;
                
                if(useClip != null)//проверка есть ли звуковая дорожка 
                    {
                        audioSource.volume = PlayerPrefs.GetFloat("EffectSound"); //Настройка уровня звука

                        audioSource.PlayOneShot(useClip);//Воспроизведение звука

                    }

            }

            else if(staticCharacter.changeLocal.typeColorChangeImage != 0)
                {
                    
                    

                    character.transform.position = point.transform.position; // перемещаем персонажа в новую точку

                    nextRoom.SetActive(true); // Делаем активную следующую комнату по перемещению персонажа

                    lastRoom.SetActive(false); // Делаем закрытую предыдущую комнату 

                    stayInTrugger = false;

                    inputCharacter = null;

                    character = null;

                    }
        }

        else 
        {
            target.textPlane.text = "";
        }
    }
}
