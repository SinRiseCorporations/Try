using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //Компоненты для тригера необходимые для перемещения
    private bool stayInTrugger; // Переменная отслеживающая нахождения персонажа в тригере 
    private InputCharacter inputCharacter; //переменная принемающая на себя скрипт упровления персонажа
    private GameObject character;// игровой объект персонажа

    //Метод добавления персонажа в тригер и удаление его соответственно 
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Character")
        {
            stayInTrugger = true;
            inputCharacter = other.gameObject.GetComponent<InputCharacter>();
            character = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other) {
                if(other.tag == "Character")
        {
            stayInTrugger = true;
            inputCharacter = other.gameObject.GetComponent<InputCharacter>();
            character = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
                if(other.tag == "Character")
        {
            stayInTrugger = false;
            inputCharacter = null;
            character = null;
        }
    }
    
    void Update()
    {
        if(stayInTrugger) //Проверка находиться ли персонаж в колайдере двери
        {
            if(inputCharacter.actionEvent) // обработка нажатия на взаимодействие
            {
                character.transform.position = point.transform.position; // перемещаем персонажа в новую точку

                nextRoom.SetActive(true); // Делаем активную следующую комнату по перемещению персонажа

                lastRoom.SetActive(false); // Делаем закрытую предыдущую комнату 
            }
        }
    }
}
