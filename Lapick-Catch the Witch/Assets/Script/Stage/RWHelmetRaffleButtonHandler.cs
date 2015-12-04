using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class RWHelmetRaffleButtonHandler : MonoBehaviour
{
    public GameObject tmpHelmetRafflePanal;
    public GameObject tmpTreasureBox;

    public GameObject priceText;

    protected int helmetRafflePrice = 50;

    protected int presentTotalCoin;

    void Start()
    {
        priceText.GetComponent<Text>().text = helmetRafflePrice.ToString();
    }

    public void HelmetRaffleSelectButtonActive()
    {
        presentTotalCoin = Convert.ToInt32(PlayerPrefs.GetString("TotalCoin"));

        if (tmpHelmetRafflePanal.GetComponent<RWRaffleHandler>().ItemFull == true)
            tmpHelmetRafflePanal.SendMessage("AlertPanelActiveDelivery", 2);
        else
        {
            if (presentTotalCoin >= helmetRafflePrice)
            {
                tmpHelmetRafflePanal.SendMessage("CompulsionTargetDelivery", tmpTreasureBox.transform);
                
                tmpHelmetRafflePanal.SendMessage("HelmetRaffleActive");
                tmpHelmetRafflePanal.SendMessage("DisAblePanelOn");

                TotalCoinSubtraction();
                tmpHelmetRafflePanal.SendMessage("TotalCoinRefreshDelivery");
            }
            else
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
