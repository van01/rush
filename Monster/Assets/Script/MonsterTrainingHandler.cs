using UnityEngine;
using System.Collections;

public class MonsterTrainingHandler : MonoBehaviour {

    private int _currentTrainingMountTotalValue;
    private TrainingController _trainingController;

    public void TrainingComplete()
    {
        //훈련 완료
        CurrentTrainingResultSetting();

        //훈련으로 증감될 배고픔, 피로도
        SendMessage("ChangeHunger", -20.0f);
        SendMessage("ChangeFatigue", 30.0f);

        SendMessage("SumTotalStat");
        transform.root.GetComponent<MonsterBasket>().tmpGameController.SendMessage("LevelUpCheck");
        //GetComponent<MonsterAbility>().myParams.currentHunger -= 20.0f;
        //GetComponent<MonsterAbility>().myParams.currentFatigue += 30.0f;
    }

    public void TrainingAttackSuccess()
    {
        transform.root.SendMessage("AttackSuccess");
    }

    public void TrainingAttackFail()
    {
        transform.root.SendMessage("AttackFail");
    }

    public void CurrentTrainingResultSetting()
    {
        //훈련 종료 내용 적용 설정
        _trainingController = transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<TrainingController>();

        _currentTrainingMountTotalValue = _trainingController.TrainingResultTotalValue();

        if (_trainingController.currentTraining == TrainingController.TrainingType.Pow)
        {
            GetComponent<MonsterAbility>().myParams.statPow += _currentTrainingMountTotalValue;
        }
    }
}
