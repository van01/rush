using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState {

	void Start(){
		CharacterStateControll("Spawn");
	}

	public override void SpawnAction(){
		base.SpawnAction();
	}

	public override void MoveAction(){
		base.MoveAction();
	}

	public override void RunAction(){
		base.RunAction();
	}

	public override void CharacterStateControll(string s){
		base.CharacterStateControll(s);
	}
}
