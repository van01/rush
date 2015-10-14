using UnityEngine;
using System.Collections;

public class RWUICharacterSizeHandler : MonoBehaviour {

    private Transform bigZoneTransform;

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
        }
        else
        {
            transform.localScale = Vector3.one;
        }

    }
}
