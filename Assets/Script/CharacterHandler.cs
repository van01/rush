using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

    public float colorDisableDelay = 0.1f;

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

	void Start(){
		tmpGameController = GameObject.Find("GameController");
        myAllSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();

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
            backupColorR = myAllSpriteRenderer[i].color.r;
            backupColorG = myAllSpriteRenderer[i].color.g;
            backupColorB = myAllSpriteRenderer[i].color.b;

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

            /*
            for (float r = hitColorR; r <= backupColorR; r += 0.05f)
            {
                for (float g = hitColorG; g <= backupColorG; g += 0.05f)
                {
                    for (float b = hitColorB; b <= backupColorB; b += 0.05f)
                    {
                        myAllSpriteRenderer[i].color = new Vector4(r, g, b, 1.0f);
                    }
                }
            }
                */
        }
    }

    public void hittingPositionValueSetting(float i)
    {
        hittingPosition = i;
    }
}