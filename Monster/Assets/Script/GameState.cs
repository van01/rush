using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

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
        SendMessage("EggInitialize");
    }

    void EggAction()
    {
        SendMessage("EggInitialize");
    }

    void EggEndAction()
    {
        SendMessage("EggEnd");
        SendMessage("WhitePanelEffectActiveOn");
    }

    void MonsterAction()
    {
        SendMessage("MonsterInitialize");
    }

    void RoomOutAction()
    {

    }

    void MonsterEndAction()
    {

    }
}
