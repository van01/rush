using UnityEngine;
using System.Collections;

public class FloorScroll : MonoBehaviour {

    private bool scrollOn = true;
    private float scrollSpeed;

    void Update () {
        if (scrollOn == true)
        {
            Vector3 scrollValue = Vector3.left * scrollSpeed * Time.deltaTime;

            transform.Translate(scrollValue, Space.World);
        }
    }

    public void DeliveryFloorScrollSpeed(float fSC)
    {
        scrollSpeed = fSC;
    }

    public void ScrollOnFalse()
    {
        scrollOn = false;
        print("Scroll Block Stop");
    }
}
