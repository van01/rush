using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	public float scrollSpeed;

    public bool isStageTest = false;
    public int StageTestNumber = 0;

    public GameObject floorCollider2D;
    public GameObject ScrollFloorCollider2D;

    public bool isRWStage = false;
    public bool isEnemyAppear = false;

	private GameObject tmpStage;
	private GameObject tmpEnemy;

    public GameObject[] stagePrefab;
    private GameObject presentStage;

    void Awake()
    {
        tmpStage = GameObject.FindGameObjectWithTag("Stage");
        if (tmpStage != null)
            tmpStage.SetActive(false);
    }

	void Start(){
		tmpEnemy = GameObject.Find("Enemy");

        if (isRWStage == true)
        {
            floorCollider2D.SetActive(false);
            ScrollFloorCollider2D.SetActive(true);
        }
        else
        {
            floorCollider2D.SetActive(true);
            ScrollFloorCollider2D.SetActive(false);
        }
    }

    public void StageInialize()
    {
        if (stagePrefab.Length < StageTestNumber)
            StageInialize();

        if (isStageTest == true)
        {
            presentStage = Instantiate(stagePrefab[StageTestNumber], transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            presentStage.SendMessage("FloorSetting", isRWStage);
            if (presentStage.GetComponent<StageColorController>().randomSpriteColorApply == true)
                StageColorActiveOn();
        }
        else
        {
            StageInstatiate();
        }
    }

    void StageInstatiate()
    {
        for (int i = 0; i < stagePrefab.Length; i++)
        {
            if (PlayerPrefs.GetInt("currentStage") == i)
            {
                presentStage = Instantiate(stagePrefab[i], transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                presentStage.SendMessage("FloorSetting", isRWStage);
                if (presentStage.GetComponent<StageColorController>().randomSpriteColorApply == true)
                    StageColorActiveOn();
            }
        }
    }

	public void StageScrollInialize(){
        presentStage.SendMessage("ScrollOnTrue");
        presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);

        if (isRWStage == true)
            ScrollFloorCollider2D.SendMessage("DeliveryFloorScrollSpeedValue", scrollSpeed);

        if (isEnemyAppear == true)
        {
            tmpEnemy.SendMessage("ScrollOnTrue");
            tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed);
        }
	}

	public void DeliveryScrollOnTrue(){
		presentStage.SendMessage("ScrollOnTrue");
		tmpEnemy.SendMessage("ScrollOnTrue");
	}

	public void DeliveryScrollOnFalse(){
        if (isRWStage == true)
        {
            presentStage.SendMessage("ScrollOnFalse");
            ScrollFloorCollider2D.SendMessage("BlockScrollOnFalse");
        }
        else
        {
            presentStage.SendMessage("ScrollOnFalse");
            tmpEnemy.SendMessage("ScrollOnFalse");
        }
	}

	public void RunScrollOn(){
		presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed * 2);
	}

	public void RunScrollOff(){
		presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
		tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed);
	}

    public void StageColorActiveOn()
    {
        presentStage.SendMessage("StageColorActive");
    }

	//gameStateController 완성 후 그쪽으로 모아야 함
}
