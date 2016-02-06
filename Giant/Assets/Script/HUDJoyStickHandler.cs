using UnityEngine;
using System.Collections;

public class HUDJoyStickHandler : MonoBehaviour {

    public GameObject tmpGameController;

    public void InputDelivery(HUDStickHandler.StickWay _stickWay)
    {
        if (_stickWay == HUDStickHandler.StickWay.Neutral)
            tmpGameController.SendMessage("JoyStickNeutral");                  //초기화
        else if (_stickWay == HUDStickHandler.StickWay.Left)
            tmpGameController.SendMessage("JoyStickLeft");
        else if (_stickWay == HUDStickHandler.StickWay.Right)
            tmpGameController.SendMessage("JoyStickRight");
        else if (_stickWay == HUDStickHandler.StickWay.LeftDown)
            tmpGameController.SendMessage("JoyStickLeftDown");
        else if (_stickWay == HUDStickHandler.StickWay.RightDown)
            tmpGameController.SendMessage("JoyStickRightDown");
        else if (_stickWay == HUDStickHandler.StickWay.LeftUp)
            tmpGameController.SendMessage("JoyStickLeftUp");
        else if (_stickWay == HUDStickHandler.StickWay.RightUp)
            tmpGameController.SendMessage("JoyStickRightUp");
        else if (_stickWay == HUDStickHandler.StickWay.Up)
            tmpGameController.SendMessage("JoyStickUp");
        else if (_stickWay == HUDStickHandler.StickWay.Down)
            tmpGameController.SendMessage("JoyStickDown");
        
    }
}
