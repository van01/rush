using UnityEngine;
using System.Collections;

public class RWDeadZoneHandler : MonoBehaviour {
    public GameObject tmpGameController;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            tmpGameController.SendMessage("RWGameOver");
        }
    }
}
