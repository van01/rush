using UnityEngine;
using System.Collections;

public class RWStageScrollBlockController : MonoBehaviour {

    private GameObject tmpScrollBlock;

	public void DeliveryFloorScrollSpeedValue(float fSC)
    {
        transform.FindChild("FloorScrollBlock").SendMessage("DeliveryFloorScrollSpeed", fSC);
    }

    public void BlockScrollOnFalse()
    {
        transform.FindChild("FloorScrollBlock").SendMessage("ScrollOnFalse");
        print("Scroll Block Stop Delivery");
    }
}
