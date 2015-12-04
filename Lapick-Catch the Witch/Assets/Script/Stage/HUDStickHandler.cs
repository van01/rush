using UnityEngine;
using System.Collections;

public class HUDStickHandler : MonoBehaviour {

    public GameObject tmpJoyStick;

    public enum StickWay
    {
        Neutral,
        LeftUp,
        Up,
        RightUp,
        Left,
        Right,
        LeftDown,
        Down,
        RightDown,
    }

    public StickWay currentStickWay;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "LeftUp")
        {
            currentStickWay = StickWay.LeftUp;
            SendingCurrentStickWay();
        }
        if (c.name == "CenterUp")
        {
            currentStickWay = StickWay.Up;
            SendingCurrentStickWay();
        }
        if (c.name == "RightUp")
        {
            currentStickWay = StickWay.RightUp;
            SendingCurrentStickWay();
        }

        if (c.name == "Left")
        {
            currentStickWay = StickWay.Left;
            SendingCurrentStickWay();
        }
        if (c.name == "Right")
        {
            currentStickWay = StickWay.Right;
            SendingCurrentStickWay();
        }

        if (c.name == "LeftDown")
        {
            currentStickWay = StickWay.LeftDown;
            SendingCurrentStickWay();
        }
        if (c.name == "CenterDown")
        {
            currentStickWay = StickWay.Down;
            SendingCurrentStickWay();
        }
        if (c.name == "RightDown")
        {
            currentStickWay = StickWay.RightDown;
            SendingCurrentStickWay();
        }

        if (c.name == "DeadZone")
        {
            currentStickWay = StickWay.Neutral;
            SendingCurrentStickWay();
        }
    }

    public void CurrentStickNeutral()
    {
        currentStickWay = StickWay.Neutral;
        SendingCurrentStickWay();
    }

    void SendingCurrentStickWay()
    {
        tmpJoyStick.SendMessage("InputDelivery", currentStickWay);
    }

    
}
