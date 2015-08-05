using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {

	public GameObject HUD;

	private float lastClickLeftDownTime = 0;
    private bool DobleClickLeft = false;
    private float lastClickRightDownTime = 0;
	private float catchTime = 0.25f;

    private int clicked = 0;

    public GameObject monsterHitTxtPrefab;
    private GameObject monsterHitTxt;
    private Vector3 monsterHitPoint;


    private GameObject coinHitTxt;
    //public GameObject coinHitTxtPrefab;

    private string nCoinValue;

	public void LeftHitZoneDown(){
        bool dtest = DoubleClick();
        
        clicked++;
        if (clicked == 1) lastClickLeftDownTime = Time.time;
        if (dtest)
        {
            SendMessage("CharacterBattlingOff");
            SendMessage("CharacterBackPredicateOn");
            SendMessage("CharacterAttactDistanceOff");
            DobleClickLeft = true;
        }
        else
        {
            SendMessage("CharacterBattlingOff");
            SendMessage("CharacterGuardPredicateOn");
            DobleClickLeft = false;
        }
        lastClickLeftDownTime = Time.time;        
	}

	public void LeftHitZoneUp(){
        //SendMessage("DeliveryScrollOnTrue");
        if (DobleClickLeft == true)
        {
            //SendMessage("CharacterBattlingOn");
            SendMessage("CharacterBackPredicateOff");
            SendMessage("CharacterAttactDistanceOn");
        }
        else
        {
            //SendMessage("CharacterBattlingOn");
            SendMessage("CharacterGuardPredicateOff");
            SendMessage("CharacterAttactDistanceOn");
        }
        
        DobleClickLeft = false;
	}

	public void RightHitZoneDown(){
        if (Time.time - lastClickRightDownTime < catchTime)
        {
            SendMessage("RunScrollOn");
			SendMessage("CharacterFowardPredicateOn");
		}else{
			SendMessage("RunScrollOn");
			SendMessage("CharacterRunPredicateOn");
		}

        lastClickRightDownTime = Time.time;

	}

	public void RightHitZoneUp(){
		//SendMessage("RunScrollOff");
		SendMessage("CharacterRunPredicateOff");
		SendMessage("CharacterFowardPredicateOff");
	}


    //new input System :::: Button Type __ 20150723
    public void Left01Down()
    {
        //SendMessage("CharacterBattlingOff");
        SendMessage("CharacterBackPredicateOn");
        SendMessage("CharacterAttactDistanceOff");
    }

    public void Lef01Up()
    {
        //SendMessage("CharacterBattlingOn");
        SendMessage("CharacterBackPredicateOff");
        SendMessage("CharacterAttactDistanceOn");
    }

    public void Left02Down()
    {
		//Run On
		SendMessage("RunScrollOn");
		SendMessage("CharacterRunPredicateOn");
        
    }

    public void Left02Up()
    {
		//Run Off
		SendMessage("CharacterRunPredicateOff");
		SendMessage("CharacterFowardPredicateOff");

    }

    public void Right01Down()
    {
        //Guard On
        SendMessage("CharacterGuardPredicateOn");
        SendMessage("CharacterBattlingOff");
    }

    public void Right01Up()
    {
		//Guard Off
		//SendMessage("CharacterBattlingOn");
		SendMessage("CharacterGuardPredicateOff");
		SendMessage("CharacterAttactDistanceOn");
    }

    public void Right02Down()
    {
		//Foward On
		SendMessage("CharacterFowardPredicateOn");

    }

    public void Right02Up()
    {
		//Foward Off
		SendMessage("CharacterRunPredicateOff");
		SendMessage("CharacterFowardPredicateOff");

    }





	public void HitZoneOff(){
		HUD.SendMessage("HitZoneDisable");
	}

	public void HitZoneOn(){
		HUD.SendMessage("HitZoneAble");
	}

	public void TestMonsterDestroy(){
		GameObject tmpPlayer;
		GameObject target;

		tmpPlayer = GameObject.Find ("Pawn");

		target = tmpPlayer.GetComponent<PlayerAI>().GetCurrentTarget();

		Destroy(target);
	}


    bool DoubleClick() {
        if (clicked > 1 && Time.time - lastClickLeftDownTime < catchTime)
        {
            clicked = 0;
            lastClickLeftDownTime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - lastClickLeftDownTime > 1) clicked = 0;
        return false;
    }



    public void MonsterHitDamage(int nDamage)
    {
        monsterHitTxt = Instantiate(monsterHitTxtPrefab, monsterHitPoint, HUD.transform.rotation) as GameObject;
        monsterHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
        monsterHitTxt.transform.localScale = new Vector3(1, 1, 1);
        monsterHitTxt.GetComponent<Text>().text = nDamage.ToString();
        monsterHitTxt.SendMessage("HitTypeSetting", "Enemy");
    }

    public void PlayerHitDamage(int nDamage)
    {
        monsterHitTxt = Instantiate(monsterHitTxtPrefab, monsterHitPoint, HUD.transform.rotation) as GameObject;
        monsterHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
        monsterHitTxt.transform.localScale = new Vector3(1, 1, 1);
        monsterHitTxt.GetComponent<Text>().text = nDamage.ToString();
        monsterHitTxt.SendMessage("HitTypeSetting", "Player");
    }

    public void CoinHitValue(Vector3 nCoinPosition)
    {
        coinHitTxt = Instantiate(monsterHitTxtPrefab, nCoinPosition, gameObject.transform.rotation) as GameObject;
        coinHitTxt.GetComponent<RectTransform>().SetParent(HUD.transform);
        coinHitTxt.GetComponent<Text>().text = "+" + nCoinValue;
        coinHitTxt.SendMessage("HitTypeSetting", "Coin");
    }

    public void CoinValueSetting(int nSettingCoinValue)
    {
        nCoinValue = nSettingCoinValue.ToString();
    }

    public void HitPositionSetting(Vector3 vHitPoint)
    {
        monsterHitPoint = vHitPoint;
    }

    public void SelectPauseButton()
    {
        Application.LoadLevel("FrontEnd");
    }

}
