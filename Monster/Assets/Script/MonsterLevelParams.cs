using UnityEngine;
using System.Collections;

public class MonsterLevelParams : CharacterMonLevelParams
{

	public MonsterLevelParams()
    {
        this.id = 0;
        this.monType = "slime";

        this.level = 2;
        this.totalStat = 10;
    }
}
