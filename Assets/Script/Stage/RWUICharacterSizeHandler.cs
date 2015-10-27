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
                SendMessage("PresentPlayerCharacterStateChange", "RWPlay");
                SendMessage("PresentPlayerCharacterAniSpeed", 1);
                stateDeliveryJeged = true;
            }
        }
        else
        {
            transform.localScale = Vector3.one;

            if (stateDeliveryJeged == true)
            {
                SendMessage("PresentPlayerCharacterStateChange", "RWHold");
                stateDeliveryJeged = false;
            }
        }

    }
}
