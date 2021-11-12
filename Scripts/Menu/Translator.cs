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
        "Single player", //0          
        "Multiplayer", //1
        "Settings", //2
        "Exit", //3
        "Back", //4
        "Language", //5
        "Graphics", //6
        "Sounds", //7
        "Controll",  //8
        "Back", // 9
        "On development stage", //10
        "English", //11
        "System sounds",//12
        "Screen resolution", //13
        "Quality",//14
        "Texture quality",//15
        "Smoothing",//16
        "Shadow quality",//17
        "Distance of shadows",//18
        "Low",//19
        "Midlle",//20
        "High",//21
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
        "Одиночная игра",   //0        
        "Кооператив",//1
        "Настройки",//2
        "Выход",//3
        "Назад",//4
        "Язык",//5
        "Графика",//6
        "Звук",//7
        "Управление",//8
        "Назад", //9
        "В процессе разработки",//10
        "Русский",//11
        "Системные звуки",//12
        "Разрешение экрана",//13
        "Качество", //14
        "Качество текстур", //15
        "Сглаживание",//16
        "Качество теней",//17
        "Дальность теней", //18
        "Низкое", //19
        "Среднее",//20
        "Высокое",//21
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
        }
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
