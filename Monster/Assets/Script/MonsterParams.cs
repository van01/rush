using UnityEngine;
using System.Collections;

public class MonsterParams : CharacterMonParams
{
	public MonsterParams()
    {
        this.id = 0;
        this.name = "어린 슬라임";

        this.monType = "slime";

        this.stress = 1000f;
        this.hunger = 100f;

        this.currentStress = this.stress;
        this.currentHunger = this.hunger;

        this.statPow = 1;
        this.statVit = 1;
        this.statDex = 1;
        this.statAgr = 1;
        this.statInt = 1;
        this.statMal = 1;

        this.monPrice = 10;
    }
}
