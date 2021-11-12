using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCharacter : MonoBehaviour
{
    public MoveCharacter moveCharacter;

    public SettingGame setting;

    public bool actionEvent;
    [SerializeField] private DynamicJoystick joystick;
    public void InputUpdate()
    {
        if(!setting.android) PCInput();
        else MobileInput();
        
    }

    void PCInput()
    {
        InputMovement();
        InputActionEvent();
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

    void MobileInput()
    {
        moveCharacter.vertical = joystick.Vertical * 1.5f;
        moveCharacter.horizontal = joystick.Horizontal * 1.5f;
    }
}
