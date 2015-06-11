using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle {

	private GameObject target;
	private GameObject testGameController;

	void Start(){
		testGameController = GameObject.Find ("GameController");
	}

	public override void StartBattle(){
		myState = GetComponent<PlayerState>();
		target = GetComponent<PlayerAI>().GetCurrentTarget();

		myParams = GetComponent<PlayerAbility>().GetParams();
		enemyParams = target.GetComponent<EnemyAbility>().GetParams();

		DoBattle();
	}

	public override void DoBattle(){
		SendMessage("CharacterStateControll", "Attack");

		StartCoroutine("SuccessRoll");
	}

	protected IEnumerator SuccessRoll(){
		yield return new WaitForSeconds(0.3f);

		enemyParams.curHP -= myParams.attack;
		print (enemyParams.curHP + " / " + enemyParams.maxHP);

		CheckEnemyCurHP();

		yield return new WaitForSeconds(0.7f);
		//SendMessage("CheckDistanceFromTarget");
		SendMessage("CharacterStateControll", "Battle");


	}

	public void BattleStop(){
		StopCoroutine("SuccessRoll");
	}

	protected void CheckEnemyCurHP(){
		if(enemyParams.curHP > 0)
			return;
		else{
			BattleEnd();
		}
	}

	public void BattleEnd(){
		target.SetActive(false);
		testGameController.SendMessage("PlayingAction");
		StopCoroutine("SuccessRoll");
		SendMessage("CharacterStateControll", "Move");
		SendMessage("SearchEnemy");
	}
}
