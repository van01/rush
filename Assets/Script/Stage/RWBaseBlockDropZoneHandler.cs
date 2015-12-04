using UnityEngine;
using System.Collections;

public class RWBaseBlockDropZoneHandler : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "BaseBlock")
            c.SendMessage("BaseBlockDrop");
    }
}
