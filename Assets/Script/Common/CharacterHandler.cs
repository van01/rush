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
    private float hitColorA = 0f;

    private float backupColorR;
    private float backupColorG;
    private float backupColorB;

    private float hittingPosition = 0.05f;   //아군 AI 문제로 0.0 적용
    private float totalhittingPosition;
    private float backupPosition;

    public GameObject healthBarPrefab;
    private GameObject healthBar;
    private Vector3 healthBarPoint;

    private GameObject tmpHUD;

    public float DeadDelay = 0.7f;

    private int sortValue;

    public int assaultWeightValue;
    public bool assaultAddforce;    // 스킬 및 가드 적용 시 사용
    public string assaultName;

    private bool characterAddPositionOn = false;

    protected int attackValueX;
    protected int attackValueY;

    private bool HealthBarInitOn = true;

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
            hitColorA = 1.0f;
            hittingPosition = hittingPosition * -1;
        }

        if (gameObject.CompareTag("Enemy"))
        {
            hitColorR = 0f;
            hitColorG = 0f;
            hitColorB = 0f;
            hitColorA = 1.0f;
        }


        float healthBarInitX = healthBarX + transform.position.x;
        float healthBarInitY = healthBarY + transform.position.y;

        HelthBarInitPositionSetting(new Vector3(healthBarInitX, healthBarInitY, 0));
	}

    void Start()
    {
        if (HealthBarInitOn == true)
            HelthBarInitialize();
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
        //타격 시 멈추기
        //SendMessage("AnimationStop");     //해당 기능의 경우 Animator -> Animation 전환 과정에서 무의미해짐 (타격 타이밍 조정), 다시 구축해야 함

        //타격 시 색깔 바꾸기
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].color = new Vector4(hitColorR, hitColorG, hitColorB, hitColorA);
        }

        StartCoroutine("CharacterHitOff");
    }

    public void CharacterAddPosition()
    {
        //타격 시 위치 바꾸기
        if (characterAddPositionOn != true)
        {
            backupPosition = transform.position.x;
            totalhittingPosition = hittingPosition + backupPosition;
            transform.position = new Vector3(totalhittingPosition, transform.position.y, transform.position.z);
            characterAddPositionOn = true;
        }
    }

    public void CharacterAddForce()
    {
        //타격 시 밀어내기
        int i = 1;
        
        if (tag == "Player")
            i = -1;

        float rForceX = (attackValueX - assaultWeightValue) * 8;
        float rForceY = (attackValueY - assaultWeightValue) * 5;

        rForceX = Random.RandomRange(rForceX - 2, rForceX + 2);
        rForceY = Random.RandomRange(rForceY - 2, rForceY + 2);

        if (rForceX >= 20.0f)
            rForceX = 20.0f;
        else if (rForceX <= 0f)
            rForceX = 1.0f;
        if (rForceY >= 20.0f)
            rForceY = 20.0f;
        else if (rForceY <= 0f)
            rForceY = 1.0f;

        GetComponent<Rigidbody2D>().AddForce(new Vector2(rForceX * i, rForceY * i), ForceMode2D.Impulse);
    }

    IEnumerator CharacterHitOff()
    {
        yield return new WaitForSeconds(colorDisableDelay);
        if (characterAddPositionOn == true)
        {
            transform.position = new Vector3(backupPosition, transform.position.y, transform.position.z);
            characterAddPositionOn = false;
        }

        //SendMessage("AnimationPlay");     //해당 기능의 경우 Animator -> Animation 전환 과정에서 무의미해짐 (타격 타이밍 조정), 다시 구축해야 함

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
        GetComponent<BoxCollider2D>().enabled = false;
        tag = "Untagged";
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

    public void AssaultAddforceOn(string aName)
    {
        assaultAddforce = true;
        assaultName = aName;
    }

    public void AssaultAddforceOff()
    {
        assaultAddforce = false;
    }

    public void attackValueXSetting(int aValueX)
    {
        attackValueX = aValueX;
    }

    public void attackValueYSetting(int aValueY)
    {
        attackValueY = aValueY;
    }

    public void HealthBarInitOff()
    {
        HealthBarInitOn = false;

        Destroy(healthBar);
    }

    /// <summary>
    /// Lapick ~ Rushing to Witch ~
    /// </summary>
    public void RWJumpAddforce()
    {
        //점프
        float rForceY = 20.0f;

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, rForceY), ForceMode2D.Impulse);
    }
}