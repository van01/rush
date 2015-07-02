using UnityEngine;
using System.Collections;

public class EnemyBattle : CharacterBattle{

    private GameObject target;
    private GameObject tmpGameController;
    private Vector3 HitTransform;

    protected bool attackProssible = false;

	void Start () {
        tmpGameController = GameObject.Find("GameController");    
	}

    public override void StartBattle()
    {
        myState = GetComponent<EnemyState>();
        target = GetComponent<EnemyAI>().GetCurrentTarget();

        enemyParams = GetComponent<EnemyAbility>().GetParams();
        playerParams = target.GetComponent<PlayerAbility>().GetParams();

        DoBattle();
    }

    public override void DoBattle()
    {
        SendMessage("CharacterStateControll", "Attack");
    }

    protected void CheckEnemyCurHP()
    {
        if (playerParams.curHP > 0)
            return;
        else
        {
            BattleEnd();
        }
    }

    public void BattleEnd()
    {
        Destroy(target);
    }

    public void AttackSuccess()
    {
        if (attackProssible == true)
        {
            print("Enemy ::::: Attack Success :: attackProssible True");

            playerParams.curHP -= enemyParams.attack;

            //HitTransform = target.transform;
            HitTransform = new Vector3(target.transform.position.x - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2) + 0.2f, target.transform.position.y, target.transform.position.z);


            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            tmpGameController.SendMessage("PlayerHitDamage", enemyParams.attack);
             

            print("Attack Success!!!!!!!!!!! ::: " + playerParams.curHP + " / " + playerParams.maxHP);

            attackProssible = false;

            CheckEnemyCurHP();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.root.tag == "Player")
        {
            attackProssible = true;
        }
    }

    public void AttackEnd()
    {
        SendMessage("CharacterStateControll", "Battle");
    }
}
