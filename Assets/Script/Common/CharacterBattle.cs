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

    protected int totalAttack = 0;

    protected bool skillOn = false;


    protected GameObject projectilePrefab;
    protected GameObject presentProjectile;
    protected GameObject launchPosition;
    protected GameObject parentProjectile;

    protected float distance;
    protected float addArrowForceX = 3f;
    protected float addArrowForceY = 6f;

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

	public virtual void DoBattle()
    {
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

    public virtual void LongDistancelaunchHandler()
    {
        attackProssible = true;     ////// ???
        if (attackProssible == true)
        {
            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Bow || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackWeaponType == EnemyAbility.attackWeaponType.Bow)
            {
                float arrowForceX = (addArrowForceX - distance) * 0.1f + distance;
                float arrowForceY = (addArrowForceY - distance) * 0.5f + distance;
                if (arrowForceY >= 5f)
                    arrowForceY = 5f;

                presentProjectile = Instantiate(projectilePrefab, launchPosition.transform.position, Quaternion.Euler(0, 0, 45)) as GameObject;
                presentProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowForceX, arrowForceY), ForceMode2D.Impulse);           //arrow base 2.2f, 5.0f
                presentProjectile.SendMessage("RotateValue", distance);
            }
            else if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Gun || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackWeaponType == EnemyAbility.attackWeaponType.Gun)
            {
                presentProjectile = Instantiate(projectilePrefab, launchPosition.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                presentProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(15.0f, 0f), ForceMode2D.Impulse);           //arrow base 2.2f, 5.0f
            }
            else if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Bazooka || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackWeaponType == EnemyAbility.attackWeaponType.Bazooka)
            {
                presentProjectile = Instantiate(projectilePrefab, launchPosition.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                presentProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(10.0f, 0f), ForceMode2D.Impulse);           //arrow base 2.2f, 5.0f
            }
            else if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Staff || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackWeaponType == EnemyAbility.attackWeaponType.Staff)
            {
                presentProjectile = Instantiate(projectilePrefab, launchPosition.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                presentProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(8.0f, 0f), ForceMode2D.Impulse);           //arrow base 2.2f, 5.0f
            }
            else if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Wand || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackWeaponType == EnemyAbility.attackWeaponType.Wand)
            {
                presentProjectile = Instantiate(projectilePrefab, launchPosition.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                presentProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(5.0f, 0f), ForceMode2D.Impulse);           //arrow base 2.2f, 5.0f
            }

            presentProjectile.SendMessage("launchForceSetting", tag);
            presentProjectile.SendMessage("FlyingOn");

            presentProjectile.transform.SetParent(parentProjectile.transform);
        }
    }

    public virtual void AttackSuccessCall()
    {
        if (attackProssible == true)
        {
            AttackSuccess();
        }
    }

    public virtual void AttackSuccess()
    {
        attackActionCount++;
            
        if (tag == "Player")
        {
            target = GetComponent<PlayerAI>().GetCurrentTarget();

            enemyParams = target.GetComponent<EnemyAbility>().GetParams();

            if (skillOn == true)
            {
                target.SendMessage("AssaultAddforceOn", name);
                SendMessage("AttackLightValueXSetting", 5);   // 스킬에 따라 날아갈 값 설정, 폰은 기본적으로 무게가 3, 가로
                SendMessage("AttackLightValueYSetting", 5);
                    
                totalAttack = (int)(playerParams.attack * 2f);
            }                 
            else if (skillOn == false)
                totalAttack = playerParams.attack;

            enemyParams.curHP -= totalAttack;

            if (target.GetComponent<EnemyAI>().currentAssulttype == EnemyAI.assultType.defense)
                target.SendMessage("ChasePlayer");

            //타격 연출 적용  PlayerHitEffectActive
            SendMessage("PlayerHitEffectActive");

            //타격 위치 알아내기
            HitTransformX = target.transform.position.x - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
            HitTransformY = transform.position.y - ((GetComponent<BoxCollider2D>().size.y/2 - GetComponent<BoxCollider2D>().offset.y) * transform.localScale.y / 2);
            HitTransform = new Vector3(HitTransformX, HitTransformY, target.transform.position.z);

            if (skillOn == true)
            {
                tmpGameController.SendMessage("ActiveSkillOn");

                //스킬 타격 이펙트 On
                SendMessage("ActiveSkillOn");
            }

            //타격 위치 및 공격력 전송
            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            tmpGameController.SendMessage("MonsterHitDamage", totalAttack);
        }
        else if (tag == "Enemy")
        {
            target = GetComponent<EnemyAI>().GetCurrentTarget();

            playerParams = target.GetComponent<PlayerAbility>().GetParams();

            totalAttack = enemyParams.attack;
            playerParams.curHP -= totalAttack;

            //타격 연출 적용  EnemyHitEffectActive
            SendMessage("EnemyHitEffectActive");

            //타격 위치 알아내기
            HitTransformX = target.transform.position.x + ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
            HitTransformY = transform.position.y - ((GetComponent<BoxCollider2D>().size.y - GetComponent<BoxCollider2D>().offset.y) * transform.localScale.y / 2);
            HitTransform = new Vector3(HitTransformX, HitTransformY, target.transform.position.z);

            //타격 위치 및 공격력 전송
            tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
            tmpGameController.SendMessage("PlayerHitDamage", totalAttack);
        }
        //일반 공격 타격 이펙트
        SendMessage("NormalAttackEffectOn", HitTransform);

        CheckTargetCurHP();        
    }

    public virtual void AttackFail()
    {

    }


    public virtual void AttackEnd()
    {
        SendMessage("CharacterStateControll", "AttackDelay");
        attackProssible = false;

        if (skillOn == true)
        {
            SendMessage("ActivePlayerSkillOff", name);  // 임시로 자기 이름 던짐
            target.SendMessage("AssaultAddforceOff");
            tmpGameController.SendMessage("ActiveSkillOff");
            SendMessage("ActiveSkillOff");
        }
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

    public void attackProssibleOn()
    {
        attackProssible = true;
    }

    public void attackProssibleOff()
    {
        attackProssible = false;
    }

    public void ActiveSkillOn()
    {
        skillOn = true;
    }

    public void ActiveSkillOff()
    {
        skillOn = false;
    }

    public void TargetDistance(float tDistance)
    {
        distance = tDistance;
    }
}
