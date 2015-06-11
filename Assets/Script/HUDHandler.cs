using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

	public GameObject tmpGameController;

	public GameObject hitZone_L;
	public GameObject hitZone_R;

	void LeftHitZoneTriggerDown(){
		tmpGameController.SendMessage("LeftHitZoneDown");
	}

	void LeftHitZoneTriggerUp(){
		tmpGameController.SendMessage("LeftHitZoneUp");
	}

	void RightHitZoneTriggerDown(){
		tmpGameController.SendMessage("RightHitZoneDown");
	}

	void RightHitZoneTriggerUp(){
		tmpGameController.SendMessage("RightHitZoneUp");
	}

	public void HitZoneDisable(){
		hitZone_L.SetActive(false);
		hitZone_R.SetActive(false);
	}

	public void HitZoneAble(){
		hitZone_L.SetActive(true);
		hitZone_R.SetActive(true);
	}
}
