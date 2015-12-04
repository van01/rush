using UnityEngine;
using System.Collections;

public class FloorScroll : MonoBehaviour {
   
    private bool scrollOn;
    private float scrollSpeed;
        
    private bool blockGeneraterOn = false;

    private Transform tmpBaseBlockTransform;

    private float beginPositionY;

    void Start()
    {
        tmpBaseBlockTransform = transform.FindChild("BaseBlock");
        beginPositionY = transform.position.y;
    }

    void Update () {
        if (scrollOn == true)
        {
            Vector3 scrollValue = Vector3.left * scrollSpeed * Time.deltaTime;
          
            transform.Translate(scrollValue, Space.World);
            if (blockGeneraterOn == false)
            {
                blockGeneraterOn = true;
            }
        }
    }

    public void DeliveryFloorScrollSpeed(float fSC)
    {
        scrollSpeed = fSC;
    }

    public void BlockScrollOff()
    {
        scrollOn = false;
    }

    public void StageBlockScrollOn()
    {
        scrollOn = true;
        tmpBaseBlockTransform.SendMessage("ScrollOffBaseBlock");
    }

    public void ResetBlockScroll()
    {
        transform.position = new Vector3(0, beginPositionY, 0);
    }
}
