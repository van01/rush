using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	public void LeftHitZoneDown(){
		gameObject.SendMessage("DeliveryScrollOnFalse");
	}

	public void LeftHitZoneUp(){
		gameObject.SendMessage("DeliveryScrollOnTrue");
	}

	public void RightHitZoneDown(){
		gameObject.SendMessage("RunScrollOn");
		gameObject.SendMessage("CharacterStateChange", "Run");
	}

	public void RightHitZoneUp(){
		gameObject.SendMessage("RunScrollOff");
		gameObject.SendMessage("CharacterStateChange", "Move");
	}

	//gameStateController 완성 후 그쪽으로 모아야 함
}
