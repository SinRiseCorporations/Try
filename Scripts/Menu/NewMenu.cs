using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMenu : MonoBehaviour
{

    #region Прогресс в игре
    [Header("Переменная данного эпизода")]
    public int progressGame;
    [Header("Перменная главы.")]
    [Space(5)]
    public int chapter;

    #endregion

    #region Компоненты игрового меню
    [Header("Игровые объекты меню")]
    [Space(5)]
    public GameObject menu;
    public GameObject contineBatton;
    public GameObject newGame;
    public GameObject askReset;
    private bool askResetActive;
    public GameObject setting;
    public GameObject languageChange;
    private bool settingActive;
    public GameObject loading;

    public settngOptions settingMenu;
    [System.Serializable]
    public class settngOptions
    {
        public GameObject SoundSetting;
        public bool soundSettinActive = false;

        public AudioSource audioSourceTach;
        public float valueAudioSourceTach;
        
        public AudioSource musicAudioSource;
        public float valueMusicSource;

        public float valumEffectSound;
    }

    public GameObject[] episodos;

    #endregion

    #region Язык игры

    [Header("Язык выбранный в данный момент")]
    [Space(5)]
    public string language;

    [Header("Количество языков в игре")]
    [Space(5)]
    public int All_language;
    [Header("Вкл/Выкл субтитров")]
    [Space(5)]
    [Range(0,1)]public int SubTitles;
    [SerializeField] private Translation_text_ID subTitleText;

    #endregion
    
    private void Awake() {

        #region Загрузка сохранения настроек звука в игре

        if(PlayerPrefs.HasKey("SoundSystem") == false) PlayerPrefs.SetFloat("SoundSystem", 1f);
        settingMenu.valueAudioSourceTach = PlayerPrefs.GetFloat("SoundSystem");
        settingMenu.audioSourceTach.volume = settingMenu.valueAudioSourceTach;

        if(PlayerPrefs.HasKey("SoundMusik") == false) PlayerPrefs.SetFloat("SoundMusik", 1f);
        settingMenu.valueMusicSource = PlayerPrefs.GetFloat("SoundMusik");
        settingMenu.musicAudioSource.volume = settingMenu.valueMusicSource;

        if(PlayerPrefs.HasKey("EffectSound") == false) PlayerPrefs.SetFloat("EffectSound", 1f);
        settingMenu.valumEffectSound = PlayerPrefs.GetFloat("EffectSound");

        #endregion

        #region Загрузка сохранения прогресса в игре

        if(PlayerPrefs.HasKey("ProgressGame") == false) 
        {
            PlayerPrefs.SetInt("ProgressGame",1);
        }
        else contineBatton.SetActive(true);
        progressGame = PlayerPrefs.GetInt("ProgressGame");

        if(PlayerPrefs.HasKey("Chapter") == false) PlayerPrefs.SetInt("Chapter", 1);
        chapter = PlayerPrefs.GetInt("Chapter");

        #endregion
    
        #region Загрузка сохранения языка в игре

        if(PlayerPrefs.HasKey("Language") == false)
        {
            if(Application.systemLanguage == SystemLanguage.Russian) PlayerPrefs.SetInt("Language",1);
            else PlayerPrefs.SetInt("Language",0);
        }

        Translator.Seleck_language(PlayerPrefs.GetInt("Language"));

        if(PlayerPrefs.HasKey("SubTitles") == false)
        {
            SubTitles = 1;
            PlayerPrefs.SetInt("SubTitles",SubTitles);

        }
        if(PlayerPrefs.GetInt("SubTitles") == 0) subTitleText.ID_Text = 21;
        else if(PlayerPrefs.GetInt("SubTitles") == 1) subTitleText.ID_Text = 20;
        SubTitles = PlayerPrefs.GetInt("SubTitles");
        #endregion

    }
    
    void Start()
    {
        menu.SetActive(true);

        if(progressGame == 1) contineBatton.SetActive(false);
        else contineBatton.SetActive(true);

        askReset.SetActive(false);
        askResetActive = false;

        setting.SetActive(false);
        settingActive = false;

        settingMenu.SoundSetting.SetActive(false);
        settingMenu.soundSettinActive = false;
        
        loading.SetActive(false);

        languageChange.SetActive(false);

        ScensStart();
    }

    void ScensStart()
    {
        for(int i = 0; i < episodos.Length; i++)
        {
            episodos[i].SetActive(false);
        }

        episodos[progressGame].SetActive(true);
    }   

    void Update()
    {
        
    }

    public void Play()
    {
        SoundTachPlay();
        loading.SetActive(true);
        SceneManager.LoadScene(progressGame);
    }

    public void NowGame(string type)
    {
        SoundTachPlay();
        if(type == "open")
        {
            if(progressGame == 1)
            {
                Play();
            }
            else
            {
                menu.SetActive(false);
                askReset.SetActive(true);
            }
        }
        if(type == "closet")
        {
            menu.SetActive(true);
            askReset.SetActive(false);
        }
    }

    public void NowPlay()
    {
        PlayerPrefs.SetInt("ProgressGame" , 1);
        SoundTachPlay();
        loading.SetActive(true);
        progressGame = PlayerPrefs.GetInt("ProgressGame");
        SceneManager.LoadScene(progressGame);
    }

    public void Setting()
    {
        SoundTachPlay();
        if(!settingActive)
        {
        setting.SetActive(true);
        menu.SetActive(false);
        settingActive = true;
        }
        else {
        setting.SetActive(false);
        menu.SetActive(true);
        settingActive = false;
        }
    }

    #region Смена языка
    public void LanguageSettingActive(string type)
    {
        SoundTachPlay();
        if(type == "open")
        {
            setting.SetActive(false);
            languageChange.SetActive(true);
        }
        if(type == "closet")
        {
            setting.SetActive(true);
            languageChange.SetActive(false);
        }
    }

    public void ChangeLanguahe(string turn) {

        SoundTachPlay();

        int idLan = 0;
        if(PlayerPrefs.GetInt("Language") == 0) 
        {
            language = "English";
            idLan = 0;
        }
        else if (PlayerPrefs.GetInt("Language") == 1) {
            language = "Русский";
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

    public void ChangeSubTitles(string turn)
    {
        SoundTachPlay();

        if(turn == "left")
        {
            if(SubTitles == 0) SubTitles = 1;
            else SubTitles = 0;
        }

        if(turn == "right")
        {
            if(SubTitles == 1) SubTitles = 0;
            else SubTitles = 1;
        }

        PlayerPrefs.SetInt("SubTitles",SubTitles);
        if((PlayerPrefs.GetInt("SubTitles") == 0)) subTitleText.ID_Text = 21;
        else if((PlayerPrefs.GetInt("SubTitles") == 1)) subTitleText.ID_Text = 20;
        Translator.Update_texts();
    }

    #endregion

    #region Отдел настроек 

    public void SoundSetting()
    {
        SoundTachPlay();
        if(!settingMenu.soundSettinActive)
        {
            setting.SetActive(false);
            settingMenu.SoundSetting.SetActive(true);
            settingMenu.soundSettinActive = true;
        }
        
        else{
            setting.SetActive(true);
            settingMenu.SoundSetting.SetActive(false);
            settingMenu.soundSettinActive = false;
        }
    }

    void SoundTachPlay()
    {
        settingMenu.audioSourceTach.Play();
    }
    #endregion
    public void ExitGame()
    {
        SoundTachPlay();
        Application.Quit();
    }

}
