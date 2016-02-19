using UnityEngine;
using System.Collections;

public class TrainingDramaticHandler : MonoBehaviour {

    public GameObject gameContoller;

    public void SuccessUIOnDelivery()
    {
        gameContoller.GetComponent<HUDController>().HUD.SendMessage("ResultTxtOn");
        StartCoroutine(TrainingResultPopupCall());
    }


    IEnumerator TrainingResultPopupCall()
    {
        yield return new WaitForSeconds(1.5f);
        gameContoller.GetComponent<HUDController>().HUD.SendMessage("ResultPopupOn");
    }

}
