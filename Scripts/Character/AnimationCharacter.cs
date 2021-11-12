using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    
    public Animator animator;
    public MoveCharacter moveCharacter;
    
    public void AnimatorUpdate()
    {
        animator.SetFloat("Movement",moveCharacter.moveAmount,0.15f, Time.deltaTime);
    }
}
