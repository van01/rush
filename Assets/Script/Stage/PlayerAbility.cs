using UnityEngine;
using System.Collections;

public class PlayerAbility : MonoBehaviour {

	PlayerParams myParams = new PlayerParams();

    public enum attackWeaponType { Sword, Spear, temp}
    public attackWeaponType currentAttackWeaponType;

	public void SetParams(PlayerParams tParams){
		myParams = tParams;
	}

	public PlayerParams GetParams(){
		return myParams;
	}
}
