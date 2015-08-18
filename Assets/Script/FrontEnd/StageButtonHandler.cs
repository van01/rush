using UnityEngine;
using System.Collections;

public class StageButtonHandler : MonoBehaviour {
    public GameObject tmpFrontEndController;

    public enum StageType
    {
        DiceForest,
        Kingdom,
    }

    public StageType currentStage;

    public void OnClickStageButtonSelfSetting()
    {
        tmpFrontEndController.SendMessage("OnClickStageButton", name);
    }
}
