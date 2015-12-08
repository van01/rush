using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

    public GameObject HUD;

    public void WhitePanelEffectActiveOn()
    {
        HUD.SendMessage("WhitePanelEffectActiveDelivery", transform);
    }
}
