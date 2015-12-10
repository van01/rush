using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

    public GameObject tmpGameController;
    public GameObject whitePanel;

    public GameObject bottomPanel;

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
        tmpGameController.SendMessage("CurrentEggDestroy");     //이 부분이 hudHandler에 있는게 이상함
    }

    public void BottomHomePanelInitialize()
    {
        bottomPanel.GetComponent<HUDBottomHandler>().SendMessage("MonsterInfoInitialIzeRefresh");
    }
}
