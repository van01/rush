using UnityEngine;
using System.Collections;

public class StageScroll : MonoBehaviour {
	
	public GameObject[] distanteA;
	public GameObject[] distanteB;

	public float scrollSpeedDropValue;

	private float scrollSpeed;
	private float[] distanteEachScrollSpeed;
	private bool scrollOn = false;
	private float[] initX;

	void Start(){
        initX = new float[distanteA.Length];

        for (int i = 0; i < distanteA.Length ; i++){
            initX[i] = distanteB[i].transform.position.x;
        }
	}
	
	void Update(){
		if (scrollOn == true){
			for (int i = 0; i < distanteA.Length ; i++){
				Vector3 scrollValue = Vector3.left * distanteEachScrollSpeed[i] * Time.deltaTime;

				distanteA[i].transform.Translate(scrollValue, Space.World);
				distanteB[i].transform.Translate(scrollValue, Space.World);

				if (distanteA[i].transform.position.x <= -initX[i])
					distanteA[i].transform.position = new Vector3 (initX[i], distanteA[i].transform.position.y, distanteA[i].transform.position.z);

				if (distanteB[i].transform.position.x <= -initX[i])
					distanteB[i].transform.position = new Vector3 (initX[i], distanteB[i].transform.position.y, distanteB[i].transform.position.z);
			}
		}
	}

	public void DeliveryScrollSpeed(float fSC){
		scrollSpeed = fSC;

		distanteEachScrollSpeed = new float[distanteA.Length];
		
		for (int i = 0 ; i < distanteA.Length ; i++){
			distanteEachScrollSpeed[i] = (i + 1) * scrollSpeed * scrollSpeedDropValue;
		}
	}

	public void ScrollOnTrue(){
		scrollOn = true;
	}

	public void ScrollOnFalse(){
		scrollOn = false;
	}
}
