using UnityEngine;
using System.Collections;

public class EnemyParams : CharacterParams {
    public int moneyBonus { get; set; }

	public EnemyParams(){
		this.name = "Enemy";
		this.id = 0;
        this.currentUnitType = unitTpye.Enemy;
        this.currentAttackType = attackType.Short;
		this.level = 1;
		this.maxHP = 10;
		this.curHP = this.maxHP;
		this.attack = 5;
		this.skillId = 0;
        this.moneyBonus = 100;
	}
}
