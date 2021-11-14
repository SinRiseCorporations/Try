using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMenu : MonoBehaviour
{
    public int progressGame;
    public int chapter;
    public GameObject menu;
    public GameObject contineBatton;
    public GameObject newGame;
    public GameObject askReset;
    bool askResetActive;
    public GameObject setting;
    bool settingActive;

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

    private void Awake() {

        if(PlayerPrefs.HasKey("SoundSystem") == false) PlayerPrefs.SetFloat("SoundSystem", 1f);
        settingMenu.valueAudioSourceTach = PlayerPrefs.GetFloat("SoundSystem");
        settingMenu.audioSourceTach.volume = settingMenu.valueAudioSourceTach;

        if(PlayerPrefs.HasKey("SoundMusik") == false) PlayerPrefs.SetFloat("SoundMusik", 1f);
        settingMenu.valueMusicSource = PlayerPrefs.GetFloat("SoundMusik");
        settingMenu.musicAudioSource.volume = settingMenu.valueMusicSource;

        if(PlayerPrefs.HasKey("EffectSound") == false) PlayerPrefs.SetFloat("EffectSound", 1f);
        settingMenu.valumEffectSound = PlayerPrefs.GetFloat("EffectSound");

        if(PlayerPrefs.HasKey("ProgressGame") == false) 
        {
            PlayerPrefs.SetInt("ProgressGame",0);
            contineBatton.SetActive(false);
        }
        else contineBatton.SetActive(true);
        progressGame = PlayerPrefs.GetInt("ProgressGame");

        if(PlayerPrefs.HasKey("Chapter") == false) PlayerPrefs.SetInt("Chapter", 1);
        chapter = PlayerPrefs.GetInt("Chapter");
    }
    
    void Start()
    {
        menu.SetActive(true);

        askReset.SetActive(false);
        askResetActive = false;

        setting.SetActive(false);
        settingActive = false;

        settingMenu.SoundSetting.SetActive(false);
        settingMenu.soundSettinActive = false;
        
        
    }

    
    void Update()
    {
        
    }

    public void Play()
    {
        SoundTachPlay();
        SceneManager.LoadScene(chapter);
    }

    public void NowGame()
    {
        SoundTachPlay();
        if(progressGame == 0)
        {
            Play();
        }
        else
        {
            menu.SetActive(false);
            askReset.SetActive(true);
        }
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
