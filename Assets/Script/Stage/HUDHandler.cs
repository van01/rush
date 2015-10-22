﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHandler : MonoBehaviour {

    public GameObject tmpGameController;

    public GameObject AlertPanel;

    public GameObject hitZone;
    public GameObject tmpPlayer;

    public GameObject HUDPlayingUI;
    public GameObject HUDBattleUI;
    public GameObject HUDRWLobbyUI;
    public GameObject HUDRWReadyUI;
    public GameObject HUDRWPlayingUI;
    public GameObject HUDRWPaueseUI;
    public GameObject HUDRWGameOverUI;
    public GameObject HUDRWExitPopup;

    public GameObject HUDRWCharacterUI;
    public GameObject HUDRWHelmetUI;
    public GameObject HUDRWRaffleUI;

    public GameObject blockCounter;
    public GameObject totalCoinUI;
    public GameObject HelmetRafflePaneltotalCoinUI;

    public GameObject currentCoinUI;

    public GameObject currentGameCoinUI;
    public GameObject currentGameBlockCounterUI;


    public void OnClickSkillButton(string activeSkillID)
    {
        tmpPlayer = GameObject.Find("Pawn");

        tmpPlayer.SendMessage("ActivePlayerSkillOn", activeSkillID);
        //print(activeSkillID);       //여기에서 어떤 녀석의 스킬인지 판단해 해당 녀석에게 쏨
    }

    //new input System 20150723

    void Left01ButtonDown()
    {
        tmpGameController.SendMessage("Left01Down");
    }

    void Left01ButtonUp()
    {
        tmpGameController.SendMessage("Lef01Up");
    }

    void Left02ButtonDown()
    {
        tmpGameController.SendMessage("Left02Down");
    }

    void Left02ButtonUp()
    {
        tmpGameController.SendMessage("Left02Up");
    }

    void Right01ButtonDown()
    {
        tmpGameController.SendMessage("Right01Down");
    }

    void Right01ButtonUp()
    {
        tmpGameController.SendMessage("Right01Up");
    }

    void Right02ButtonDown()
    {
        tmpGameController.SendMessage("Right02Down");
    }

    void Right02ButtonUp()
    {
        tmpGameController.SendMessage("Right02Up");
    }




    // 20150906 test목적으로 심음 추후 스테이지 진행 시 보스 클러어 후 자동 호출
    public void StageColorTest()
    {
        tmpGameController.SendMessage("StageColorActiveOn");
    }



    /// <summary>
    /// Lapick ~ Rushing to Witch ~
    /// </summary>
    void RWHitZoneInput()
    {
        tmpGameController.SendMessage("RWCharacterJumpAddforce");
    }

    public void HUDBattleUIOn()
    {
        HUDBattleUI.SetActive(true);
        HUDRWLobbyUI.SetActive(false);
    }

    public void HUDBattleUIOff()
    {
        HUDBattleUI.SetActive(false);
        HUDRWLobbyUI.SetActive(true);

        TotalCoinRefresh();
    }

    public void HUDRWLobbyUIOff()
    {
        HUDRWLobbyUI.SetActive(false);
    }

    public void HUDRWReadyUIOn()
    {
        HUDRWReadyUI.SetActive(true);
    }

    public void HUDRWReadyUIOff()
    {
        HUDRWReadyUI.SetActive(false);
    }

    public void HUDPlayingUIon()
    {
        HUDPlayingUI.SetActive(true);
    }

    public void HUDPlayingUIoff()
    {
        HUDPlayingUI.SetActive(false);
    }

    public void HUDRWPlayingUIon()
    {
        HUDRWPlayingUI.SetActive(true);
    }

    public void HUDRWPlayingUIoff()
    {
        HUDRWPlayingUI.SetActive(false);
    }

    public void HUDRWPaueseUIon()
    {
        HUDRWPaueseUI.SetActive(true);
    }

    public void HUDRWPaueseUIoff()
    {
        HUDRWPaueseUI.SetActive(false);
    }

    public void HUDRWGameOverUIon()
    {
        int i = 1;
        HUDRWGameOverUI.SetActive(true);

        tmpGameController.SendMessage("CurrentGameCoinCountTotal");
        tmpGameController.SendMessage("CurrentGameBlockCountTotal");
    }

    public void HUDRWGameOverUIoff()
    {
        HUDRWGameOverUI.SetActive(false);
    }

    public void HUDRWCharacterUIon()
    {
        HUDRWCharacterUI.SetActive(true);
    }

    public void HUDRWCharacterUIoff()
    {
        HUDRWCharacterUI.SetActive(false);
    }

    public void HUDRWHelmetUIon()
    {
        HUDRWHelmetUI.SetActive(true);
        HUDRWHelmetUI.SendMessage("ChangeCharacterCheck");

        HUDRWHelmetUI.SendMessage("PossessHelmetRefresh");
    }

    public void HUDRWHelmetUIoff()
    {
        HUDRWHelmetUI.SetActive(false);
    }

    public void HUDRWHelmetRaffleUIon()
    {
        HUDRWRaffleUI.SetActive(true);
        TotalCoinRefresh();
    }

    public void HUDRWHelmetRaffleUIoff()
    {
        HUDRWRaffleUI.SetActive(false);
    }

    public void HUDHUDRWExitPopupon()
    {
        HUDRWExitPopup.SetActive(true);
    }

    public void HUDHUDRWExitPopupoff()
    {
        HUDRWExitPopup.SetActive(false);
    }

    public void AlertPanelon()
    {
        AlertPanel.SetActive(true);
    }

    public void AlertPaneloff()
    {
        AlertPanel.SetActive(false);
    }

    public void AlertPanelTextSetting(string nAlertMessage)
    {
        AlertPanel.SendMessage("AlertMessageSetting", nAlertMessage);
    }

    public void StartButtonActive()
    {
        tmpGameController.SendMessage("GameStateControll", "Ready");
        tmpGameController.SendMessage("CurrentGameCoininitialize");
    }

    public void ReadyPanelActive()
    {
        tmpGameController.SendMessage("GameStateControll", "Playing");
    }

    public void PauseButtonActive()
    {
        //Pause On

        tmpGameController.SendMessage("RWGamePauseOnUISetting");
    }

    public void ReStartButtonActive()
    {
        //Pause Off

        tmpGameController.SendMessage("RWGamePauseOffUISetting");
    }

    public void GiveUpButtonActive()
    {
        tmpGameController.SendMessage("RWGameGiveUpUISetting");

        tmpGameController.SendMessage("BlockInitDelivery");
        tmpGameController.SendMessage("RetryCharacterPosition");
        tmpGameController.SendMessage("GameStateControll", "Lobby");

        tmpGameController.SendMessage("StageLevelInitialize");

    }

    public void RetryActive()
    {
        tmpGameController.SendMessage("StageLevelInitialize");

        tmpGameController.SendMessage("BlockInitDelivery");
        tmpGameController.SendMessage("GameStateControll", "Playing");
        tmpGameController.SendMessage("RetryCharacterPosition");

        tmpGameController.SendMessage("CurrentGameCoininitialize");

        HUDRWGameOverUIoff();
    }

    public void HomeActive()
    {
        tmpGameController.SendMessage("BlockInitDelivery");
        tmpGameController.SendMessage("RetryCharacterPosition");
        tmpGameController.SendMessage("GameStateControll", "Lobby");

        tmpGameController.SendMessage("StageLevelInitialize");
    }

    public void CharacterButtonActive()
    {
        HUDRWCharacterUIon();
    }

    public void CharacterCloseButtonActive()
    {
        HUDRWCharacterUIoff();
    }

    public void HelmetButtonActive()
    {
        tmpGameController.SendMessage("RWHelmetUISetting");
    }

    public void HelmetCloseButtonActive()
    {
        tmpGameController.SendMessage("RWHelmetUICancel");
    }

    public void HelmetRaffleButtonActive()    //HUDRWRaffleUIon
    {
        tmpGameController.SendMessage("RWRaffleUISetting");
    }

    public void HelmetRaffleCloseButtonActive()
    {
        tmpGameController.SendMessage("RWRaffleUICancel");
    }

    public void BlockCounterRefresh(string nCount)
    {
        blockCounter.GetComponent<Text>().text = nCount;
    }

    public void CancelButtonActive()
    {
        tmpGameController.SendMessage("RWGameExitUICancel");
    }

    public void ExitButtonActive()
    {
        Application.Quit();
    }

    public void CoinCounterRefresh(int nCurrentCoin)
    {
        currentCoinUI.GetComponent<Text>().text = nCurrentCoin.ToString();      //playing
    }

    public void CurrentGameCoinTotalViewer(int nCurrentCoin)
    {
        currentGameCoinUI.GetComponent<Text>().text = nCurrentCoin.ToString();  //gameOver
    }
    public void CurrentGameBlockCountTotalViewer(int nCurrentBlockCount)
    {
        currentGameBlockCounterUI.GetComponent<Text>().text = nCurrentBlockCount.ToString();  //gameOver
    }

    public void TotalCoinRefresh()
    {
        totalCoinUI.GetComponent<Text>().text = PlayerPrefs.GetString("TotalCoin");
        HelmetRafflePaneltotalCoinUI.GetComponent<Text>().text = PlayerPrefs.GetString("TotalCoin");
    }

    public void AlertPanelActive(int nAlertType)
    {
        tmpGameController.SendMessage("AlertPanelSetting", nAlertType);
    }

    public void AlertPanelCloseActive()
    {
        AlertPaneloff();
    }
    //HUDcontroller와 HUDHandler 기능 정리 필요
}
