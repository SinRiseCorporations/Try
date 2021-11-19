using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    [Header("Переменная отвечающая за не воспрпоизведения скрипта повторно")]
    public int wasTalk = 0;

    [Header("Текс который неообходимо персонажу сказать")]
    [Space(10)]
    public string texttalk;

    [Header("Время которе будет висеть данный текст")]
    [Space(10)]
    public float time;

    [Header("Звук необходиммый воспроизвести")]
    public AudioClip clip;

    [SerializeField]private AudioSource source;

    private bool stay;

    private StaticCharacter subTible;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Character")
        {
            stay = true;
            subTible = other.gameObject.GetComponent<StaticCharacter>();
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Character")
        {
            stay = true;
            subTible = other.gameObject.GetComponent<StaticCharacter>();
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Character")
        {
            stay = false;
            subTible = null;
        }
    }
    
    
    void Update()
    {
        if(stay)
        {
            if(wasTalk == 0)
            {
                SoundPlay();

                if(texttalk != null)
                {
                    subTible.subtibleText = texttalk;
                    subTible.timeClearSubtibleText = time;

                    wasTalk = 1;

                    gameObject.SetActive(false);
                }

            }
        }
    }

    void SoundPlay()
    {
        if(source!= null)
        {
            if(clip != null)
            {
                source.PlayOneShot(clip);
            }
        }
    }

}
