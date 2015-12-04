using UnityEngine;
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

    public GameObject bestBlockCounterUI;

    public GameObject openingSkipPanel;

    public GameObject HUDRWAdsPopup;

    void Awake()
    {
        //HUDRWAdsPopup.SetActive(true);
    }

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

        //HUDRWAdsPopup.SetActive(false); //adspopup init 후 비활성화

        TotalCoinRefresh();
    }

    public void HUDRWLobbyUIOff()
    {
        HUDRWLobbyUI.SetActive(false);
    }

    public void HUDRWReadyUIOn()
    {
        HUDRWReadyUI.SetActive(true);
        HUDRWReadyUI.SendMessage("ReadyPanelInitailize");
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

        HUDRWGameOverUI.SendMessage("CurrentCharacterInitialize");
    }

    public void HUDRWGameOverUIoff()
    {
        if (HUDRWGameOverUI.active == true)
        {
            HUDRWGameOverUI.SendMessage("CurrentCharacterDestroy");     //게임오버 창 캐릭터 삭제
            HUDRWGameOverUI.SendMessage("GameOverUIInitialize");       //신기록 연출, x2 아이콘 숨기기
        }
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
        HUDRWRaffleUI.SendMessage("RaffleCharacterDraw");
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

    public void AdsPopupOn()
    {
        HUDRWAdsPopup.SetActive(true);
        HUDRWAdsPopup.SendMessage("AdsOn");

    }

    public void AdsPopupOff()
    {
        HUDRWAdsPopup.SendMessage("AdsOff");
        HUDRWAdsPopup.SetActive(false);
        HUDRWGameOverUI.SendMessage("CurrentCharacterInitialize");
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


        tmpGameController.SendMessage("StageScrollInialize");
        tmpGameController.SendMessage("BaseBlockScrollOnDelivery");
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

        tmpGameController.SendMessage("StageScrollInialize");
        tmpGameController.SendMessage("BaseBlockScrollOnDelivery");
    }

    public void DoubleActive()
    {
        AdsPopupOn();
        HUDRWGameOverUI.SendMessage("CurrentCharacterDestroy");
        //광고 호출 팝업 call
        //HUDRWGameOverUI에게 캐릭터 끄기 보내기
    }

    public void CharacterButtonActive()
    {
        HUDRWCharacterUIon();

        tmpGameController.SendMessage("OpeningTake4Acting");
    }

    public void CharacterCloseButtonActive()
    {
        HUDRWCharacterUIoff();
    }

    public void HelmetButtonActive()
    {
        tmpGameController.SendMessage("RWHelmetUISetting");

        tmpGameController.SendMessage("OpeningTake4Acting");
    }

    public void HelmetCloseButtonActive()
    {
        tmpGameController.SendMessage("RWHelmetUICancel");
    }

    public void HelmetRaffleButtonActive()    //HUDRWRaffleUIon
    {
        tmpGameController.SendMessage("RWRaffleUISetting");

        tmpGameController.SendMessage("OpeningTake4Acting");
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

    public void BestBlockCountTotalViewer(int nBestBlockCount)
    {
        bestBlockCounterUI.GetComponent<Text>().text = nBestBlockCount.ToString();  //gameOver
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

    public void ShareImageButtonActive()
    {
        tmpGameController.SendMessage("NativeShareWithImage");
    }

    public void OpeningSkipPanelActive()
    {
        tmpGameController.SendMessage("OpeningTake4Acting");
        OpeningSkipPanelOff();
    }

    public void OpeningSkipPanelOff()
    {
        openingSkipPanel.SetActive(false);
    }

    public void OpeningSkipInitialize()
    {
        openingSkipPanel.SetActive(true);
        HUDRWAdsPopup.SetActive(false);
        //최초 실행 시 ui 숨기기
    }

    public void NewRecordTitleOnDelivery()
    {
        HUDRWGameOverUI.SendMessage("NewRecordTitleOn");
    }
    //HUDcontroller와 HUDHandler 기능 정리 필요
}
