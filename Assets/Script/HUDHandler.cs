using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

	public GameObject tmpGameController;

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
}
