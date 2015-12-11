using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

    public GameObject HUD;

    public void WhitePanelEffectActiveOn()
    {
        HUD.SendMessage("WhitePanelEffectActiveDelivery", transform);
    }

    public void BottomHomePanelInitializeDelivery()
    {
        HUD.SendMessage("BottomHomePanelInitialize");
    }

    public void BottomMenuDisable()
    {
        HUD.GetComponent<HUDHandler>().bottomPanel.GetComponent<HUDBottomHandler>().menuPanel.GetComponent<HUDMenuButtonHandler>().SendMessage("AllButtonDisable");
    }

    public void BottomMenuAble()
    {
        HUD.GetComponent<HUDHandler>().bottomPanel.GetComponent<HUDBottomHandler>().menuPanel.GetComponent<HUDMenuButtonHandler>().SendMessage("AllButtonAble");
    }
}
