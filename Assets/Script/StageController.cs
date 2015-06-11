using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public float scrollSpeed;

	private GameObject tmpStage;
	private GameObject tmpEnemy;

	void Start(){
		tmpStage = GameObject.FindGameObjectWithTag("Stage");
		tmpEnemy = GameObject.Find("Enemy");
	}

	public void StageScrollInialize(){
		tmpStage.SendMessage("ScrollOnTrue");
		tmpStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
		tmpEnemy.SendMessage("ScrollOnTrue");
		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

	public void DeliveryScrollOnTrue(){
		tmpStage.SendMessage("ScrollOnTrue");
		tmpEnemy.SendMessage("ScrollOnTrue");
	}

	public void DeliveryScrollOnFalse(){
		tmpStage.SendMessage("ScrollOnFalse");
		tmpEnemy.SendMessage("ScrollOnFalse");
	}

	public void RunScrollOn(){
		tmpStage.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
	}

	public void RunScrollOff(){
		tmpStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);

		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

	//gameStateController 완성 후 그쪽으로 모아야 함
}
