using UnityEngine;
using System.Collections;

public class RWBlockDestroyZoneHandler : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Block")
        {
            c.SendMessage("CurrentBlockPrefabCountMinusDelivery");
            Destroy(c.gameObject);
            
        }
        else if (c.tag == "RWCoin")
            Destroy(c.gameObject);
    }
}
