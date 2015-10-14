using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    private GameObject[] tmpPlayer;
	public enum State{
        Lobby,      //RW menu Mode
		Ready,		//게임 준비
		Playing,	//게임 진행
        Hold,		//전투
		Battle,		//전투
		Success,	//클리어
		Fail,		//실패
	}

	public State currentState;

	public virtual void GameStateControll(string s){
        if (s == "Lobby")
            currentState = State.Lobby;
        if (s == "Ready")
			currentState = State.Ready;
		if(s == "Playing")
			currentState = State.Playing;
        if (s == "Hold")
            currentState = State.Hold;
        if (s == "Battle")
            currentState = State.Battle;
		if(s == "Success")
			currentState = State.Success;
		if(s == "Fail")
			currentState = State.Fail;

		CheckGameState();
		}

	public void CheckGameState(){
		switch(currentState){
        case State.Lobby:
            LobbyAction();
            break;
        case State.Ready:
			ReadyAction();
			break;
		case State.Playing:
			PlayingAction();
			break;
        case State.Hold:
            HoldAction();
            break;
        case State.Battle:
            BattleAction();
			break;
		case State.Success:
			SuccessAction();
			break;
		case State.Fail:
			FailAction();
			break;
		}
	}

    public virtual void LobbyAction()
    {
        if (GetComponent<StageController>().isRWStage == true)
        {
            SendMessage("RWModeUISetting");

            SendMessage("CharacterInialize");
            SendMessage("StageInialize");
        }
    }

    public virtual void ReadyAction(){
        if (GetComponent<StageController>().isRWStage == true)
        {
            SendMessage("RWReadyModeUISetting");
        }
        else
        {
            SendMessage("CharacterInialize");
            SendMessage("StageInialize");

            SendMessage("BattleModeUISetting");
        }

        //Debug.Log("■■Game State■■ReadyAction");
    }
		
	public virtual void PlayingAction(){
        if (GetComponent<StageController>().isRWStage == true)
        {
            SendMessage("RWPlayingModeUISetting");
            SendMessage("RWBlockScrollon");
            SendMessage("StageScrollInialize");
        }
        
        SendMessage("CharacterActionCheck");
        //Debug.Log("■■Game State■■PlayingAction");
	}

    public virtual void HoldAction()
    {
        SendMessage("DeliveryScrollOnFalse");
    }

    public virtual void BattleAction()
    {
		SendMessage("DeliveryScrollOnFalse");
	}


	public virtual void SuccessAction(){
		//Debug.Log("■■Game State■■SuccessAction");
	}
	
	
	
	public virtual void FailAction(){
		//Debug.Log("■■Game State■■FailAction");
	}

    void Start()
    {
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
    }
}
