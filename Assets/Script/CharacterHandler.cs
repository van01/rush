using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

	private GameObject tmpGameController;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
	}

	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag == "Enemy"){
			tmpGameController.SendMessage("CharacterEnterCheckTrue");

			GameStateHoldOn();
		}
	}

	public void GameStateHoldOn(){
		tmpGameController.SendMessage("GameStateControll", "Hold");
	}

	public void CharacterStateBattleOn(){
		tmpGameController.SendMessage("CharacterBattlePredicateOn");
	}

	public void CharacterStateMoveOn(){
		tmpGameController.SendMessage("CharacterMovePredicateOn");
	}
}