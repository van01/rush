using UnityEngine;
using System.Collections;

public class EnemyScroll : MonoBehaviour {
	
	private float scrollSpeed;
	private bool scrollOn = true;
	
	void Start(){
	}
	
	void Update(){
		if (scrollOn == true){
			Vector3 scrollValue = Vector3.left * scrollSpeed * Time.deltaTime;

			this.transform.Translate(scrollValue, Space.World);
		}
	}

	public void DeliveryScrollSpeed(float fSC){
		scrollSpeed = fSC * 4 ;
	}
	
	public void ScrollOnTrue(){
		scrollOn = true;
	}
	
	public void ScrollOnFalse(){
		scrollOn = false;
	}
}
