using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCharacter : MonoBehaviour
{
    public GameObject pauseWindow;
    public GameObject loadWindow;
    public GameObject soundSetting;
    public AllComponentsCanvas canvas;

    public bool soundSettingAction;

    public AudioSource TachSource;
    public AudioClip tachClip;

    void Start()
    {
        
    }

    
    void Update()
    {
        TachSource.volume = PlayerPrefs.GetFloat("SoundSystem");

        if(canvas.pauseAction)
        {
            pauseWindow.SetActive(true);
            Time.timeScale = 0;

        }
        else 
        {
            pauseWindow.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnTachPlaySound()
    {
        TachSource.PlayOneShot(tachClip);
    }

    public void BackInMenuBatton()
    {
        loadWindow.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void NewGameLoading()
    {
        loadWindow.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void SettingSoundPauseGame()
    {
        if(!soundSettingAction)
        {
            soundSetting.SetActive(true);
            soundSettingAction = true;
        }
        else 
        {
            soundSetting.SetActive(false);
            soundSettingAction = false;
        }
    }
}
