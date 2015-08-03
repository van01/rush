using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle {

	private GameObject target;
	private GameObject tmpGameController;
    private Vector3 HitTransform;
    private float HitTransformX;
    private float HitTransformY;

    private int attackCount = 0;

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
        StopCoroutine("BattleWait");
	}

	protected void CheckEnemyCurHP(){
        if (enemyParams.curHP > 0)
        {
            target.SendMessage("HealthBarValueUpdate", (float)enemyParams.curHP / (float)enemyParams.maxHP);    //!!
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

        SendMessage("CharacterStateControll", "Move");
        SendMessage("BattlingOn");
        SendMessage("PositionDistanceReset");

        //SendMessage("SearchEnemy");
        BattleStop();
    }

    public void AttackSuccess()
    {
        //if (attackProssible == true)
        //{
        //attackCount = 0;
        //attackProssible = false;

        //SendMessage("BattlingOff");
        //StartCoroutine("BattleWait");

        //enemyParams.curHP -= playerParams.attack;

        ////타격 연출 적용
        //SendMessage("PlayerHitEffectActive");

        ////타격 위치 알아내기
        //HitTransformX = target.transform.position.x - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
        //HitTransformY = target.transform.position.y;
        //HitTransform = new Vector3(HitTransformX, target.transform.position.y, target.transform.position.z);

        ////타격 위치 및 공격력 전송
        //tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
        //tmpGameController.SendMessage("MonsterHitDamage", playerParams.attack);

        //CheckEnemyCurHP();
        //}
        attackProssible = true;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        
        //if (c.tag == "Enemy")
        //{
        //    print(c.name + " " + Time.time);
        //    attackCount++;

        //    if (attackCount == 1)
        //    {
        //        attackProssible = true;
        //    }
        //}
        if (attackProssible == true)
        {
            if (c.tag == "Enemy")
            {
                print(c.name + "  " + Time.time);
                StartCoroutine("BattleWait");

                enemyParams = c.GetComponent<EnemyAbility>().GetParams();
                enemyParams.curHP -= playerParams.attack;

                //타격 연출 적용
                SendMessage("PlayerHitEffectActive");

                //타격 위치 알아내기
                HitTransformX = c.transform.position.x - ((c.GetComponent<BoxCollider2D>().size.x - c.GetComponent<BoxCollider2D>().offset.x) * c.transform.localScale.x / 2);
                HitTransformY = c.transform.position.y;
                HitTransform = new Vector3(HitTransformX, c.transform.position.y, c.transform.position.z);

                //타격 위치 및 공격력 전송
                tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
                tmpGameController.SendMessage("MonsterHitDamage", playerParams.attack);

                CheckEnemyCurHP2(c);
            }
        }
    }

    protected void CheckEnemyCurHP2(Collider2D cPass)
    {
        if (enemyParams.curHP > 0)
        {
            cPass.SendMessage("HealthBarValueUpdate", (float)enemyParams.curHP / (float)enemyParams.maxHP);    //!!
        }
        else
        {
            TargetDead2(cPass);
        }
    }

    protected void TargetDead2(Collider2D cPass)
    {
        cPass.SendMessage("HealthBarValueUpdate", 0f);
        cPass.SendMessage("CharacterStateControll", "Dead");
        //target.tag = "Untagged";
        cPass.SendMessage("CharacterDieEffect");

        SendMessage("CharacterStateControll", "Move");
        SendMessage("BattlingOn");
        SendMessage("PositionDistanceReset");

        //SendMessage("SearchEnemy");
        BattleStop();
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

        attackProssible = false;

        SendMessage("BattlingOn");
    }
}
