using UnityEngine;
using System.Collections;

public class RWHelmetDrawZoneHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "UI_Character")
        {
            c.SendMessage("CharacterOn");
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "UI_Character")
        {
            c.SendMessage("CharacterOff");
        }
    }
}
