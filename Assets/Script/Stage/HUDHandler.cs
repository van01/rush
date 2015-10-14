using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

	public GameObject tmpGameController;

	public GameObject hitZone;
    public GameObject tmpPlayer;

    public GameObject HUDPlayingUI;
    public GameObject HUDBattleUI;
    public GameObject HUDRWLobbyUI;
    public GameObject HUDRWReadyUI;
    public GameObject HUDRWPlayingUI;
    public GameObject HUDRWGameOverUI;

    public GameObject HUDRWCharacterUI;
    public GameObject HUDRWHelmetUI;

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

    public void HUDRWGameOverUIon()
    {
        HUDRWGameOverUI.SetActive(true);
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
    }

    public void HUDRWHelmetUIoff()
    {
        HUDRWHelmetUI.SetActive(false);
    }
    
    public void StartButtonActive()
    {
        tmpGameController.SendMessage("GameStateControll", "Ready");
    }

    public void ReadyPanelActive()
    {
        tmpGameController.SendMessage("GameStateControll", "Playing");
    }

    public void RetryActive()
    {
        tmpGameController.SendMessage("BlockInitDelivery");
        tmpGameController.SendMessage("GameStateControll", "Playing");
        tmpGameController.SendMessage("RetryCharacterPosition");

        HUDRWGameOverUIoff();
    }

    public void HomeActive()
    {
        tmpGameController.SendMessage("BlockInitDelivery");
        tmpGameController.SendMessage("RetryCharacterPosition");
        tmpGameController.SendMessage("GameStateControll", "Lobby");
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
        HUDRWHelmetUIon();
    }

    public void HelmetCloseButtonActive()
    {
        HUDRWHelmetUIoff();
    }

    //HUDcontroller와 HUDHandler 기능 정리 필요
}
