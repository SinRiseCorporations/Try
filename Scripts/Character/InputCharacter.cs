using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCharacter : MonoBehaviour
{
    private MoveCharacter moveCharacter;
    private StaticCharacter staticCharacter;
    [Header("Настройки меню , указать из папки скриптов")]
    public SettingGame setting;
    [HideInInspector]
    public bool actionEvent;
    
    //[SerializeField] private DynamicJoystick joystick;

    [HideInInspector]
    public int pauseID;

    private float t;

    private void Awake() {
        moveCharacter = gameObject.GetComponent<MoveCharacter>();
        staticCharacter = gameObject.GetComponent<StaticCharacter>();
    }

    public void InputUpdate()
    {
        if(!staticCharacter.changeLocal.changeLocations){
            if(!setting.android) PCInput();
            else MobileInputUpdate();

            pauseID = Mathf.Clamp(pauseID,0,1);

        }
    }

    public void FixedUpdate()
    {
        if(!setting.android)
        {
             PCFixedUpdate();
            if(actionEvent)
            {
                Debug.Log("work");
                actionEvent = false;
            }
        }
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
        //else actionEvent = false;
    }

    void PauseModePC()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pauseID == 0){
            pauseID += 1;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && pauseID != 0))
        {
            pauseID -= 1;
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
        moveCharacter.vertical = staticCharacter.canvas.joystick.Vertical * 1.5f;
        moveCharacter.horizontal = staticCharacter.canvas.joystick.Horizontal * 1.5f;
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

    public void PauseMobileInput()
    {
        pauseID += 1;
    }

    public void ClosetPauseWindow()
    {
        pauseID -= 1;
    }

    #endregion

}
