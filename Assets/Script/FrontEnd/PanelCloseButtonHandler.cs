using UnityEngine;
using System.Collections;

public class PanelCloseButtonHandler : MonoBehaviour {
    public GameObject tmpFrontEndController;

    public void OnClickPanelCloseButtonSelfSetting()
    {
        tmpFrontEndController.SendMessage("OnClickPanelCloseButton", transform.parent.name);
    }
}
