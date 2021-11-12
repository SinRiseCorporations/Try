using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public InputCharacter inputCharacter;
    public MoveCharacter moveCharacter;
    public AnimationCharacter animationCharacter;
     

    void Update()
    {
        inputCharacter.InputUpdate();
        moveCharacter.MoveUpdate();
        animationCharacter.AnimatorUpdate();
    }
}
