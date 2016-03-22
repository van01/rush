using UnityEngine;
using System.Collections;

public class BackGroundHandler : MonoBehaviour {

	public float scrollSpeed;
	public bool isScrollOn;

	void Update(){
		if (isScrollOn == true) {
			Vector3 backGroundScrollValue = Vector3.left * scrollSpeed * Time.deltaTime;
			transform.Translate(backGroundScrollValue, Space.World);
		}
	}

	public void testtest(){
		isScrollOn = true;
	}
}
