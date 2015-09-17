using UnityEngine;
using System.Collections;

public class HUDJoyStickHandler : MonoBehaviour {

    public GameObject tmpGameController;

    public void InputDelivery(HUDStickHandler.StickWay _stickWay)
    {
        if (_stickWay == HUDStickHandler.StickWay.Neutral)
            tmpGameController.SendMessage("Left02Up");                  //초기화
        else if (_stickWay == HUDStickHandler.StickWay.Right)
            tmpGameController.SendMessage("Left02Down");                //달리기, 현재는 임시로 기존 코드 그대로 사용, HUDController에 신규 코드 추가 필요

        print(_stickWay);
    }
}
