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
        print("Do Battle");
		SendMessage("CharacterStateControll", "Attack");

		StartCoroutine("SuccessRoll");
	}

	protected IEnumerator SuccessRoll(){
		yield return new WaitForSeconds(0.3f);

		enemyParams.curHP -= myParams.attack;
		print (enemyParams.curHP + " / " + enemyParams.maxHP);

		CheckEnemyCurHP();

		yield return new WaitForSeconds(0.7f);
		
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
        Destroy(target);
        BattleStop();
		SendMessage("CharacterStateControll", "Move");
		SendMessage("SearchEnemy");
        SendMessage("BattlingOff");
        SendMessage("PositionDistanceReset");
	}
}
