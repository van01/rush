using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
    protected int hatchMonsterNumber;
    protected int nextEvolutionMonsterNumber;

    protected int currentMonsterNumber;
    protected int prevMonsterNumber;

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
    }

    void StandByAction()
    {
        SendMessage("BottomHomePanelInitializeDelivery");
    }

    void EggAction()
    {
        SendMessage("BottomHomePanelInitializeDelivery");

        //hatchMonsterNumber = GetComponent<EggController>().currentEgg.GetComponent<EggAbility>().hatchMonsterNumber;
        currentMonsterNumber = GetComponent<EggController>().currentEgg.GetComponent<EggAbility>().hatchMonsterNumber;

        if (GetComponent<HUDController>().isSmallBottomPanel == false)
            SendMessage("BottomMenuDisable");
        
    }

    void EggEndAction()
    {
        SendMessage("EggEnd");
        SendMessage("WhitePanelEffectActiveOn");
    }

    void MonsterAction()
    {
        if (prevMonsterNumber != currentMonsterNumber)
        {
            SendMessage("MonsterInitialize", currentMonsterNumber);
            prevMonsterNumber = currentMonsterNumber;
        }
            
        SendMessage("BottomHomePanelInitializeDelivery");

        if (GetComponent<HUDController>().isSmallBottomPanel == true)
            SendMessage("MenuPanelOnDeliver");  //임시
        SendMessage("BottomMenuAble");
    }

    void MonsterEndAction()
    {
        //SendMessage("MonsterInitialize", nextEvolutionMonsterNumber);
        currentState = State.Monster;
        CheckGameState();
    }

    void RoomOutAction()
    {
        SendMessage("MonsterHidePosition");     //진짜 현재 몬스터 숨겨놓기
    }

    public void NextEvolutionMonsterNumberSetting(int nEvolutionMonsterNumber)
    {
        //nextEvolutionMonsterNumber = nEvolutionMonsterNumber;
        currentMonsterNumber = nEvolutionMonsterNumber;
    }

    public void RoomOutEnd()
    {
        //해당 부분 연출 완료 시점에서 이관 필요

        SendMessage("HUDInitializeDelivery"); //UI 복원
        GetComponent<MonsterController>().currentMonster.GetComponent<MonsterAbility>().TrainingComplete();

        currentState = State.MonsterEnd;
        CheckGameState();

        GetComponent<TrainingController>().trainingDramaticHandler.GetComponent<TrainingDramaticHandler>().SendMessage("PowDirectionDestroy");
        //연출 종료, 현재는 pow 구현중이라 pow에게 직접 쏨, 추후 처리 필요
        SendMessage("MonsterRestorePosition");     //진짜 현재 몬스터 복구
    }
}
