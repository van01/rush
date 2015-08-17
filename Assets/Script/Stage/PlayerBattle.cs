using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle{

    private int attackCount = 0;
    
    protected Collider2D currentTargetColl;

    public GameObject coinPrefab;
    protected int coinValue;
    private GameObject presentCoin;
    private GameObject coinParent;
    private int coinCount = 0;


    public override void Start()
    {
        base.Start();

        coinParent = GameObject.Find("_CoinParent");

        coinCount = Random.Range(3, 6);
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

    public override void CheckTargetCurHP()
    {
        base.CheckTargetCurHP();
    }

    public override void TargetDead()
    {
        base.TargetDead();

        SendMessage("CharacterStateControll", "Move");
        SendMessage("BattlingOn");
        SendMessage("PositionDistanceReset");

        for (int i = 0; i <= coinCount; i++)
        {
            CoinSpawnHandler(target.transform);
        }
    }

    public void AttackEnd()
    {
        SendMessage("AttackAniInit");
        attackProssible = false;
    }

    private  IEnumerator BattleWait()
    {
        float attackWaitTime = 1.0f;
        SendMessage("CharacterStateControll", "Battle");

        yield return new WaitForSeconds(attackWaitTime);

        attackActionCount = 0;
        //currentTargetColl.SendMessage("AssultStateOn");
        SendMessage("BattlingOn");
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
