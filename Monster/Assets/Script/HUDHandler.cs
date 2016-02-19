using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

    public GameObject tmpGameController;
    public GameObject whitePanel;

    public GameObject eggBuyButton;
    public GameObject ScoutButton;

    public GameObject bottomPanel;
    public GameObject bigBottomPanel;
    public GameObject smallBottomPanel;

    public GameObject eggBuyPanel;
    public GameObject scoutPanel;

    public GameObject trainingPanel;
    public GameObject dishPanel;

    public GameObject menu;

    public bool isCurrentBottomPanel;

    void Start()
    {
        isCurrentBottomPanel = tmpGameController.GetComponent<HUDController>().isSmallBottomPanel;

        if (isCurrentBottomPanel == true)
        {
            bigBottomPanel.SetActive(false);
            smallBottomPanel.SetActive(true);
            bottomPanel = smallBottomPanel;

            MenuPanelOff();
        }
        else
        {
            bigBottomPanel.SetActive(true);
            smallBottomPanel.SetActive(false);
            bottomPanel = bigBottomPanel;
        }
    }

    public void WhitePanelEffectActiveDelivery(Transform nTransform)
    {
        whitePanel.SetActive(true);

        whitePanel.SendMessage("WhitePanelEffectActive", nTransform);
    }

    public void WhitePanelOff()
    {
        whitePanel.SetActive(false);
    }

    public void CurrentEggDestroyDelivery()
    {
        tmpGameController.SendMessage("CurrentEggDestroy");     //이 부분이 hudHandler에 있는게 이상함
    }

    public void BottomHomePanelInitialize()
    {
        bottomPanel.GetComponent<HUDBottomHandler>().SendMessage("MonsterInfoInitialIzeRefresh");
    }

    public void EggBuyPanelOn()
    {
        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.StandBy)
        {
            eggBuyPanel.SetActive(true);
        }
        else
        {
            print("오류"); //몬스터, 알 존재 시 오류 메시지 출력
        }
        
    }

    public void EggBuyPanelOff()
    {
        eggBuyPanel.SetActive(false);
    }

    public void EggBuySuccessDelivery(int nEggNumber)
    {
        tmpGameController.SendMessage("EggInitialize", nEggNumber); //가격 관련 체크 내용 추가 필요
    }


    public void ScoutPanelOn()
    {
        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.Monster)
        {
            scoutPanel.SetActive(true);
            scoutPanel.SendMessage("TextBoxStringSetting", "text string");
            scoutPanel.SendMessage("ConfirmPopupOn");   //테스트
        }
        else
        {
            print("오류"); //몬스터, 알 존재 시 오류 메시지 출력
        }
    }

    public void ScoutPanelOff()
    {
        scoutPanel.SetActive(false);
    }

    public void MonsterScoutSuccessDelivery()
    {
        tmpGameController.SendMessage("MonsterScoutSuccess");

        scoutPanel.SendMessage("ConfirmPopupOff");
        ScoutPanelOff();
        MenuPanelOff();
    }

    public void TrainingPanelOff()
    {
        trainingPanel.SetActive(false);
    }

    public void DishPanelOff()
    {
        dishPanel.SetActive(false);
    }

    public void MenuPanelOn()
    {
        menu.SetActive(true);
    }

    public void MenuPanelOff()
    {
        menu.SetActive(false);
    }

    public void HUDInitialize()
    {
        eggBuyButton.SetActive(true);
        ScoutButton.SetActive(true);

        eggBuyPanel.SetActive(false);
        scoutPanel.SetActive(false);

        trainingPanel.SetActive(false);
        dishPanel.SetActive(false);

        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.Monster)
            menu.SetActive(true);  //해당 부분은 메뉴 제공 방식에 따라 수정 필요
    }

    public void HUDHide()
    {
        eggBuyButton.SetActive(false);
        ScoutButton.SetActive(false);

        eggBuyPanel.SetActive(false);
        scoutPanel.SetActive(false);

        trainingPanel.SetActive(false);
        dishPanel.SetActive(false);

        menu.SetActive(false);
    }
}
