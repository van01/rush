using UnityEngine;
using System.Collections;

public class EnemyBattle : CharacterBattle{

    private int attackCount = 0;

    protected Collider2D currentTargetColl;
    protected GameObject currentTargetGameObject;

    public override void Start()
    {
        base.Start();
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

    public void AttackSuccess()
    {
        base.AttackSuccess();

        StartCoroutine("BattleWait");
    }

    public override void CheckTargetCurHP()
    {
        base.CheckTargetCurHP();
    }

    public override void TargetDead()
    {
        base.TargetDead();

        SendMessage("CharacterStateControll", "Idle");
    }

    public void AttackEnd()
    {
        //SendMessage("CharacterStateControll", "Battle");
        //print("attack End");
        SendMessage("WeaponColliderOff");
        SendMessage("AttackAniInit");
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
