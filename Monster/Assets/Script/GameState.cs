using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
    protected int hatchMonsterNumber;
    protected int nextEvolutionMonsterNumber;

    protected int currentMonsterNumber;

    public enum State
    {
        Title,
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

    void TitleAction()
    {
        SendMessage("EggInitialize");   //eggPanel 완성 시 선택한 egg 생성되도록 수정
    }

    void EggAction()
    {
        SendMessage("EggInitialize");
        SendMessage("BottomHomePanelInitializeDelivery");

        SendMessage("BottomMenuDisable");

        //hatchMonsterNumber = GetComponent<EggController>().currentEgg.GetComponent<EggAbility>().hatchMonsterNumber;
        currentMonsterNumber = GetComponent<EggController>().currentEgg.GetComponent<EggAbility>().hatchMonsterNumber;
    }

    void EggEndAction()
    {
        SendMessage("EggEnd");
        SendMessage("WhitePanelEffectActiveOn");
    }

    void MonsterAction()
    {
        SendMessage("BottomMenuAble");

        //SendMessage("MonsterInitialize", hatchMonsterNumber);
        SendMessage("MonsterInitialize", currentMonsterNumber);
        SendMessage("BottomHomePanelInitializeDelivery");
    }

    void MonsterEndAction()
    {
        //SendMessage("MonsterInitialize", nextEvolutionMonsterNumber);
        currentState = State.Monster;
        CheckGameState();
    }

    void RoomOutAction()
    {

    }

    public void NextEvolutionMonsterNumberSetting(int nEvolutionMonsterNumber)
    {
        //nextEvolutionMonsterNumber = nEvolutionMonsterNumber;
        currentMonsterNumber = nEvolutionMonsterNumber;
        print(nEvolutionMonsterNumber);
    }
}
