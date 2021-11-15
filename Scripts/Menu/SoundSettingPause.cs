using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SoundSettingPause : MonoBehaviour
{
    public PauseCharacter pauseCharacter;
    public TextMeshProUGUI textSoundSystem;
    public Slider scrollSoundSystem;
    public float valueAudioSourceTach;

    public TextMeshProUGUI textMusikSound;
    public Slider sliderMusicSound;
    public float valueMusicSource;
    public TextMeshProUGUI textEffectSount;
    public Slider sliderEffectSound;
    public float valumEffectSound;
    private void Start()
    {
        valueAudioSourceTach = PlayerPrefs.GetFloat("SoundSystem");
        scrollSoundSystem.value = valueAudioSourceTach;
        textSoundSystem.text = Mathf.Round(valueAudioSourceTach*100).ToString();

        valueMusicSource = PlayerPrefs.GetFloat("SoundMusik");
        sliderMusicSound.value = valueMusicSource;
        textMusikSound.text = Mathf.Round(valueMusicSource*100).ToString();

        valumEffectSound = PlayerPrefs.GetFloat("EffectSound");
        sliderEffectSound.value = valumEffectSound;
        textEffectSount.text = Mathf.Round(valumEffectSound * 100).ToString();
    }

    
    void Update()
    {
        if(pauseCharacter.soundSettingAction)
        {
            valueAudioSourceTach = scrollSoundSystem.value;

            PlayerPrefs.SetFloat("SoundSystem", scrollSoundSystem.value);

            textSoundSystem.text = Mathf.Round(valueAudioSourceTach*100).ToString();

            valueMusicSource = sliderMusicSound.value;

            PlayerPrefs.SetFloat("SoundMusik", sliderMusicSound.value);

            textMusikSound.text = Mathf.Round(valueMusicSource*100).ToString();

            valumEffectSound = sliderEffectSound.value;

            PlayerPrefs.SetFloat("EffectSound",sliderEffectSound.value);

            textEffectSount.text = Mathf.Round(valumEffectSound * 100).ToString();
        }
    }
}
