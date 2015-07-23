using UnityEngine;
using System.Collections;

public class CharacterParams{

	public string name {get; set;}
	public int id {get; set;}
    public enum unitTpye { Player, Enemy, Boss,}
    public unitTpye currentUnitType { get; set; }
	public enum attackType {Short,}
    public attackType currentAttackType { get; set; }
	public int level {get; set;}
	public int curHP {get; set;}
	public int maxHP {get; set;}
	public int attack {get; set;}
	public int skillId {get; set;}
}
