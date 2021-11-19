using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    [Header("Переменная отвечающая за не воспрпоизведения скрипта повторно")]
    public int wasTalk = 0;

    [SerializeField]private AudioSource source;

    private bool stay;

    private StaticCharacter subTible;

    public List<StaticCharacter.SubTitlesClass> talk = new List<StaticCharacter.SubTitlesClass>();

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
                if(talk.Count!=0)
                {
                    Debug.Log("Work");
                    for (int i =0; i < talk.Count;i++)
                    {
                    subTible.subTitles.Add(talk[i]);
                    
                    wasTalk = 1;

                    if(i == talk.Count) gameObject.SetActive(false);
                    }
                }

            }
        }
    }

}
