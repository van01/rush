using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {
	protected float scrollSpeed;

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

    private Transform baseBlockTransform;

    void Awake()
    {
        
        baseBlockTransform = ScrollFloorCollider2D.transform.FindChild("FloorScrollBlock").transform.FindChild("BaseBlock");

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
        tmpStage = GameObject.FindGameObjectWithTag("Stage");

        if (tmpStage != null)
            Destroy(tmpStage);

        if (stagePrefab.Length < StageTestNumber)
            StageInialize();

        if (isStageTest == true)
        {
            presentStage = Instantiate(stagePrefab[StageTestNumber], transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            presentStage.SendMessage("FloorSetting", isRWStage);
            if (presentStage.GetComponent<StageColorController>().randomSpriteColorApply == true)
                StageColorActiveOn();

            SendMessage("StageLevelInitialize");
            baseBlockTransform.SendMessage("DeliveryBaseBlockScrollSpeed", scrollSpeed);    // baseBlock에 속도 전달
            BaseBlockScrollOnDelivery();    // 오프닝 종료 후 시작
            StageScrollInialize();
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

        if (isEnemyAppear == true)
        {
            tmpEnemy.SendMessage("ScrollOnTrue");
            tmpEnemy.SendMessage("DeliveryScrollSpeed", scrollSpeed);
        }
	}

    public void RWBlockScrollon()
    {
        if (isRWStage == true)
        {
            ScrollFloorCollider2D.SendMessage("DeliveryFloorScrollSpeedValue", scrollSpeed);        //블럭 스크롤
            ScrollFloorCollider2D.SendMessage("BlockScrollOn");
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
            ScrollFloorCollider2D.SendMessage("BlockScrollOff");
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

    public void BlockInitDelivery()
    {
        baseBlockTransform.gameObject.SetActive(true);
        ScrollFloorCollider2D.transform.FindChild("FloorScrollBlock").SendMessage("ResetBlockScroll");
        ScrollFloorCollider2D.transform.FindChild("FloorScrollBlock").GetComponent<RWBlockController>().AllBlockDelete();
        baseBlockTransform.SendMessage("BaseBlockInit");
        //ResetBlockScroll
        //AllBlockDelete
    }

    public void BaseBlockScrollOnDelivery()
    {
        baseBlockTransform.SendMessage("ScrollOnBaseBlock");
    }

    public void ScrollSpeedRefresh(float nScrollSpeed)
    {
        scrollSpeed = nScrollSpeed;

        presentStage.SendMessage("DeliveryScrollSpeed", scrollSpeed);
        ScrollFloorCollider2D.SendMessage("DeliveryFloorScrollSpeedValue", scrollSpeed);
    }

    //level
    //ScrollFloorCollider2D 
    public void PresentBlockColMinSizeXMessenger(string nMinSize)
    {
        ScrollFloorCollider2D.SendMessage("PresentBlockColMinSizeXDelivery", nMinSize);
    }

    public void PresentBlockColMaxSizeXMessenger(string nMaxSize)
    {
        ScrollFloorCollider2D.SendMessage("PresentBlockColMaxSizeXDelivery", nMaxSize);
    }

    public void PresentBlockSpaceMinSizeXMessenger(string nMinSize)
    {
        ScrollFloorCollider2D.SendMessage("PresentBlockSpaceMinSizeXDelivery", nMinSize);
    }

    public void PresentBlockSpaceMaxSizeXMessenger(string nMaxSize)
    {
        ScrollFloorCollider2D.SendMessage("PresentBlockSpaceMaxSizeXDelivery", nMaxSize);
    }

    public void PresentBlockSpaceMinSizeYMessenger(string nMinSize)
    {
        ScrollFloorCollider2D.SendMessage("PresentBlockSpaceMinSizeYDelivery", nMinSize);
    }

    public void PresentBlockSpaceMaxSizeYMessenger(string nMaxSize)
    {
        ScrollFloorCollider2D.SendMessage("PresentBlockSpaceMaxSizeYDelivery", nMaxSize);
    }
}
