using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    private GameObject[] tmpPlayer;
	public enum State{
		Ready,		//게임 준비
		Playing,	//게임 진행
		Hold,		//스크롤 멈춤
		Success,	//클리어
		Fail,		//실패
	}

	public State currentState;

	public virtual void GameStateControll(string s){
		if(s == "Ready")
			currentState = State.Ready;
		if(s == "Playing")
			currentState = State.Playing;
		if(s == "Hold")
			currentState = State.Hold;
		if(s == "Success")
			currentState = State.Success;
		if(s == "Fail")
			currentState = State.Fail;

		CheckGameState();
		}

	public void CheckGameState(){
		switch(currentState){
		case State.Ready:
			ReadyAction();
			break;
		case State.Playing:
			PlayingAction();
			break;
		case State.Hold:
			HoldAction();
			break;
		case State.Success:
			SuccessAction();
			break;
		case State.Fail:
			FailAction();
			break;
		}
	}

	public virtual void ReadyAction(){
        SendMessage("CharacterInialize");
        SendMessage("StageInialize");
		//Debug.Log("■■Game State■■ReadyAction");
	}
		
	public virtual void PlayingAction(){
		SendMessage("StageScrollInialize");
		SendMessage("CharacterActionCheck");
		//Debug.Log("■■Game State■■PlayingAction");
	}
	
	public virtual void HoldAction(){
		SendMessage("DeliveryScrollOnFalse");
		SendMessage("CharacterEnterCheck");

		//SendMessage("HitZoneOff");
		//Debug.Log("■■Game State■■ HoldAction");
	}

    public virtual void BattleAction()
    {
        //Debug.Log("■■Game State■■Character Attack");
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

    void Update()
    {/*
        if (currentState == State.Hold)
        {
            for (int i = 0; i < tmpPlayer.Length; i++)
            {
                if (tmpPlayer[i].GetComponent<PlayerState>().currentState == CharacterState.State.Move)
                {
                    GameStateControll("Playing");
                }
            }
        }*/
    }
}
