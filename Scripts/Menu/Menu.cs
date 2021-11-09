using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{   
    [Header("Переводчик")]
    [Space(10)]
    public Translator translator_menu;
    [Header("Язык который выбран сейчас.")]
    public string languageNow;
    [Space(10)]
    [Header("Количество Языков в игре.")]
    public int All_language;
    [Space(10)]
    [Header("Игровые объекты.")]
    public GameObject menu;
    public GameObject setting;
    public GameObject Error;
    public GameObject languageSetting;
    public GameObject soundSetting;
    public GameObject qualitySetting;

    [Space(10)]
    public AudioSource audioSource;
    public Slider sliderSoundSystem;
    public float lvl_sound_system;
    public TextMeshProUGUI text_sound_system;
    [Space(20)]
    [Header("Переменные для настройки граффики")]
    int valueSlider;
    [Space(20)]
    [Header("Разрешения")]
    public Slider sliderResolution;
    public TextMeshProUGUI textResolution;
    public Resolution[] resolutions;
    [Space(10)]
    [Header("Качество графики")]
    public int valueQuality;
    public Slider sliderQuality;
    public Translation_text_ID textQuality;
    public string quality;
    [Space(10)]
    [Header("Качество текстур")]
    public int valueTexture;
    public Slider sliderTexture;
    public Translation_text_ID textTexture;
    [Space(10)]
    [Header("Сглаживание")]
    public int valueAntAliasing;
    public Slider sliderAntAliasing;
    public Translation_text_ID textSmoothing;
    [Space(10)]
    [Header("Качество Теней")]
    public int valueShadow;
    public Slider sliderShadow;
    public Translation_text_ID textShadow;
    [Space(10)]
    [Header("ДАльность теней")]
    public int valueRangeShadow;
    public Slider sliderRangeShadow;
    public TextMeshProUGUI textRangShadow;

    private void Start() {

        #region Обработка запуска меню игры
        menu.SetActive(true);
        setting.SetActive(false);
        Error.SetActive(false);
        languageSetting.SetActive(false);
        soundSetting.SetActive(false);
        qualitySetting.SetActive(false);
        #endregion

        #region Проверка первоночального языка на устройстве а также его сохранение.
        if(PlayerPrefs.HasKey("Language")== false) {
            if(Application.systemLanguage == SystemLanguage.Russian) PlayerPrefs.SetInt("Language",1);
            else PlayerPrefs.SetInt("Language",0);
        }
        Translator.Seleck_language(PlayerPrefs.GetInt("Language"));
        #endregion

        #region Проверка установленного уровня звука в игре а также его сохранение.
        if(PlayerPrefs.HasKey("SystemSound") == false) PlayerPrefs.SetFloat("SystemSound",1);
        sliderSoundSystem.value = PlayerPrefs.GetFloat("SystemSound");
        #endregion

        #region Проверка настроек разришения устройства а также его сохранение 
        resolutions = Screen.resolutions;
        sliderResolution.maxValue = resolutions.Length -1;
        #endregion

        #region Применение настроек сохранёных разрешения
        if(PlayerPrefs.HasKey("Resolutions") == false) PlayerPrefs.SetInt("Resolutions", (int)sliderResolution.maxValue);
        sliderResolution.value = PlayerPrefs.GetInt("Resolutions");
        Screen.SetResolution(resolutions[(int)sliderResolution.value].width,resolutions[(int)sliderResolution.value].height,true);
        #endregion

        #region Загрузка сохранёных настроек качества
        if(PlayerPrefs.HasKey("QualitySetting") == false) PlayerPrefs.SetInt("QualitySetting" ,valueQuality = 3);
        valueQuality = PlayerPrefs.GetInt("QualitySetting");

        if(PlayerPrefs.HasKey("IndexQualite") == false) PlayerPrefs.SetInt("IndexQualite" ,textQuality.ID_Text = 21);
        textQuality.ID_Text = PlayerPrefs.GetInt("IndexQualite");

        sliderQuality.value = valueQuality;

        switch(valueQuality)
        {
            case 1: QualitySettings.SetQualityLevel(1); break;
            case 2: QualitySettings.SetQualityLevel(2); break;
            case 3: QualitySettings.SetQualityLevel(3); break;
            case 4: QualitySettings.SetQualityLevel(4); break;
        }
        #endregion
        
        #region Загруска сохранённых настроек текстур

        if(PlayerPrefs.HasKey("TextureQuality") == false) PlayerPrefs.SetInt("TextureQuality" ,valueTexture = 3);
        valueTexture = PlayerPrefs.GetInt("TextureQuality");

        if(PlayerPrefs.HasKey("IndexTextureQuality") == false) PlayerPrefs.SetInt("IndexTextureQuality" , textTexture.ID_Text = 21);
        textTexture.ID_Text = PlayerPrefs.GetInt("IndexTextureQuality");

        sliderTexture.value = valueTexture;

       switch(valueTexture)
        {
            case 1: QualitySettings.masterTextureLimit = 3; break;
            case 2: QualitySettings.masterTextureLimit = 2; break;
            case 3: QualitySettings.masterTextureLimit = 1; break;
            case 4: QualitySettings.masterTextureLimit = 0; break;
        }
        #endregion

        #region Загрузка сохранённых ностроек сглаживания
        if(PlayerPrefs.HasKey("AntAliasing") == false) PlayerPrefs.SetInt("AntAliasing" ,valueAntAliasing = 3);
        valueAntAliasing = PlayerPrefs.GetInt("AntAliasing");

        if(PlayerPrefs.HasKey("IndexSmoothing") == false) PlayerPrefs.SetInt("IndexSmoothing" , textSmoothing.ID_Text = 25);
        textSmoothing.ID_Text = PlayerPrefs.GetInt("IndexSmoothing");

        sliderAntAliasing.value = valueAntAliasing;

                switch(valueAntAliasing)
        {
            case 1: QualitySettings.antiAliasing = 1; break;
            case 2: QualitySettings.antiAliasing = 2; break;
            case 3: QualitySettings.antiAliasing = 4; break;
            case 4: QualitySettings.antiAliasing = 8; break;
        }
        #endregion

        #region Загрузка сохранённых настроек качества теней

        if(PlayerPrefs.HasKey("ShadowQuality") == false) PlayerPrefs.SetInt("ShadowQuality" ,valueShadow = 3);
        valueShadow = PlayerPrefs.GetInt("ShadowQuality");

        if(PlayerPrefs.HasKey("IndexQualityShadow") == false) PlayerPrefs.SetInt("IndexQualityShadow" , textShadow.ID_Text = 21);
        textShadow.ID_Text = PlayerPrefs.GetInt("IndexQualityShadow");

        sliderShadow.value = valueShadow;

        switch(valueShadow)
        {
            case 1 : QualitySettings.shadowResolution = ShadowResolution.Low; break;
            case 2 : QualitySettings.shadowResolution = ShadowResolution.Medium; break;
            case 3 : QualitySettings.shadowResolution = ShadowResolution.High; break;
            case 4 : QualitySettings.shadowResolution = ShadowResolution.VeryHigh; break;
        }
        #endregion

        #region Зарузка сохранённых настроек дальности теней
        if(PlayerPrefs.HasKey("ShadowRange") == false) PlayerPrefs.SetInt("ShadowRange" ,valueRangeShadow = 30);
        valueRangeShadow = PlayerPrefs.GetInt("ShadowRange");

        sliderRangeShadow.value = valueRangeShadow;

        QualitySettings.shadowDistance = valueRangeShadow;
        #endregion
    }

    private void Update() {

        #region Работа со звуком игры
        lvl_sound_system = sliderSoundSystem.value;
        audioSource.volume = lvl_sound_system;
        PlayerPrefs.SetFloat("SystemSound",lvl_sound_system);
        text_sound_system.text = Mathf.Round((PlayerPrefs.GetFloat("SystemSound")*100)).ToString();
        #endregion

        #region Работа с разришением настроек игры
        textResolution.text = "" + resolutions[(int)sliderResolution.value];
        #endregion

        #region Применение количества настроек к слайдеру
        valueTexture = (int)sliderTexture.value;
        valueAntAliasing = (int)sliderAntAliasing.value;
        valueShadow = (int)sliderShadow.value;
        valueRangeShadow = (int)sliderRangeShadow.value;
        #endregion

        #region Работа с общими настройками графики
        if(sliderQuality.value != valueQuality)
        {
            valueQuality = (int)sliderQuality.value;
            if(valueQuality == 1)
            {   
                textQuality.ID_Text = 19;
                sliderTexture.value = 1;
                sliderAntAliasing.value = 1;
                sliderShadow.value = 1;
                sliderRangeShadow.value  = 15;
                Translator.Update_texts();
                PlayerPrefs.SetInt("IndexQualite",textQuality.ID_Text);
            }
            else if (valueQuality == 2)
            {
                textQuality.ID_Text = 20;
                sliderTexture.value = 2;
                sliderAntAliasing.value = 2;
                sliderShadow.value = 2;
                sliderRangeShadow.value = 25;
                Translator.Update_texts();
                PlayerPrefs.SetInt("IndexQualite",textQuality.ID_Text);
            }
            else if (valueQuality == 3)
            {
                textQuality.ID_Text = 21;
                sliderTexture.value = 3;
                sliderAntAliasing.value = 3;
                sliderShadow.value = 3;
                sliderRangeShadow.value  = 35;
                Translator.Update_texts();
                PlayerPrefs.SetInt("IndexQualite",textQuality.ID_Text);
            }
            else if (valueQuality == 4)
            {
                textQuality.ID_Text = 22;
                sliderTexture.value = 4;
                sliderAntAliasing.value = 4;
                sliderShadow.value = 4;
                sliderRangeShadow.value  = 50;
                Translator.Update_texts();
                PlayerPrefs.SetInt("IndexQualite",textQuality.ID_Text);
            }
            
        }
        #endregion

        #region Отоброжение настроек текста текстур
        if(valueTexture == 1) {
            textTexture.ID_Text = 19;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexTextureQuality" , textTexture.ID_Text = 19);
        }
        else if (valueTexture == 2) {
            textTexture.ID_Text = 20;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexTextureQuality" , textTexture.ID_Text = 20);
        }
        else if (valueTexture == 3) {
            textTexture.ID_Text = 21;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexTextureQuality" , textTexture.ID_Text = 21);
        }
        else if (valueTexture == 4) {
            textTexture.ID_Text = 22;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexTextureQuality" , textTexture.ID_Text = 22);
        }
        #endregion

        #region Отоброжение настроек сглаживания
        if(valueAntAliasing == 1)
        {
            textSmoothing.ID_Text = 23;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexSmoothing" , textSmoothing.ID_Text = 23);
        }

        else if(valueAntAliasing == 2)
        {
            textSmoothing.ID_Text = 24;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexSmoothing" , textSmoothing.ID_Text = 24);
        }

        else if(valueAntAliasing == 3)
        {
            textSmoothing.ID_Text = 25;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexSmoothing" , textSmoothing.ID_Text = 25);
        }

        else if(valueAntAliasing == 4)
        {
            textSmoothing.ID_Text = 26;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexSmoothing" , textSmoothing.ID_Text = 26);
        }
        #endregion

        #region Отоброжение качества теней
        if(valueShadow == 1) 
        {
            textShadow.ID_Text = 19;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexQualityShadow" , textShadow.ID_Text = 19);
        }

        else if(valueShadow == 2) 
        {
            textShadow.ID_Text = 20;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexQualityShadow" , textShadow.ID_Text = 20);
        }

        else if(valueShadow == 3) 
        {
            textShadow.ID_Text = 21;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexQualityShadow" , textShadow.ID_Text = 21);
        }
        
        else if(valueShadow == 4) 
        {
            textShadow.ID_Text = 22;
            Translator.Update_texts();
            PlayerPrefs.SetInt("IndexQualityShadow" , textShadow.ID_Text = 22);
        }

        #endregion

        #region Отоброжение дальности теней
        textRangShadow.text = valueRangeShadow.ToString();

        #endregion
    }

    public void Play() 
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSetting()
    {
        menu.SetActive(false);
        setting.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void CloseSetting()
    {
        menu.SetActive(true);
        setting.SetActive(false);
    }

    public void ErrorOpen()
    {
        menu.SetActive(false);
        setting.SetActive(false);
        Error.SetActive(true);
    }

    public void ErrorCloset()
    {
        menu.SetActive(true);
        setting.SetActive(false);
        Error.SetActive(false);
    }

    public void OpenLanguageSetting()
    {
        languageSetting.SetActive(true);
        setting.SetActive(false);
    }

    public void ClosetLanguageSetting()
    {
        languageSetting.SetActive(false);
        setting.SetActive(true);
    }

    public void ChangeLanguahe(string turn) {
        int idLan = 0;
        if(PlayerPrefs.GetInt("Language") == 0) 
        {
            languageNow = "English";
            idLan = 0;
        }
        else if (PlayerPrefs.GetInt("Language") == 1) {
            languageNow = "Русский";
            idLan = 1;
        }

        if(turn == "left")
        {
            if(idLan == 0) idLan = All_language;
            else idLan = idLan -1;
        }

        if(turn == "right")
        {
            if(idLan == All_language) idLan = 0;
            else idLan = idLan + 1;
        }

        PlayerPrefs.SetInt("Language",idLan);
        Translator.Seleck_language(PlayerPrefs.GetInt("Language"));
    }

   public void OnTach()
   {
       audioSource.Play();
   } 

   public void OpenSoundSetting()
   {
       soundSetting.SetActive(true);
       setting.SetActive(false);
   }

    public void ClosetSoundSetting()
   {
       soundSetting.SetActive(false);
       setting.SetActive(true);
   }

    public void OpenQualitySetting()
    {
        setting.SetActive(false);
        qualitySetting.SetActive(true);
    }
    public void ClosetqualiteSetting()
    {
        qualitySetting.SetActive(false);
        setting.SetActive(true);

        //Пременение разрешения
        Screen.SetResolution(resolutions[(int)sliderResolution.value].width,resolutions[(int)sliderResolution.value].height,true);
        PlayerPrefs.SetInt("Resolutions",(int)sliderResolution.value);

        //Качество графики
        switch(valueQuality)
        {
            case 1: QualitySettings.SetQualityLevel(1); break;
            case 2: QualitySettings.SetQualityLevel(2); break;
            case 3: QualitySettings.SetQualityLevel(3); break;
            case 4: QualitySettings.SetQualityLevel(4); break;
        }
        PlayerPrefs.SetInt("QualitySetting",valueQuality);

        //Качество текстур
        switch(valueTexture)
        {
            case 1: QualitySettings.masterTextureLimit = 3; break;
            case 2: QualitySettings.masterTextureLimit = 2; break;
            case 3: QualitySettings.masterTextureLimit = 1; break;
            case 4: QualitySettings.masterTextureLimit = 0; break;
        }
        PlayerPrefs.SetInt("TextureQuality" , valueTexture);

        //Переменная сглаживания
        switch(valueAntAliasing)
        {
            case 1: QualitySettings.antiAliasing = 1; break;
            case 2: QualitySettings.antiAliasing = 2; break;
            case 3: QualitySettings.antiAliasing = 4; break;
            case 4: QualitySettings.antiAliasing = 8; break;
        }
        PlayerPrefs.SetInt("AntAliasing",valueAntAliasing);

        //Переменная качества теней 
        switch(valueShadow)
        {
            case 1 : QualitySettings.shadowResolution = ShadowResolution.Low; break;
            case 2 : QualitySettings.shadowResolution = ShadowResolution.Medium; break;
            case 3 : QualitySettings.shadowResolution = ShadowResolution.High; break;
            case 4 : QualitySettings.shadowResolution = ShadowResolution.VeryHigh; break;
        }
        PlayerPrefs.SetInt("ShadowQuality",valueShadow);

        //Переменная дистанции теней
        QualitySettings.shadowDistance = valueRangeShadow;
        PlayerPrefs.SetInt("ShadowRange",valueRangeShadow);
    }
}
