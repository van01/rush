using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle {

	private GameObject target;
	private GameObject tmpGameController;
    private Vector3 HitTransform;

    protected bool attackProssible = false;

	void Start(){
		tmpGameController = GameObject.Find ("GameController");      
	}

	public override void StartBattle(){
		myState = GetComponent<PlayerState>();
		target = GetComponent<PlayerAI>().GetCurrentTarget();

        playerParams = GetComponent<PlayerAbility>().GetParams();
		enemyParams = target.GetComponent<EnemyAbility>().GetParams();

		DoBattle();
	}

	public override void DoBattle(){
        SendMessage("CharacterStateControll", "Attack");
	}

	public void BattleStop(){
		StopCoroutine("SuccessRoll");
        SendMessage("beginningJoinOn");
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
		//SendMessage("SearchEnemy");
        //SendMessage("AttDistanceOn");
        SendMessage("BattlingOn");
        SendMessage("PositionDistanceReset");
	}

    public void AttackSuccess()
    {
        if (attackProssible == true)
        {
            enemyParams.curHP -= playerParams.attack;

            //HitTransform = target.transform;
            HitTransform = new Vector3(target.transform.position.x - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2) + 0.2f, target.transform.position.y, target.transform.position.z);

            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            tmpGameController.SendMessage("MonsterHitDamage", playerParams.attack);
            

            //print("Player Attack Success ::::: " + enemyParams.curHP + " / " + enemyParams.maxHP);

            attackProssible = false;

            CheckEnemyCurHP();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Enemy"))
        {
            attackProssible = true;
        }
    }

    public void AttackEnd()
    {
        SendMessage("CharacterStateControll", "Battle");
    }
}
