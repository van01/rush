using UnityEngine;
using System.Collections;

public class EnemyParams : CharacterParams {

	public EnemyParams(){
		this.name = "Enemy";
		this.id = 0;
		this.attackType = "Short";
		this.level = 1;
		this.maxHP = 5000;
		this.curHP = this.maxHP;
		this.attack = 6;
		this.skillId = 0;
		
	}
}
