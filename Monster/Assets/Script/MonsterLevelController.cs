using UnityEngine;
using System.Collections;

public class MonsterLevelController : MonoBehaviour {

    public GameObject levelUpEffect;

    private MonsterParams currentMonsterParams;
    private MonsterLevelParams pParams;

    private int _currentTotalStat;
    private string _crrentMonType;

    public void LevelUpCheck()
    {
        LevelCheck();

        if (_currentTotalStat >= pParams.totalStat)
        {
            GetComponent<MonsterController>().currentMonster.SendMessage("LevelUp", pParams.level);
            //레벨업 연출 추가
        }
    }

    public void CompulsionLevelCheck()
    {
        LevelCheck();

        if (_currentTotalStat >= pParams.totalStat)
        {
            GetComponent<MonsterController>().currentMonster.SendMessage("LevelUp", pParams.level);
        }
    }

    private void LevelCheck()
    {
        //레벨별 능력치 총합을 이용해 레벨 판단
        currentMonsterParams = GetComponent<MonsterController>().currentMonster.GetComponent<MonsterAbility>().GetParams();

        _crrentMonType = currentMonsterParams.monType;
        _currentTotalStat = GetComponent<MonsterController>().currentMonster.GetComponent<MonsterAbility>().currentTotalStat;

        pParams = XMLManager.GetMonsterLevelParamsByMonType(_crrentMonType, _currentTotalStat);
    }
}
