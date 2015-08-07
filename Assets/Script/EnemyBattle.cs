using UnityEngine;
using System.Collections;

public class EnemyBattle : CharacterBattle{

    private GameObject target;
    private GameObject tmpGameController;
    private Vector3 HitTransform;
    private float HitTransformX;
    private float HitTransformY;

    private int attackCount = 0;
    private int attackActionCount = 0;

    protected bool attackProssible = false;

    protected Collider2D currentTargetColl;
    protected GameObject currentTargetGameObject;

    void Start () {
        tmpGameController = GameObject.Find("GameController");
        SendMessage("WeaponColliderOff");
    }

    public override void StartBattle()
    {
        myState = GetComponent<EnemyState>();
        enemyParams = GetComponent<EnemyAbility>().GetParams();
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
        //SendMessage("CharacterStateControll", "Move");
        StopCoroutine("BattleWait");
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
        if (c.transform.root.tag == "Player")
        {
            if (attackProssible == true)
                currentTargetColl = c.transform.root.gameObject.GetComponent<BoxCollider2D>();
                //currentTargetGameObject = c.transform.root.gameObject;
            {
                StartCoroutine("BattleWait");

                playerParams = currentTargetColl.GetComponent<PlayerAbility>().GetParams();
                playerParams.curHP -= enemyParams.attack;

                //타격 연출 적용
                SendMessage("EnemyHitEffectActive");

                //타격 위치 알아내기
                HitTransformX = currentTargetColl.transform.position.x - ((c.GetComponent<BoxCollider2D>().size.x - currentTargetColl.GetComponent<BoxCollider2D>().offset.x) * currentTargetColl.transform.localScale.x / 2);
                HitTransformY = currentTargetColl.transform.position.y;
                HitTransform = new Vector3(HitTransformX, currentTargetColl.transform.position.y, currentTargetColl.transform.position.z);

                //타격 위치 및 공격력 전송
                tmpGameController.SendMessage("HitPositionSetting", Camera.main.WorldToScreenPoint(HitTransform));
                tmpGameController.SendMessage("PlayerHitDamage", enemyParams.attack);

                CheckEnemyCurHP(currentTargetColl);
            }
        }
    }

    protected void CheckEnemyCurHP(Collider2D cPass)
    {
        if (playerParams.curHP > 0)
        {
            cPass.SendMessage("HealthBarValueUpdate", (float)playerParams.curHP / (float)playerParams.maxHP);    //!!
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

        SendMessage("CharacterStateControll", "Idle");

        //BattleStop();
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
