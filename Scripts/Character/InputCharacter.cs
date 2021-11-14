using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCharacter : MonoBehaviour
{
    public MoveCharacter moveCharacter;

    public SettingGame setting;

    public bool actionEvent;
    [SerializeField] private DynamicJoystick joystick;

    private int pauseMode;

    private float t;

    public void InputUpdate()
    {
        if(!setting.android) PCInput();
        else MobileInputUpdate();
        
    }

    public void FixedUpdate()
    {
        if(!setting.android) PCFixedUpdate();
        else InputMobileFixedUpdate();
    }

    #region  PCInput
    void PCInput()
    {
        InputMovement();
        InputActionEvent();
        PauseModePC();
    }

    void PCFixedUpdate()
    {

    }

    void InputMovement()
    {
        moveCharacter.vertical = Input.GetAxis("Vertical");
        moveCharacter.horizontal = Input.GetAxis("Horizontal");
    }

    void InputActionEvent()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            actionEvent = true;
            Debug.Log("EventWork");
        }
        else actionEvent = false;
    }

    void PauseModePC()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pauseMode == 0){
            Time.timeScale = 1;
            pauseMode += 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && pauseMode != 0))
        {
            Time.timeScale = 0;
            pauseMode -= 1;
        }
        
    }

    #endregion


    #region MobileInput
    void MobileInputUpdate()
    {
        InputMovementMobile();
        //InputActionEventMobile();
    }

    void InputMobileFixedUpdate()
    {
        InputActionEventMobile();
    }

    void InputMovementMobile()
    {
        moveCharacter.vertical = joystick.Vertical * 1.5f;
        moveCharacter.horizontal = joystick.Horizontal * 1.5f;
    }

    void InputActionEventMobile()
    {
        if(actionEvent)
        {
            Debug.Log("EventWork");
            actionEvent = false;
        }
    }

    public void TachActionBatton()
    {
        actionEvent = true;
    }

    #endregion

}
