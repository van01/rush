using UnityEngine;
using System.Collections;

public class EnemyAbility : MonoBehaviour {

	EnemyParams myParams = new EnemyParams();

    public enum attackDistanceType { melee, longDistance }
    public attackDistanceType currentAttackDistanceType;

    public enum attackWeaponType { Sword, Spear, Bow, Gun, Bazooka, Staff, Wand }
    public attackWeaponType currentAttackWeaponType;

	public void SetParams(EnemyParams tParams){
		myParams = tParams;
	}
	
	public EnemyParams GetParams(){
		return myParams;
	}
}
