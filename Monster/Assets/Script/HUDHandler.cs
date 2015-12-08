using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

    public GameObject tmpGameController;
    public GameObject whitePanel;

    public void WhitePanelEffectActiveDelivery(Transform nTransform)
    {
        whitePanel.SetActive(true);

        whitePanel.SendMessage("WhitePanelEffectActive", nTransform);
    }

    public void WhitePanelOff()
    {
        whitePanel.SetActive(false);
    }

    public void CurrentEggDestroyDelivery()
    {
        tmpGameController.SendMessage("CurrentEggDestroy");
    }
}
