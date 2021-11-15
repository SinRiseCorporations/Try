using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    
    private Animator animator;
    private MoveCharacter moveCharacter;
    
    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        moveCharacter = gameObject.GetComponent<MoveCharacter>();
    }

    public void AnimatorUpdate()
    {
        animator.SetFloat("Movement",moveCharacter.moveAmount,0.15f, Time.deltaTime);
    }
}
