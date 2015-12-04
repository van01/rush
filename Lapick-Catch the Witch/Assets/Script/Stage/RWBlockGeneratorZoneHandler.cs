using UnityEngine;
using System.Collections;

public class RWBlockGeneratorZoneHandler : MonoBehaviour {

    public GameObject tmpBlockController;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Block")
        {
            tmpBlockController.SendMessage("BlockGenerater");
        }
    }
}
