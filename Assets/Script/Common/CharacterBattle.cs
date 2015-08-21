using UnityEngine;
using System.Collections;

public class CharacterBattle : MonoBehaviour {

    protected GameObject target;
    protected GameObject tmpGameController;
    protected Vector3 HitTransform;
    protected float HitTransformX;
    protected float HitTransformY;	

	protected PlayerParams playerParams;
	protected EnemyParams enemyParams;

	protected CharacterState myState;

    protected bool attackProssible = false;

    protected int attackActionCount = 0;

    public virtual void Start()
    {
        tmpGameController = GameObject.Find("GameController");
        SendMessage("WeaponColliderOff");
    }

	public virtual void StartBattle(){
        attackActionCount++;
        if (tag == "Player")
        {
            myState = GetComponent<PlayerState>();
            playerParams = GetComponent<PlayerAbility>().GetParams();            
        }
        else if (tag == "Enemy")
        {
            myState = GetComponent<EnemyState>();
            enemyParams = GetComponent<EnemyAbility>().GetParams();
        }

        DoBattle();      
    }

	public virtual void DoBattle(){
        if(this.tag == "Player"){
            //print("Start Battle -> Do Battle");
            //print("Do Battle Attack Action Count ::: " + attackActionCount);
        }
            
        if (attackActionCount == 1)
        {
            SendMessage("CharacterStateControll", "Attack");
            attackProssible = true;
        }
	}

    public virtual void BattleStop()
    {
        StopCoroutine("BattleWait");
        attackActionCount = 0;
    }

    public virtual void BattleEnd()
    {
        StopCoroutine("BattleWait");
        print("Battle End");
    }

    public virtual void AttackSuccess()
    {
        if (attackProssible == true)
        {
            if (tag == "Player")
            {
                target = GetComponent<PlayerAI>().GetCurrentTarget();

                enemyParams = target.GetComponent<EnemyAbility>().GetParams();
                enemyParams.curHP -= playerParams.attack;

                //타격 연출 적용  PlayerHitEffectActive
                SendMessage("PlayerHitEffectActive");
            }
            else if (tag == "Enemy")
            {
                target = GetComponent<EnemyAI>().GetCurrentTarget();

                playerParams = target.GetComponent<PlayerAbility>().GetParams();
                playerParams.curHP -= enemyParams.attack;

                //타격 연출 적용  EnemyHitEffectActive
                SendMessage("EnemyHitEffectActive");
            }

            //타격 위치 알아내기
            HitTransformX = target.transform.position.x - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
            HitTransformY = target.transform.position.y;
            HitTransform = new Vector3(HitTransformX, target.transform.position.y, target.transform.position.z);

            //타격 위치 및 공격력 전송
            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            if (tag == "Player")
                tmpGameController.SendMessage("MonsterHitDamage", playerParams.attack);
            else if (tag == "Enemy")
                tmpGameController.SendMessage("PlayerHitDamage", enemyParams.attack);

            CheckTargetCurHP();
        }
        SendMessage("CharacterStateControll", "AttackDelay");

        attackProssible = false;
    }

    public virtual void CheckTargetCurHP()
    {
        if (tag == "Player")
        {
            if (enemyParams.curHP > 0)
            {
                target.SendMessage("HealthBarValueUpdate", (float)enemyParams.curHP / (float)enemyParams.maxHP);    //!!
            }
            else
            {
                TargetDead();
            }
        }
        else if (tag == "Enemy")
        {
            if (playerParams.curHP > 0)
            {
                target.SendMessage("HealthBarValueUpdate", (float)playerParams.curHP / (float)playerParams.maxHP);    //!!
            }
            else
            {
                TargetDead();
            }
        }
    }

    public virtual void TargetDead()
    {
        //BattleStop();
        target.SendMessage("HealthBarValueUpdate", 0f);
        target.SendMessage("CharacterStateControll", "Dead");
        target.SendMessage("CharacterDieEffect");
    }

    
}
