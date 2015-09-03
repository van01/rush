using UnityEngine;
using System.Collections;

public class EnemyAbility : MonoBehaviour {

	EnemyParams myParams = new EnemyParams();

    public enum attackWeaponType { Sword, Spear, temp }
    public attackWeaponType currentAttackWeaponType;

	public void SetParams(EnemyParams tParams){
		myParams = tParams;
	}
	
	public EnemyParams GetParams(){
		return myParams;
	}
}
