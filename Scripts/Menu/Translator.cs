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
        "System sounds" //12
        },
        #endregion

        #region Русский
        {
        "Одиночная игра",           
        "Кооператив",
        "Настройки",
        "Выход",
        "Назад",
        "Язык",
        "Графика",
        "Звук",
        "Управление",
        "Назад", 
        "В процессе разработки",
        "Русский",
        "Системные звуки"
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
