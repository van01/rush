using UnityEngine;
using System.Collections;

public class StageButtonHandler : MonoBehaviour {
    public GameObject tmpFrontEndController; 

    public void OnClickStageButtonSelfSetting()
    {
        tmpFrontEndController.SendMessage("OnClickStageButton", name);
    }
}
