using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryTalk : MonoBehaviour
{
    public string talk;
    public float time;

    public StaticCharacter state;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Character")
        {
            state = other.GetComponent<StaticCharacter>();
            state.subtibleText = talk;
            state.timeClearSubtibleText = time;
        }
    }


    private void OnTriggerExit(Collider other) {
        
            state = null;
            state.subtibleText = null;
            state.timeClearSubtibleText = 0;
        
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
