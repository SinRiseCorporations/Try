using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    private static int LanguageID;

    private static List<Translation_text_ID> listID = new List<Translation_text_ID>();

    #region Весь текст [двухмерный массив]

    private static string[,] LineText = 
    {
        #region Английский
        {
        "Continue", //0
        "New Game",//1
        "Settings",//2
        "Exit",//3
        "Back",//4
        "Play",//5
        "There is a game save, sure you want to start over.",//6
        "Audio settings",//7
        "Language and subtitles",//8
        "The development list", //9
        "A developer",//10
        "Sound system",//11
        "Sound of music",//12
        "Sound effects",//13
        "Language", //14
        "English", //15
        "Loading",//16
        "Exit to the menu",//17
        "Start from the beginning", //18
        "Subtitles", //19
        "Yes",//20
        "No",//21+
        "Very hige",//22
        "Disablet",//23
        "2X",//24
        "4X",//25
        "8X",//26
        "Next",//27
        "Precious",//28
        "Chapter 1",//29
        "Chapter 2",//30
        "Chapter 3",//31
        "Chapter 4",//32
        "Chapter 5",//33
        "Chapter 6",//34
        "Play",//35
        },
        #endregion

        #region Русский
        {
        "Продолжить",   //0        
        "Новая игра",//1
        "Настройки",//2
        "Выход",//3
        "Назад",//4
        "Играть",//5
        "Есть сохранение игры, уверены что хотите начать сначала.",//6
        "Настройки звука",//7
        "Язык и субтитры",//8
        "Список разработчиков", //9
        "Помощь разработчиков",//10
        "Звук системный",//11
        "Звук музыки",//12
        "Звук эффектов",//13
        "Язык", //14
        "Русский", //15 Переведено ..
        "Загрузка",//16
        "Выйти в главное меню",//17
        "Начать с начала", //18 +
        "Субтитры", //19
        "Да",//20
        "Нет",//21+
        "Ультра",//22
        "Отсутствует",//23
        "2X",//24
        "4X",//25
        "8X",//26
        "Следующая",//27
        "Предыдущая",//28
        "Глава 1", //29
        "Глава 2", //30
        "Глава 3", //31
        "Глава 4", //32
        "Глава 5", //33
        "Глава 6", //34
        "Играть",//35
        },
        #endregion

    };
    #endregion

    static public void Seleck_language(int id){
        LanguageID = id;
        Update_texts();
    }

    static public string Get_text(int textKey)
    {
        return LineText[LanguageID,textKey];
    }

    static public void Add(Translation_text_ID idText)
    {
        listID.Add(idText);
    }

    static public void Delete(Translation_text_ID idText)
    {
        listID.Remove(idText);
    }

    static public void Update_texts()
    {
        for(int i = 0 ; i < listID.Count;i++)
        {
            listID[i].UIText.text = LineText[LanguageID,listID[i].ID_Text];//Тексты
            //if(PlayerPrefs.GetInt("Language") == 1) listID[i].UIText.font = Resources.Load<TMP_FontAsset>("RU_font_assets");
            //else listID[i].UIText.font = Resources.Load<TMP_FontAsset>("EN_font_assets");
        }
    }
}
