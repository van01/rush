using UnityEngine;
using System.Collections;

public class MonsterAbility : MonoBehaviour {

    public int monsterDataID;

    public MonsterParams myParams = new MonsterParams();

    public bool isHungry;
    public int currentTotalStat;

    protected MonsterParams monsterParams;

    private float nextTime;
    
    public void SetParams(MonsterParams tParams)
    {
        //myParams = tParams;
        myParams.id = tParams.id;

        myParams.name = tParams.name;
        myParams.monType = tParams.monType;

        myParams.level = tParams.level;
        myParams.minLevel = tParams.minLevel;

        myParams.fatigue = tParams.fatigue;
        myParams.hunger = tParams.hunger;

        myParams.currentFatigue = tParams.currentFatigue;
        myParams.currentHunger = tParams.currentHunger;

        myParams.statPow = tParams.statPow;
        myParams.statVit = tParams.statVit;
        myParams.statDex = tParams.statDex;
        myParams.statAgr = tParams.statAgr;
        myParams.statInt = tParams.statInt;
        myParams.statMal = tParams.statMal;
    }

    public MonsterParams GetParams()
    {
        return myParams;
    }

    void Update()
    {
        if (isHungry == true)
        {
            if (myParams.currentHunger > 0)
            {
                if (Time.time > nextTime)
                {
                    nextTime = Time.time + 0.1f;
                    myParams.currentHunger = myParams.currentHunger - 0.1f *10.0f;
                    //배고픔 계산
                }
            }
        }
    }

    public void HungryPlay()
    {
        isHungry = true;
    }

    public void HungryStop()
    {
        isHungry = false;
    }

    public void ChangeHunger(float nCurrentHunger)
    {
        myParams.currentHunger += nCurrentHunger;

        if (myParams.hunger <= myParams.currentHunger)
            myParams.currentHunger = myParams.hunger;
        else if (0 >= myParams.currentHunger)
            myParams.currentHunger = 0;
    }

    public void ChangeFatigue(float nCurrentFatigue)
    {
        myParams.currentFatigue += nCurrentFatigue;

        if (myParams.fatigue <= myParams.currentFatigue)
            myParams.currentFatigue = myParams.fatigue;
        else if (0 >= myParams.currentFatigue)
            myParams.currentFatigue = 0;
    }

    public void SumTotalStat()
    {
        currentTotalStat = myParams.statPow + myParams.statVit + myParams.statDex + myParams.statAgr + myParams.statInt + myParams.statMal;
    }

    public void LevelUp(int nCurrentLevel)
    {
        myParams.level = nCurrentLevel;
    }
    
    public void MyParamsInitialize()
    {
        //myParams 초기화 실패
        myParams = null;
    }
}
