using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

    public float colorDisableDelay = 0.1f;

    public float healthBarX;
    public float healthBarY;

	private GameObject tmpGameController;
    private SpriteRenderer[] myAllSpriteRenderer;

    private float hitColorR = 1.0f;
    private float hitColorG = 0f;
    private float hitColorB = 0f;

    private float backupColorR;
    private float backupColorG;
    private float backupColorB;

    private float hittingPosition = 0.05f;
    private float totalhittingPosition;
    private float backupPosition;

    public GameObject healthBarPrefab;
    private GameObject healthBar;
    private Vector3 healthBarPoint;

    private GameObject tmpHUD;

    public float DeadDelay = 0.5f;

    private int sortValue;

	void Awake(){
        tmpHUD = GameObject.Find("Canvas");
		tmpGameController = GameObject.Find("GameController");
        myAllSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            backupColorR = myAllSpriteRenderer[i].color.r;
            backupColorG = myAllSpriteRenderer[i].color.g;
            backupColorB = myAllSpriteRenderer[i].color.b;
        }   //수정 필요

        // 타격 색상 및 포지션 Player 음수 설정
        if (gameObject.CompareTag("Player"))
        {
            hitColorR = 1.0f;
            hitColorG = 0.3f;
            hitColorB = 0.3f;
            hittingPosition = hittingPosition * -1;
        }

        if (gameObject.CompareTag("Enemy"))
        {
            hitColorR = 1.0f;
            hitColorG = 0f;
            hitColorB = 0f;
        }


        float healthBarInitX = healthBarX + transform.position.x;
        float healthBarInitY = healthBarY + transform.position.y;

        HelthBarInitPositionSetting(new Vector3(healthBarInitX, healthBarInitY, 0));

        
	}

    void Start()
    {
        HelthBarInitialize();
    }

	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag == "Enemy"){
			tmpGameController.SendMessage("CharacterEnterCheckTrue");

			GameStateHoldOn();
		}
	}

	public void GameStateHoldOn(){
		tmpGameController.SendMessage("GameStateControll", "Hold");
	}

	public void CharacterStateBattleOn(){
		tmpGameController.SendMessage("CharacterBattlePredicateOn");
	}

	public void CharacterStateMoveOn(){
		tmpGameController.SendMessage("CharacterMovePredicateOn");
	}

    public void CharacterHitOn()
    {
        //타격 시 위치 바꾸기
        backupPosition = transform.position.x;
        totalhittingPosition = hittingPosition + backupPosition;
        transform.position = new Vector3(totalhittingPosition, transform.position.y, transform.position.z);

        //타격 시 멈추기
        SendMessage("AnimationStop");

        //타격 시 색깔 바꾸기
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].color = new Vector4(hitColorR, hitColorG, hitColorB, 1.0f);
        }

        StartCoroutine("CharacterHitOff");
    }

    IEnumerator CharacterHitOff()
    {
        yield return new WaitForSeconds(colorDisableDelay);
        transform.position = new Vector3(backupPosition, transform.position.y, transform.position.z);

        SendMessage("AnimationPlay");

        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].color = new Vector4(backupColorR, backupColorG, backupColorB, 1.0f);
        }
    }

    public void hittingPositionValueSetting(float i)
    {
        hittingPosition = i;
    }
    
    public void HelthBarInitPositionSetting(Vector3 vInitPoint)
    {
        healthBarPoint = vInitPoint;
    }

    public void HelthBarInitialize()
    {
        healthBar = Instantiate(healthBarPrefab, Camera.main.WorldToScreenPoint(healthBarPoint), tmpHUD.transform.rotation) as GameObject;
        healthBar.GetComponent<RectTransform>().SetParent(tmpHUD.transform);
        healthBar.GetComponent<RectTransform>().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
        healthBar.name = healthBar.name + sortValue;
        if(gameObject.tag == "Player")
            healthBar.transform.FindChild("Mask").transform.FindChild("Image").GetComponent<Image>().color = new Vector4(0.0f, 1.0f, 0.4f, 1.0f);
        else
            healthBar.transform.FindChild("Mask").transform.FindChild("Image").GetComponent<Image>().color = new Vector4(0.9f, 0.3f, 0.3f, 1.0f);
    }

    public void HealthBarPositionUpdate(Vector3 vUpdatePoint)
    {
        healthBar.transform.position = Camera.main.WorldToScreenPoint(new Vector3(healthBarX + vUpdatePoint.x, healthBarY + vUpdatePoint.y, vUpdatePoint.z));
    }

    public void HealthBarValueUpdate(float fUpdateValue)
    {
        healthBar.GetComponent<Scrollbar>().size = fUpdateValue;
    }

    public void HealthBarDestroy()
    {
        Destroy(healthBar);
    }

    public void CharacterDieEffect()
    {
        ColliderOff();
        CharacterDEAD();
    }

    void CharacterDEAD()
    {
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            //myAllSpriteRenderer[i].color = new Vector4(backupColorR, backupColorG, backupColorB, 0.0f);
            StartCoroutine("CharacterOff", i);
        }
    }

    IEnumerator CharacterOff(int i)
    {
        yield return new WaitForSeconds(DeadDelay);

        SendMessage("HealthBarOff");
        SendMessage("HealthBarDestroy");

        for (float r = 1; r >= 0; r -= 0.05f)
        {
            myAllSpriteRenderer[i].color = new Vector4(backupColorR, backupColorG, backupColorB, r);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }

    public void ColliderOff()
    {
        SendMessage("WeaponColliderOff");
        if (CompareTag("Enemy"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            tag = "Untagged";
        }
    }

    public void CharacterSorting(int iSortValue)
    {
        sortValue = iSortValue;     // 체력 바 

        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            if (myAllSpriteRenderer[i].enabled == true)
            {
                myAllSpriteRenderer[i].sortingOrder = myAllSpriteRenderer[i].sortingOrder + iSortValue * 10;
            }
        }
    }
}