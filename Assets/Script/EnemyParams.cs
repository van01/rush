using UnityEngine;
using System.Collections;

public class EnemyParams : CharacterParams {

	public EnemyParams(){
		this.name = "Enemy";
		this.id = 0;
		this.attackType = "Short";
		this.level = 1;
		this.maxHP = 10000;
		this.curHP = this.maxHP;
		this.attack = 5;
		this.skillId = 0;
		
	}
}
