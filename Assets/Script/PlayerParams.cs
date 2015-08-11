using UnityEngine;
using System.Collections;

public class PlayerParams : CharacterParams {

	public PlayerParams(){
		this.name = "pawn";
		this.id = 0;
        this.currentUnitType = unitTpye.Player;
        this.currentAttackType = attackType.Short;
		this.level = 1;
		this.maxHP = 1000;
		this.curHP = this.maxHP;
		this.attack = 5;
		this.skillId = 0;

	}
}
