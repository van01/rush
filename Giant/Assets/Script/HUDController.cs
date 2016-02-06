using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

    public void JoyStickNeutral()
    {
        print("JoyStickNeutral");

        SendMessage("currentPlayerIdle");
    }

    public void JoyStickLeft()
    {
        print("JoyStickLeft");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickRight()
    {
        print("JoyStickRight");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickLeftUp()
    {
        print("JoyStickLeftUp");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickRightUp()
    {
        print("JoyStickRightUp");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickLeftDown()
    {
        print("JoyStickLeftDown");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickRightDown()
    {
        print("JoyStickRightDown");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickUp()
    {
        print("JoyStickUp");

        SendMessage("currentPlayerRun");
    }

    public void JoyStickDown()
    {
        print("JoyStickDown");

        SendMessage("currentPlayerRun");
    }

    public void Attack()
    {
        GetComponent<CharacterHandler>().playerObject.SendMessage("AttackWarmUp");
    }

}
