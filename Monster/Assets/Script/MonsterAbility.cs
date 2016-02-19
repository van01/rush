using UnityEngine;
using System.Collections;

public class MonsterAbility : MonoBehaviour {

    public int monsterDataID;

    MonsterParams myParams = new MonsterParams();
    protected MonsterParams monsterParams;
    private float nextTime;

    public void SetParams(MonsterParams tParams)
    {
        myParams = tParams;
    }

    public MonsterParams GetParams()
    {
        return myParams;
    }

    void Update()
    {
        if (myParams.currentHunger > 0 )
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + 0.1f;
                myParams.currentHunger = myParams.currentHunger - 0.1f * 10.0f;
            }
        }
    }

    public void TrainingComplete()
    {
        myParams.statPow += 9;
        //연출 후 해당 함수 호출, 팝업 호출 기능 추가, 진화 가능 몬스터 존재여부 체크
        SendMessage("NextEvolutionMonsterCheck");
    }

    public void ChargeHunger(float nDishPoint)
    {
        if (myParams.hunger < myParams.currentHunger)
            myParams.currentHunger += nDishPoint;
        else if (myParams.hunger >= myParams.currentHunger)
            myParams.currentHunger = myParams.hunger;
    }
}
