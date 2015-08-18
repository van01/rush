using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public float scrollSpeed;

	private GameObject tmpStage;
	private GameObject tmpEnemy;

    public GameObject[] stagePrefab;
    private GameObject presentStage;

    void Awake()
    {
        tmpStage = GameObject.FindGameObjectWithTag("Stage");
        tmpStage.SetActive(false);
    }

	void Start(){
		tmpEnemy = GameObject.Find("Enemy");
	}

    public void StageInialize()
    {
        for (int i = 0; i < stagePrefab.Length; i++)
        {
            if (PlayerPrefs.GetInt("currentStage") == i)
            {
                presentStage = Instantiate(stagePrefab[i], transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
    }

	public void StageScrollInialize(){
        presentStage.SendMessage("ScrollOnTrue");
        presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
        presentStage.SendMessage("ScrollOnTrue");
        presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

	public void DeliveryScrollOnTrue(){
		presentStage.SendMessage("ScrollOnTrue");
		tmpEnemy.SendMessage("ScrollOnTrue");
	}

	public void DeliveryScrollOnFalse(){
		presentStage.SendMessage("ScrollOnFalse");
		tmpEnemy.SendMessage("ScrollOnFalse");
	}

	public void RunScrollOn(){
		presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
	}

	public void RunScrollOff(){
		presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

	//gameStateController 완성 후 그쪽으로 모아야 함
}
