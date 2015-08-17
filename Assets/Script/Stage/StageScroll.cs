using UnityEngine;
using System.Collections;

public class StageScroll : MonoBehaviour {
	
	public GameObject[] distanteA;
	public GameObject[] distanteB;
    public GameObject[] distanteC;

	public float scrollSpeedDropValue;

    public float movePositionX = -11.0f;

	private float scrollSpeed;
	private float[] distanteEachScrollSpeed;
	private bool scrollOn = false;
	private float initX;
	
	void Update(){
		if (scrollOn == true){
			for (int i = 0; i < distanteA.Length ; i++){
				Vector3 scrollValue = Vector3.left * distanteEachScrollSpeed[i] * Time.deltaTime;

				distanteA[i].transform.Translate(scrollValue, Space.World);
				distanteB[i].transform.Translate(scrollValue, Space.World);
                distanteC[i].transform.Translate(scrollValue, Space.World);

                if (distanteA[i].transform.position.x <= movePositionX)
                    distanteA[i].transform.position = new Vector3 (distanteC[i].transform.position.x + distanteA[i].GetComponent<BoxCollider2D>().size.x, distanteA[i].transform.position.y, distanteA[i].transform.position.z);

                if (distanteB[i].transform.position.x <= movePositionX)
                    distanteB[i].transform.position = new Vector3(distanteA[i].transform.position.x + distanteB[i].GetComponent<BoxCollider2D>().size.x, distanteB[i].transform.position.y, distanteB[i].transform.position.z);

                if (distanteC[i].transform.position.x <= movePositionX)
                    distanteC[i].transform.position = new Vector3(distanteB[i].transform.position.x + distanteC[i].GetComponent<BoxCollider2D>().size.x, distanteC[i].transform.position.y, distanteB[i].transform.position.z);
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
