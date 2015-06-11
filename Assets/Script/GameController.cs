using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject[] tmpPlayer;
	private bool characterEnterCheckTrueValue = false;

	private bool characterMovePredicate = false;
	private bool characterBattlePredicate = false;
	private bool characterGuardPredicate = false;
	private bool characterRunPredicate = false;

	void Start() {
		characterMovePredicate = true;
		//CharacterActionCheck();
		SendMessage("GameStateControll", "Playing"); //임시
	}
	
	// Update is called once per frame
	public void CharacterInialize(){
		tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
		
		for (int i = 0; i < tmpPlayer.Length; i++){
			//Debug.Log(tmpPlayer[i]);
		}
	}

	private void CharacterStateChange(string s){
		for (int i = 0; i < tmpPlayer.Length; i++){
			tmpPlayer[i].gameObject.SendMessage("CharacterStateControll", s);
		}
	}

	public void CharacterEnterCheck(){
		if(characterEnterCheckTrueValue == true){
			characterMovePredicate = false;
			characterBattlePredicate = true;
			CharacterActionCheck();
		}

	}

	public void CharacterEnterCheckTrue(){
		characterEnterCheckTrueValue = true;
	}

	public void CharacterActionCheck(){
		if (characterMovePredicate == false){
			if (characterBattlePredicate == true){
				if (characterGuardPredicate == true) CharacterStateChange("Guard");
				else CharacterStateChange("Battle");
			}
			else if (characterRunPredicate == true) CharacterStateChange("Run");
			else CharacterStateChange("Idle");
		}
		else if (characterMovePredicate == true){
			if (characterGuardPredicate == true){ CharacterStateChange("Guard"); CharacterBattleStop();}
			else if(characterBattlePredicate == true){
				if (characterGuardPredicate == true) CharacterStateChange("Guard");
				else CharacterStateChange("Battle");
			}
			else if (characterRunPredicate == true) CharacterStateChange("Run");
			else CharacterStateChange("Move");
		}
	}

	public void CharacterMovePredicateOn(){
		characterMovePredicate = true;
		CharacterActionCheck();
	}
	
	public void CharacterMovePredicateOff(){
		characterMovePredicate = false;
		CharacterActionCheck();
	}
	
	public void CharacterGuardPredicateOn(){
		characterGuardPredicate = true;
		SendMessage("GameStateControll", "Hold");
		CharacterActionCheck();
	}
	
	public void CharacterGuardPredicateOff(){
		characterGuardPredicate = false;

		if (characterBattlePredicate == true)
			SendMessage("GameStateControll", "Hold");
		else
			SendMessage("GameStateControll", "Playing");

		CharacterActionCheck();
	}
	
	public void CharacterBattlePredicateOn(){
		characterBattlePredicate = true;
		CharacterActionCheck();
	}
	
	public void CharacterBattlePredicateOff(){
		characterBattlePredicate = false;
		CharacterActionCheck();
	}

	public void CharacterRunPredicateOn(){
		characterRunPredicate = true;
		CharacterActionCheck();
	}

	public void CharacterRunPredicateOff(){
		characterRunPredicate = false;

		if(characterBattlePredicate == false){
			if (characterBattlePredicate == true)
				SendMessage("GameStateControll", "Hold");
			else
				SendMessage("GameStateControll", "Playing");
		}
	}

	private void CharacterBattleStop(){
		for (int i = 0; i < tmpPlayer.Length; i++){
			tmpPlayer[i].gameObject.SendMessage("BattleStop");
		}
	}

}
