using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundSetting : MonoBehaviour
{
    public NewMenu menu;
    public TextMeshProUGUI textSoundSystem;
    public Slider scrollSoundSystem;

    public TextMeshProUGUI textMusikSound;
    public Slider sliderMusicSound;

    public TextMeshProUGUI textEffectSount;
    public Slider sliderEffectSound;

    private void Start()
    {
        scrollSoundSystem.value = menu.settingMenu.valueAudioSourceTach;
        textSoundSystem.text = Mathf.Round(menu.settingMenu.valueAudioSourceTach*100).ToString();

        sliderMusicSound.value = menu.settingMenu.valueMusicSource;
        textMusikSound.text = Mathf.Round(menu.settingMenu.valueMusicSource*100).ToString();

        sliderEffectSound.value = menu.settingMenu.valumEffectSound;
        textEffectSount.text = Mathf.Round(menu.settingMenu.valumEffectSound * 100).ToString();
    }

    
    void Update()
    {
        if(menu.settingMenu.soundSettinActive)
        {
            menu.settingMenu.valueAudioSourceTach = scrollSoundSystem.value;
            menu.settingMenu.audioSourceTach.volume = scrollSoundSystem.value;

            PlayerPrefs.SetFloat("SoundSystem", scrollSoundSystem.value);

            textSoundSystem.text = Mathf.Round(menu.settingMenu.valueAudioSourceTach*100).ToString();

            menu.settingMenu.valueMusicSource = sliderMusicSound.value;
            menu.settingMenu.musicAudioSource.volume = sliderMusicSound.value;

            PlayerPrefs.SetFloat("SoundMusik", sliderMusicSound.value);

            textMusikSound.text = Mathf.Round(menu.settingMenu.valueMusicSource*100).ToString();

            menu.settingMenu.valumEffectSound = sliderEffectSound.value;

            PlayerPrefs.SetFloat("EffectSound",sliderEffectSound.value);

            textEffectSount.text = Mathf.Round(menu.settingMenu.valumEffectSound * 100).ToString();
        }
    }
}
