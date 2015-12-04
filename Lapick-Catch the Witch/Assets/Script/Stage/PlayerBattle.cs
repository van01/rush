﻿using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle{
    
    protected Collider2D currentTargetColl;

    public GameObject coinPrefab;
    protected int coinValue;
    private GameObject presentCoin;
    private GameObject coinParent;
    private int coinCount = 0;

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

        coinParent = GameObject.Find("_CoinParent");

        coinCount = Random.Range(3, 6);

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
        SendMessage("CharacterStateControll", "Move");
        SendMessage("PositionDistanceReset");

        //for (int i = 0; i <= coinCount; i++)
        //{
        //    CoinSpawnHandler(target.transform);
        //}
    }

    private  IEnumerator BattleWait()
    {
        yield return new WaitForSeconds(attackWaitTime);
        SendMessage("CharacterStateControll", "Battle");

        attackActionCount = 0;
    }

    protected void CoinSpawnHandler(Transform tTrans)
    {
        float rForceX = Random.Range(-2f, 0f);
        float rForceY = Random.Range(2f, 8f);
        float rForceZ = Random.Range(0f, 0f);

        presentCoin = Instantiate(coinPrefab, tTrans.position, Quaternion.Euler(90, 0, 0)) as GameObject;
        presentCoin.GetComponent<Rigidbody>().AddForce(new Vector3(rForceX, rForceY, rForceZ), ForceMode.Impulse);
        presentCoin.transform.SetParent(coinParent.transform);
        presentCoin.SendMessage("CoinValueSetting", coinValue);

        coinValue = enemyParams.moneyBonus / coinCount;

        if (coinValue <= 1)
            coinValue = 1;
    }

    
}