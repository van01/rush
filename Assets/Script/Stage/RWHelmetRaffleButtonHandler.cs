using UnityEngine;
using System;
using System.Collections;

public class RWHelmetRaffleButtonHandler : MonoBehaviour
{
    public GameObject tmpHelmetRafflePanal;

    protected int helmetRafflePrice = 50;

    protected int presentTotalCoin;

    public void HelmetRaffleSelectButtonActive()
    {
        presentTotalCoin = Convert.ToInt32(PlayerPrefs.GetString("TotalCoin"));

        if (presentTotalCoin >= helmetRafflePrice)
        {
            tmpHelmetRafflePanal.SendMessage("CompulsionTargetDelivery", transform);
            tmpHelmetRafflePanal.SendMessage("HelmetRaffleActive");
            tmpHelmetRafflePanal.SendMessage("DisAblePanelOn");

            TotalCoinSubtraction();
            tmpHelmetRafflePanal.SendMessage("TotalCoinRefreshDelivery");
        }
        else
        {
            tmpHelmetRafflePanal.SendMessage("AlertPanelActiveDelivery", 1);
        }
    }

    public void AttackButtonEnd()
    {
        tmpHelmetRafflePanal.SendMessage("CharacterDestroy");
        tmpHelmetRafflePanal.SendMessage("DisAblePanelOff");
        tmpHelmetRafflePanal.SendMessage("RaffleCharacterDraw");

        tmpHelmetRafflePanal.SendMessage("ResultPanelActive");
    }

    protected void TotalCoinSubtraction()
    {
        presentTotalCoin = presentTotalCoin - helmetRafflePrice;

        PlayerPrefs.SetString("TotalCoin", presentTotalCoin.ToString());
    }
}
