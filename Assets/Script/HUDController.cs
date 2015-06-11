using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	public GameObject HUD;

	public void LeftHitZoneDown(){
		SendMessage("CharacterGuardPredicateOn");
	}

	public void LeftHitZoneUp(){
		SendMessage("CharacterGuardPredicateOff");
	}

	public void RightHitZoneDown(){
		SendMessage("RunScrollOn");
		SendMessage("CharacterRunPredicateOn");
	}

	public void RightHitZoneUp(){
		SendMessage("RunScrollOff");
		SendMessage("CharacterRunPredicateOff");
	}


	public void HitZoneOff(){
		HUD.SendMessage("HitZoneDisable");
	}

	public void HitZoneOn(){
		HUD.SendMessage("HitZoneAble");
	}

	public void TestMonsterDestroy(){
		GameObject tmpPlayer;
		GameObject target;

		tmpPlayer = GameObject.Find ("Pawn");

		target = tmpPlayer.GetComponent<PlayerAI>().GetCurrentTarget();

		Destroy(target);
	}
}
