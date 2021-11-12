using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePart : MonoBehaviour
{
    
    public Menu menu;

    public void finishChangePart()
    {
        menu.nowChange = false;
    }

    public void ChangeForwardNextPart()
    {
        menu.changeImage.sprite = menu.spritePatrGame[menu.partGame];
    }

    public void ChangePartNow()
    {
        menu.nowImage.sprite = menu.spritePatrGame[menu.partGame - 1];
    }

    public void RealChangePart()
    {
        menu.leaImage.sprite = menu.spritePatrGame[menu.partGame];
    }
}
