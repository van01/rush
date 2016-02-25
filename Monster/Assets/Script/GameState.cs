using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
    protected int hatchMonsterNumber;
    protected int nextEvolutionMonsterNumber;

    protected int currentMonsterNumber;
    protected int prevMonsterNumber;

    public bool isEvolutionActive = false;

    public enum State
    {
        Title,
        StandBy,
        Egg,
        EggEnd,
        Monster,
        RoomOut,
        MonsterEnd,
    }

    public State currentState;
    private State prevState;

    public void CheckGameState()
    {
        switch (currentState)
        {
            case State.Title:
                TitleAction();
                break;
            case State.StandBy:
                StandByAction();
                break;
            case State.Egg:
                EggAction();
                break;
            case State.EggEnd:
                EggEndAction();
                break;
            case State.Monster:
                MonsterAction();
                break;
            case State.RoomOut:
                RoomOutAction();
                break;
            case State.MonsterEnd:
                MonsterEndAction();
                break;
        }
    }


    void Start()
    {
        prevMonsterNumber = -1;
    }

    void TitleAction()
    {
        currentState = State.StandBy;
        CheckGameState();
        //임시로 StandBy로 변경되도록 고정
        SendMessage("HUDInitializeDelivery");

        prevState = State.Title;
    }

    void StandByAction()
    {
        //상단 패널 초기화 전달
        SendMessage("TopPanelInitilaizeDelivery");
        //하단 패널 초기화 전달
        SendMessage("BottomHomePanelInitializeDelivery");
        //퀘스트 몬스터 유무 off
        SendMessage("QuestMonsterOff");

        prevState = State.StandBy;
    }

    void EggAction()
    {
        SendMessage("BottomHomePanelInitializeDelivery");

        //hatchMonsterNumber = GetComponent<EggController>().currentEgg.GetComponent<EggAbility>().hatchMonsterNumber;
        currentMonsterNumber = GetComponent<EggController>().currentEgg.GetComponent<EggAbility>().hatchMonsterNumber;

        if (GetComponent<HUDController>().isSmallBottomPanel == false)
            SendMessage("BottomMenuDisable");

        prevState = State.Egg;
    }

    void EggEndAction()
    {
        SendMessage("EggEnd");
        SendMessage("WhitePanelEffectActiveOn");

        prevState = State.EggEnd;
        //해당 시점부타 current day 측정, 해당 수치는 playerPrefab에 추가
    }

    void MonsterAction()
    {
        if (prevState == State.EggEnd)
        {
            SendMessage("MonsterInitialize", currentMonsterNumber);
            prevMonsterNumber = currentMonsterNumber;
        }
            
        SendMessage("BottomHomePanelInitializeDelivery");

        if (GetComponent<HUDController>().isSmallBottomPanel == true)
            SendMessage("MenuPanelOnDeliver");  //임시
        SendMessage("BottomMenuAble");

        prevState = State.Monster;
    }

    void MonsterEndAction()
    {
        if (isEvolutionActive == true)
        {
            SendMessage("MonsterInitialize", nextEvolutionMonsterNumber);
            isEvolutionActive = false;
        }

        currentState = State.Monster;
        CheckGameState();

        prevState = State.MonsterEnd;
    }

    void RoomOutAction()
    {
        SendMessage("MonsterHidePosition");     //진짜 현재 몬스터 숨겨놓기

        prevState = State.RoomOut;
    }

    public void NextEvolutionMonsterNumberSetting(int nEvolutionMonsterNumber)
    {
        nextEvolutionMonsterNumber = nEvolutionMonsterNumber;
        //currentMonsterNumber = nEvolutionMonsterNumber;
    }

}
