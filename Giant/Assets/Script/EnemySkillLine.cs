using UnityEngine;
using System.Collections;

public class EnemySkillLine : EnemySkillType
{
    public int count { get; set; }

    public EnemySkillLine()
    {
        this.currentSkillType = skillType.line;
        this.count = 1;
    }
}
