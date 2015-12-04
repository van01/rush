﻿using UnityEngine;
using System;
using System.Collections;

public class RWStageScrollBlockController : MonoBehaviour {

    private Transform tmpScrollBlockTransfrom;

    private SpriteRenderer[] myAllSpriteRenderer;

    void Start()
    {
        tmpScrollBlockTransfrom = transform.FindChild("FloorScrollBlock");
        myAllSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

	public void DeliveryFloorScrollSpeedValue(float fSC)
    {
        tmpScrollBlockTransfrom.SendMessage("DeliveryFloorScrollSpeed", fSC);
    }

    public void BlockScrollOn()
    {
        tmpScrollBlockTransfrom.SendMessage("StageBlockScrollOn");
        tmpScrollBlockTransfrom.SendMessage("BlockGeneraterInit");

    }

    public void BlockScrollOff()
    {
        tmpScrollBlockTransfrom.SendMessage("BlockScrollOff");
    }

    //level
    //tmpScrollBlockTransfrom

    public void PresentBlockColMinSizeXDelivery(string nMinSize)
    {
        tmpScrollBlockTransfrom.SendMessage("PresentBlockColMinSizeX", Convert.ToInt32(nMinSize));
    }

    public void PresentBlockColMaxSizeXDelivery(string nMaxSize)
    {
        tmpScrollBlockTransfrom.SendMessage("PresentBlockColMaxSizeX", Convert.ToInt32(nMaxSize));
    }

    public void PresentBlockSpaceMinSizeXDelivery(string nMinSize)
    {
        tmpScrollBlockTransfrom.SendMessage("PresentBlockSpaceMinSizeX", float.Parse(nMinSize));
    }

    public void PresentBlockSpaceMaxSizeXDelivery(string nMaxSize)
    {
        tmpScrollBlockTransfrom.SendMessage("PresentBlockSpaceMaxSizeX", float.Parse(nMaxSize));
    }

    public void PresentBlockSpaceMinSizeYDelivery(string nMinSize)
    {
        tmpScrollBlockTransfrom.SendMessage("PresentBlockSpaceMinSizeY", float.Parse(nMinSize));
    }

    public void PresentBlockSpaceMaxSizeYDelivery(string nMaxSize)
    {
        tmpScrollBlockTransfrom.SendMessage("PresentBlockSpaceMaxSizeY", float.Parse(nMaxSize));
    }

    public void BlockNumberinitializeDelivery()
    {
        tmpScrollBlockTransfrom.SendMessage("BlockNumberinitialize");
    }

    public void CurrentCoinCountMinusDelivery()
    {
        tmpScrollBlockTransfrom.SendMessage("CurrentCoinCountMinus");
    }

    void RWStageFloorColorApply(Vector4 nColor)
    {
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            if (myAllSpriteRenderer[i].GetComponent<StageBGColorApply>().BGColorApply == true)
            {
                myAllSpriteRenderer[i].color = nColor;
            }
        }

        tmpScrollBlockTransfrom.SendMessage("BGFloorColorDelivery", nColor);
    }
}