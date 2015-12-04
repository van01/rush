using UnityEngine;
using System.Collections;

public class RWUICharacterSizeHandler : MonoBehaviour {

    private Transform bigZoneTransform;
    private bool stateDeliveryJeged;

    void Start()
    {
        bigZoneTransform = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.FindChild("BigZone");
    }

    void Update()
    {
        if (Vector3.Distance(bigZoneTransform.position, transform.position) <= 1f)
        {   
            float distance = 1.5f - Vector3.Distance(bigZoneTransform.position, transform.position);

            if (distance >= 1.0f)
                transform.localScale = Vector3.one * distance;

            if (stateDeliveryJeged == false)
            {
                if (GetComponent<RWHelmetButtonHandler>().characterAble == true)
                {
                    SendMessage("PresentPlayerCharacterStateChange", "RWPlay");
                    SendMessage("PresentPlayerCharacterAniSpeed", 1);
                }
                    

                transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SendMessage("CurrentHelmetButtonInitailize", gameObject);

                transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SendMessage("HelmetNameTextInitailize", GetComponent<RWHelmetButtonHandler>().helmetNumber);
                transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SendMessage("HelmetActiveButtonInitailize", GetComponent<RWHelmetButtonHandler>().currentHelmetButtonState);
                stateDeliveryJeged = true;
            }
        }
        else
        {
            transform.localScale = Vector3.one;

            if (stateDeliveryJeged == true)
            {
                if (GetComponent<RWHelmetButtonHandler>().characterAble == true)
                    SendMessage("PresentPlayerCharacterStateChange", "RWHold");

                stateDeliveryJeged = false;
            }
        }

    }
}
