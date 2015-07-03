using UnityEngine;
using System.Collections;

public class EnemyBattle : CharacterBattle{

    private GameObject target;
    private GameObject tmpGameController;
    private Vector3 HitTransform;
    private float HitTransformX;
    private float HitTransformY;

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

    public void BattleStop()
    {
        SendMessage("beginningJoinOn");
        SendMessage("CharacterStateControll", "Move");
        StopCoroutine("BattleWait");
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
            playerParams.curHP -= enemyParams.attack;


            HitTransformX = target.transform.position.x + ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
            HitTransformY = target.transform.position.y;
            HitTransform = new Vector3(HitTransformX, target.transform.position.y, target.transform.position.z);

            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            tmpGameController.SendMessage("PlayerHitDamage", enemyParams.attack);

            SendMessage("EnemyHitColorEffectActive");

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
