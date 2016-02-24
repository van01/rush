using UnityEngine;
using System.Collections;

public class MonsterLevelController : MonoBehaviour {

    public GameObject levelUpEffect;

    private MonsterParams currentMonsterParams;

    private int _currentTotalStat;
    private int _crrentLevel;
    private string _crrentMonType;

    public void LevelUpCheck()
    {
        //레벨별 능력치 총합을 이용해 레벨 판단, 해당 데이터와 비교해 레벨 결정 기능 추가 필요
        currentMonsterParams = GetComponent<MonsterController>().currentMonster.GetComponent<MonsterAbility>().GetParams();
        _crrentLevel = currentMonsterParams.level;
        _crrentMonType = currentMonsterParams.monType;

        _currentTotalStat = GetComponent<MonsterController>().currentMonster.GetComponent<MonsterAbility>().currentTotalStat;

        MonsterLevelParams pParams = XMLManager.GetMonsterLevelParamsByMonType(_crrentMonType, _crrentLevel + 1);

        print(" id :" + pParams.id + " monType : " + pParams.monType + " level : " + pParams.level + " totalStat : " + pParams.totalStat);

        if (_currentTotalStat >= pParams.totalStat)
        {
            GetComponent<MonsterController>().currentMonster.SendMessage("LevelUp", _crrentLevel + 1);
            //레벨업 연출 추가
        }
            
    }
}
