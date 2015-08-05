using UnityEngine;
using System.Collections;

public class PlayerBattle : CharacterBattle{
    
    protected Collider2D currentTargetColl;

    public GameObject coinPrefab;
    protected int coinValue;
    private GameObject presentCoin;
    private GameObject coinParent;
    private int coinCount = 0;

    public float attackWaitTime = 0.7f;


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
        StopCoroutine("BattleWait");
    }

    public override void AttackSuccess()
    {
        base.AttackSuccess();        
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

        //SendMessage("BattlingOff");
        SendMessage("PositionDistanceReset");

        for (int i = 0; i <= coinCount; i++)
        {
            CoinSpawnHandler(target.transform);
        }
    }

    public void AttackEnd()
    {        
        StartCoroutine("BattleWait");
        //SendMessage("AttackAniInit");
        SendMessage("CharacterStateControll", "Battle");
        attackProssible = false;
        print("Attack End");
        //SendMessage("AttDistanceOn");   //AI: AttDistance true
    }

    private  IEnumerator BattleWait()
    {        
        //SendMessage("CharacterStateControll", "Battle");        
        //SendMessage("AttDistanceOn");
        yield return new WaitForSeconds(attackWaitTime);
        SendMessage("AttDistanceOn");

        attackActionCount = 0;
        //currentTargetColl.SendMessage("AssultStateOn");
        //SendMessage("BattlingOn");
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
