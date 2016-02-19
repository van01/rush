using UnityEngine;
using System.Collections;

public class HUDTrainingUIHandler : MonoBehaviour {

    public GameObject resultTxt;
    public GameObject resultPopup;

    public void TrainingResultUIOff()
    {
        resultPopup.SetActive(false);
        resultTxt.SetActive(false);

        GetComponent<HUDHandler>().tmpGameController.SendMessage("RoomOutEnd");    //종료
    }

    public void ResultTxtOn()
    {
        resultTxt.SetActive(true);
    }

    public void ResultPopupOn()
    {
        resultPopup.SetActive(true);
    }
}
