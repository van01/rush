using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle
{

    private GameObject target;
    private GameObject tmpGameController;
    private Vector3 HitTransform;
    private float HitTransformX;
    private float HitTransformY;

    private int attackCount = 0;
    private int attackActionCount = 0;

    protected bool attackProssible = false;

    protected Collider2D currentTargetColl;

    void Start()
    {
        tmpGameController = GameObject.Find("GameController");
        SendMessage("WeaponColliderOff");
    }

    public override void StartBattle()
    {
        myState = GetComponent<PlayerState>();
        playerParams = GetComponent<PlayerAbility>().GetParams();
        DoBattle();
    }

    public override void DoBattle()
    {
        attackActionCount++;
        if (attackActionCount == 1)
        {
            SendMessage("CharacterStateControll", "Attack");
            attackProssible = true;
        }
    }

    public void BattleStop()
    {
        StopCoroutine("BattleWait");
        attackActionCount = 0;
    }

    public void BattleEnd()
    {
        print("Battle End");
    }

    public void AttackSuccess()
    {
        //attackProssible = true;
        SendMessage("WeaponColliderReset");
        SendMessage("BattlingOff");
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            if (attackProssible == true)
            {
                currentTargetColl = c;
            
                StartCoroutine("BattleWait");

                enemyParams = currentTargetColl.GetComponent<EnemyAbility>().GetParams();
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

                CheckEnemyCurHP(c);
            }
        }
    }

    protected void CheckEnemyCurHP(Collider2D cPass)
    {
        if (enemyParams.curHP > 0)
        {
            cPass.SendMessage("HealthBarValueUpdate", (float)enemyParams.curHP / (float)enemyParams.maxHP);    //!!
        }
        else
        {
            TargetDead(cPass);
        }
    }

    protected void TargetDead(Collider2D cPass)
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
        //SendMessage("CharacterStateControll", "Battle");
        //print("attack End");
        SendMessage("WeaponColliderOff");
    }

    private IEnumerator BattleWait()
    {

        float attackWaitTime = 1.0f;
        SendMessage("CharacterStateControll", "Battle");

        yield return new WaitForSeconds(attackWaitTime);
        attackCount = 0;
        attackActionCount = 0;
        //currentTargetColl.SendMessage("AssultStateOn");
        SendMessage("BattlingOn");
    }
}
