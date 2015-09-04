using UnityEngine;
using System.Collections;

public class PlayerAbility : MonoBehaviour {

	PlayerParams myParams = new PlayerParams();

    public enum attackDistanceType { melee, longDistance }
    public attackDistanceType currentAttackDistanceType;

    public enum attackWeaponType { Sword, Spear, Bow, temp}
    public attackWeaponType currentAttackWeaponType;

	public void SetParams(PlayerParams tParams){
		myParams = tParams;
	}

	public PlayerParams GetParams(){
		return myParams;
	}
}
