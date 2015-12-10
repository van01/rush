using UnityEngine;
using System.Collections;

public class MonsterAbility : MonoBehaviour {

    public int monsterDataID;

    MonsterParams myParams = new MonsterParams();
    protected MonsterParams monsterParams;
    private float _currentTime;

    public void SetParams(MonsterParams tParams)
    {
        myParams = tParams;
    }

    public MonsterParams GetParams()
    {
        return myParams;
    }

    void Start()
    {
        _currentTime = Timer.GetTimer();
    }

    void Update()
    {
        myParams.currentHunger = myParams.currentHunger - _currentTime * 10.0f;
    }

    public void TrainingComplete()
    {
        myParams.statPow += 9;
        print(myParams.statPow);
        //연출 후 해당 함수 호출, 팝업 호출 기능 추가, 진화 가능 몬스터 존재여부 체크
        SendMessage("NextEvolutionMonsterCheck");
    }
}
