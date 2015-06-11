using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState {

	void Start(){
		CharacterStateControll("Spawn");
	}

	public override void SpawnAction(){
		base.SpawnAction();

		SendMessage("ChangeAni", CharacterAni.MOVE);
	}

	public override void IdleAction(){
		base.IdleAction();

		SendMessage("ChangeAni", CharacterAni.IDLE);
	}

	public override void MoveAction(){
		base.MoveAction();

		SendMessage("ChangeAni", CharacterAni.MOVE);
		SendMessage("SearchEnemy");
	}

	public override void RunAction(){
		base.RunAction();

		SendMessage("ChangeAni", CharacterAni.RUN);
	}

	public override void BattleAction(){
		base.BattleAction();
		SendMessage("ChangeAni", CharacterAni.BATTLE);

		SendMessage("StartBattle");
	}

	public override void AttackAction(){
		base.AttackAction();

		SendMessage("ChangeAni", CharacterAni.ATTACK);

		StartCoroutine("BattleWait");

	}

	public override void GuardAction(){
		base.GuardAction();

		SendMessage("ChangeAni", CharacterAni.GUARD);
	}

	public override void CharacterStateControll(string s){
		base.CharacterStateControll(s);
	}

	private IEnumerator BattleWait(){
		float attackWaitTime = 0.2f;

		yield return new WaitForSeconds (attackWaitTime);
		SendMessage("ChangeAni", CharacterAni.BATTLE);
	}
}
