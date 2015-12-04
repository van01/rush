using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool characterHealthBar;
    protected int currentCoinCount;

    private int currentBestBlockCount;

    void Start()
    {
        if (GetComponent<StageController>().isRWStage == true)
            SendMessage("GameStateControll", "Lobby");
        else
            SendMessage("GameStateControll", "Ready");

        CharacterHealthBarOff();

        if (PlayerPrefs.GetString("TotalCoin") == "")               //최초 실행 시 실행
        {
            PlayerPrefs.SetString("TotalCoin", "0");
            print(PlayerPrefs.GetString("TotalCoin"));
        }
        //PlayerPrefs.DeleteAll();
    }

    void CharacterHealthBarOff()
    {
        if (characterHealthBar == false)
        {
            SendMessage("PlayerHealthBarOff");
        }
    }

    /// <summary>
    /// Lapick ~ Rushing to Witch ~
    /// </summary>
    /// 
    public void RWGameOver()
    {
        SendMessage("GameStateControll", "Hold");

        SendMessage("RWGameOverModeUISetting");

        SendMessage("PlayerGravityScaleOff");
    }

    public void RetryCharacterPosition()
    {
        SendMessage("RWCharacterPositionInit");     //playercontroller로 이관
        SendMessage("PlayerGravityScaleOn");

        SendMessage("FlyingInitializeDelivery");
        SendMessage("FlyingTheWitchDelivery");
    }

    public void CurrentGameCoinCount(string nCoinCount)
    {
        currentCoinCount = currentCoinCount + Convert.ToInt32(nCoinCount);

        SendMessage("CounCounterRefreshDelivery", currentCoinCount);
    }

    public void CurrentGameCoininitialize()
    {
        currentCoinCount = 0;
        SendMessage("CounCounterRefreshDelivery", currentCoinCount);
    }

    public void CurrentGameCoinCountTotal()
    {
        SendMessage("CurrentGameCoinTotalDelivery", currentCoinCount);
        CoinTotalCalculate();
    }

    protected void CoinTotalCalculate()
    {
        int prevCoin = Convert.ToInt32(PlayerPrefs.GetString("TotalCoin"));
        int totalCoin = prevCoin + currentCoinCount;
        PlayerPrefs.SetString("TotalCoin", totalCoin.ToString());
    }

    public void BestGameBlockCountTotal(int nBlockCount)
    {
        print("current best count"+PlayerPrefs.GetString("BestCount"));
        if (PlayerPrefs.GetString("BestCount") == "")
            PlayerPrefs.SetString("BestCount", nBlockCount.ToString());

        int prevCount = Convert.ToInt32(PlayerPrefs.GetString("BestCount"));

        if (prevCount < nBlockCount)
        {
            //신기록 달성
            SendMessage("BestBlockCountTotalDelivery", nBlockCount);
            PlayerPrefs.SetString("BestCount", nBlockCount.ToString());
            SendMessage("NewRecordSuccess");
            SendMessage("PostScore", nBlockCount);
        }
        else
        {
            SendMessage("BestBlockCountTotalDelivery", prevCount);
        }
    }
}
