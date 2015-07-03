using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

    public float colorDisableDelay = 0.1f;

	private GameObject tmpGameController;
    private SpriteRenderer[] myAllSpriteRenderer;

    private float hitColorR = 1.0f;
    private float hitColorG = 0f;
    private float hitColorB = 0f;

    private float bacupColorR;
    private float bacupColorG;
    private float bacupColorB;

	void Start(){
		tmpGameController = GameObject.Find("GameController");
        myAllSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();

        if (gameObject.CompareTag("Player"))
        {
            hitColorR = 1.0f;
            hitColorG = 0.3f;
            hitColorB = 0.3f;
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
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            bacupColorR = myAllSpriteRenderer[i].color.r;
            bacupColorG = myAllSpriteRenderer[i].color.g;
            bacupColorB = myAllSpriteRenderer[i].color.b;

            myAllSpriteRenderer[i].color = new Vector4(hitColorR, hitColorG, hitColorB, 1.0f);
        }

        StartCoroutine("CharacterHitOff");
    }

    IEnumerator CharacterHitOff()
    {
        yield return new WaitForSeconds(colorDisableDelay);

        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].color = new Vector4(bacupColorR, bacupColorG, bacupColorB, 1.0f);
        }
    }
}