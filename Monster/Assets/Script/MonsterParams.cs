using UnityEngine;
using System.Collections;

public class MonsterParams : CharacterMonParams
{
	public MonsterParams()
    {
        this.name = "슬라임";
        this.id = 0;
        this.stress = 1000;
        this.hunger = 100;
        this.favoriteDish = 0;
        this.favoritePlay = 0;
        this.favoriteWork = 0;
        this.favoriteAdventure = 0;
    }
}
