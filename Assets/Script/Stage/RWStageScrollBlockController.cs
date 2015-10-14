using UnityEngine;
using System.Collections;

public class RWStageScrollBlockController : MonoBehaviour {

    private Transform tmpScrollBlockTransfrom;

    void Start()
    {
        tmpScrollBlockTransfrom = transform.FindChild("FloorScrollBlock");
    }

	public void DeliveryFloorScrollSpeedValue(float fSC)
    {
        tmpScrollBlockTransfrom.SendMessage("DeliveryFloorScrollSpeed", fSC);
    }

    public void BlockScrollOn()
    {
        tmpScrollBlockTransfrom.SendMessage("StageBlockScrollOn");
        tmpScrollBlockTransfrom.SendMessage("BlockGeneraterInit");

    }

    public void BlockScrollOff()
    {
        tmpScrollBlockTransfrom.SendMessage("BlockScrollOff");
    }
}
