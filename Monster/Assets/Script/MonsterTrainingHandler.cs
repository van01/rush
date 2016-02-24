using UnityEngine;
using System.Collections;

public class MonsterTrainingHandler : MonoBehaviour {

    public void TrainingComplete()
    {
        //훈련 완료
        //훈련 증가 능력치, 1회 훈련으로 능력치 평균 4증가. 총 5회의 기회 중 1회 정도의 실패 확률 추가
        //현재의 배고픔, 피로도 수치에 따라 확률 영향. ex> 배고픔 0, 피로도 100 = 확률 0;
        GetComponent<MonsterAbility>().myParams.statPow += 4;

        //훈련으로 증감될 배고픔, 피로도
        SendMessage("ChangeHunger", -20.0f);
        SendMessage("ChangeFatigue", 30.0f);

        SendMessage("SumTotalStat");
        transform.root.GetComponent<MonsterBasket>().tmpGameController.SendMessage("LevelUpCheck");
        //GetComponent<MonsterAbility>().myParams.currentHunger -= 20.0f;
        //GetComponent<MonsterAbility>().myParams.currentFatigue += 30.0f;

        //연출 후 해당 함수 호출, 팝업 호출 기능 추가, 진화 가능 몬스터 존재여부 체크
        //SendMessage("NextEvolutionMonsterCheck");
    }

    public void TrainingAttackSuccess()
    {
        transform.root.SendMessage("AttackSuccess");
    }
}
