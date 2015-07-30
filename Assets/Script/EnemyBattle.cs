using UnityEngine;
using System.Collections;

public class EnemyBattle : CharacterBattle{

    private GameObject target;
    private GameObject tmpGameController;
    private Vector3 HitTransform;
    private float HitTransformX;
    private float HitTransformY;

    private int attackCount = 0;

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
        SendMessage("CharacterStateControll", "Move");
        StopCoroutine("BattleWait");
    }

    protected void CheckEnemyCurHP()
    {
        if (playerParams.curHP > 0)
        {
            target.SendMessage("HealthBarValueUpdate", (float)playerParams.curHP / (float)playerParams.maxHP);
        }
        else
        {
            TargetDead();
        }
    }

    public void BattleEnd()
    {
        print("Battle End");
    }

    protected void TargetDead()
    {
        target.SendMessage("HealthBarValueUpdate", 0f);
        target.SendMessage("CharacterStateControll", "Dead");
        //target.tag = "Untagged";
        target.SendMessage("CharacterDieEffect");
        SendMessage("SearchPlayer");

        SendMessage("CharacterStateControll", "Idle");
    }

    public void AttackSuccess()
    {
        if (attackProssible == true)
        {
            attackCount = 0;
            attackProssible = false;

            SendMessage("BattlingOff");
            StartCoroutine("BattleWait");

            playerParams.curHP -= enemyParams.attack;

            //타격 연출 적용
            SendMessage("EnemyHitEffectActive");

            //타격 위치 알아내기
            HitTransformX = target.transform.position.x + ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
            HitTransformY = target.transform.position.y;
            HitTransform = new Vector3(HitTransformX, target.transform.position.y, target.transform.position.z);

            //타격 위치 및 공격력 전송
            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            tmpGameController.SendMessage("PlayerHitDamage", enemyParams.attack);

            CheckEnemyCurHP();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.root.tag == "Player")
        {
            attackCount++;

            if (attackCount == 1)
            {
                attackProssible = true;
            }
        }
        
    }

    public void AttackEnd()
    {
        SendMessage("CharacterStateControll", "Battle");
    }

    private IEnumerator BattleWait()
    {
        float attackWaitTime = 0.8f;

        SendMessage("CharacterStateControll", "Battle");

        yield return new WaitForSeconds(attackWaitTime);
        SendMessage("BattlingOn");
    }
}
