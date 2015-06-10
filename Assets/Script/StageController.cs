using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public float scrollSpeed;

	private GameObject tmpStage;

	void Start(){
		tmpStage = GameObject.FindGameObjectWithTag("Stage");

		tmpStage.SendMessage("ScrollOnTrue");
		tmpStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

	public void DeliveryScrollOnTrue(){
		tmpStage.SendMessage("ScrollOnTrue");
	}

	public void DeliveryScrollOnFalse(){
		tmpStage.SendMessage("ScrollOnFalse");
	}

	public void RunScrollOn(){
		tmpStage.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
	}

	public void RunScrollOff(){
		tmpStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

	//gameStateController 완성 후 그쪽으로 모아야 함
}
