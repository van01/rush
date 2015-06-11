using UnityEngine;
using System.Collections;

public class PlayerParams : CharacterParams {

	public PlayerParams(){
		this.name = "pawn";
		this.id = 0;
		this.attackType = "Short";
		this.level = 1;
		this.maxHP = 50;
		this.curHP = this.maxHP;
		this.attack = 6;
		this.skillId = 0;

	}
}
