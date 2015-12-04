using UnityEngine;
using System.Collections;

public class EnemyBattle : CharacterBattle{

    protected Collider2D currentTargetColl;
    protected GameObject currentTargetGameObject;

    public float attackWaitTime = 0.7f;
    public float attackSuccessDelay = 0.3f;

    public GameObject projectilePrefabLink;
    public GameObject mlaunchPositionLink;
    public GameObject parentProjectileLink;

    public override void Start()
    {
        base.Start();

        projectilePrefab = projectilePrefabLink;
        launchPosition = mlaunchPositionLink;
        parentProjectile = parentProjectileLink;

        SendMessage("attackSuccessDelayValueSetting", attackSuccessDelay);
    }

    public override void StartBattle()
    {
        base.StartBattle();
    }

    public override void DoBattle()
    {
        base.DoBattle();
    }

    public override void BattleStop()
    {
        base.BattleStop();
    }

    public override void BattleEnd()
    {
        base.BattleEnd();
    }

    public override void AttackSuccess()
    {
        base.AttackSuccess();
        StartCoroutine("BattleWait");
    }

    public override void AttackFail()
    {
        base.AttackFail();
        StartCoroutine("BattleWait");
    }

    public override void AttackEnd()
    {
        base.AttackEnd();
    }

    public override void CheckTargetCurHP()
    {
        base.CheckTargetCurHP();
    }

    public override void TargetDead()
    {
        base.TargetDead();
        BattleEnd();
        SendMessage("CharacterStateControll", "Idle");
    }

    private IEnumerator BattleWait()
    {
        yield return new WaitForSeconds(attackWaitTime);
        SendMessage("CharacterStateControll", "Battle");

        attackActionCount = 0;
    }
}
