using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

    public GameObject tmpGameController;
    public GameObject whitePanel;

    public GameObject questButton;
    public GameObject eggBuyButton;
    public GameObject ScoutButton;

    public GameObject topPanel;
    public GameObject bottomPanel;
    public GameObject bigBottomPanel;
    public GameObject smallBottomPanel;
   
    public GameObject questPanel;
    public GameObject eggBuyPanel;

    public GameObject questDramaticPanel;
    public GameObject scoutPanel;

    public GameObject trainingPanel;
    public GameObject dishPanel;
    public GameObject breakPanel;

    public GameObject menu;

    public bool isCurrentBottomPanel;

    private int currentQuestNumber;

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

    public void TopPanelInitilaize()
    {
        //상단 패널 초기화
        topPanel.SendMessage("TopPanelInfoInitilize");
    }

    public void BottomHomePanelInitialize()
    {
        //하단 패널 초기화
        bottomPanel.GetComponent<HUDBottomHandler>().SendMessage("MonsterInfoInitialIzeRefresh");
    }

    public void QuestPanelOn()
    {
        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.StandBy)
        {
            questPanel.SetActive(true);
        }
        else
        {
            print("오류"); //몬스터, 알 존재 시 오류 메시지 출력
        }
    }

    public void QuestPanelOff()
    {
        questPanel.SetActive(false);
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

    public void QuestDramaticPanelOn(int nCurrentQuestNumber)
    {
        //퀘스트 자동지급도 해당 함수 이용해 기능 구현
        //questPanel off
        QuestPanelOff();

        //nCurrentQuestNumber에 따라 해당 퀘스트의 스트링 및 캐릭터 이미지 세팅
        questDramaticPanel.SetActive(true);
        questDramaticPanel.SendMessage("TextBoxStringSetting", "text string");

        currentQuestNumber = nCurrentQuestNumber;
    }

    public void QuestDramaticPanelOff()
    {
        questDramaticPanel.SetActive(false);
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

    public void QuestAcceptDelivery()
    {
        //퀘스트 수락
        //tmpGameController.SendMessage("MonsterScoutSuccess");

        //currentQuestNumber에서 해당 퀘스트에 사용될 egg Number 추출 후 적용
        tmpGameController.SendMessage("EggInitialize", currentQuestNumber);

        questDramaticPanel.SendMessage("ConfirmPopupOff");
        QuestDramaticPanelOff();
    }

    public void MonsterScoutSuccessDelivery()
    {
        //스카우트 성공
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

    public void BreakPanelOff()
    {
        breakPanel.SetActive(false);
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
