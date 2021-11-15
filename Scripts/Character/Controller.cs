using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private InputCharacter inputCharacter;
    private MoveCharacter moveCharacter;
    private AnimationCharacter animationCharacter;
     
    private void Start() {
        inputCharacter = gameObject.GetComponent<InputCharacter>();
        moveCharacter = gameObject.GetComponent<MoveCharacter>();
        animationCharacter = gameObject.GetComponent<AnimationCharacter>();
    }
    void Update()
    {
        inputCharacter.InputUpdate();
        moveCharacter.MoveUpdate();
        animationCharacter.AnimatorUpdate();
    }
}
