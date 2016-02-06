using UnityEngine;
using System.Collections;

public class EnemySkillAbility : MonoBehaviour {

    EnemySkillStrew enemySkillStrew = new EnemySkillStrew();

    public void SetParams(EnemySkillStrew tEnemySkillStrew)
    {
        enemySkillStrew = tEnemySkillStrew;
    }

    public EnemySkillStrew GetEnemySkillStrew()
    {
        return enemySkillStrew;
    }
}
