using UnityEngine;
using System.Collections;

public class EnemySkillStrew : EnemySkillType
{
    public int count { get; set; }

    public EnemySkillStrew()
    {
        this.currentSkillType = skillType.strew;
        this.count = 1;
    }
}
