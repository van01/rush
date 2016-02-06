using UnityEngine;
using System.Collections;

public class EnemySkillSummon : EnemySkillType
{
    public int count { get; set; }

    public EnemySkillSummon()
    {
        this.currentSkillType = skillType.line;
        this.count = 1;
    }
}
