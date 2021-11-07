using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("Язык который выбран сейчас.")]
    public string languageNow;
    [Header("Количество Языков в игре.")]
    public int All_language;
    [Header("Игровые объекты.")]
    public GameObject menu;
    public GameObject setting;
    public GameObject Error;
    public GameObject languageSetting;
    public GameObject soundSetting;

    [Space(10)]
    public AudioSource audioSource;
    public Slider sliderSoundSystem;
    public float lvl_sound_system;
    public TextMeshProUGUI text_sound_system;


    private void Start() {

        menu.SetActive(true);
        setting.SetActive(false);
        Error.SetActive(false);
        languageSetting.SetActive(false);
        soundSetting.SetActive(false);

        if(PlayerPrefs.HasKey("Language")== false) {
            if(Application.systemLanguage == SystemLanguage.Russian) PlayerPrefs.SetInt("Language",1);
            else PlayerPrefs.SetInt("Language",0);
        }
        Translator.Seleck_language(PlayerPrefs.GetInt("Language"));

        if(PlayerPrefs.HasKey("SystemSound") == false) PlayerPrefs.SetFloat("SystemSound",1);
        sliderSoundSystem.value = PlayerPrefs.GetFloat("SystemSound");
    }

    private void Update() {
        lvl_sound_system = sliderSoundSystem.value;
        audioSource.volume = lvl_sound_system;
        PlayerPrefs.SetFloat("SystemSound",lvl_sound_system);
        text_sound_system.text = Mathf.Round((PlayerPrefs.GetFloat("SystemSound")*100)).ToString();
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

}
