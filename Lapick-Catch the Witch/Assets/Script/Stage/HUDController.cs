using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {

	public GameObject HUD;

    public string[] alertMessage;

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

    protected bool skillOn = false;

    protected string blockCount;

    //private string alertMessage;

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
            SendMessage("CharacterDownPredicateOn");
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
			SendMessage("CharacterDownPredicateOn");
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
        SendMessage("CharacterDownPredicateOn");
        SendMessage("CharacterAttactDistanceOff");
        SendMessage("DeliveryScrollOnFalse");
    }

    public void Lef01Up()
    {
        //SendMessage("CharacterBattlingOn");
        SendMessage("CharacterDownPredicateOff");
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
		//SendMessage("CharacterFowardPredicateOff");   //20150917 newInputsystem Test

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
        if (skillOn == true)
            monsterHitTxt.SendMessage("AttackTypeSetting", "Skill");
        else
            monsterHitTxt.SendMessage("AttackTypeSetting", "Normal");
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
        coinHitTxt.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
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

    public void ActiveSkillOn()
    {
        skillOn = true;
    }

    public void ActiveSkillOff()
    {
        skillOn = false;
    }


    //20150924 new input system joystick
    public void JoyStickNeutral()
    {
        SendMessage("PlyaerCharacterControllStateOff");
        SendMessage("CharacterRunPredicateOff");
    }

    public void JoyStickRight()
    {
        SendMessage("PlyaerCharacterControllStateOn");
        SendMessage("CharacterRunPredicateOn");
    }

    public void JoyStickRightDown()
    {
        SendMessage("PlyaerCharacterControllStateOn");
        SendMessage("CharacterDownMovePredicateOn");
    }

    public void JoyStickLeftDown()
    {
        SendMessage("PlyaerCharacterControllStateOn");
        SendMessage("CharacterDownBackPredicateOn");
    }

    public void JoyStickDown()
    {
        SendMessage("PlyaerCharacterControllStateOn");
        SendMessage("CharacterDownPredicateOn");
    }

    public void JoyStickLeft()
    {
        SendMessage("PlyaerCharacterControllStateOn");
        SendMessage("CharacterBackPredicateOn");
    }


    public void RWModeUISetting()
    {
        HUD.SendMessage("HUDBattleUIOff");

        HUD.SendMessage("HUDPlayingUIoff");
        HUD.SendMessage("HUDRWPlayingUIoff");
        HUD.SendMessage("HUDRWGameOverUIoff");
    }

    public void BattleModeUISetting()
    {
        HUD.SendMessage("HUDBattleUIOn");
    }

    public void RWReadyModeUISetting()
    {
        HUD.SendMessage("HUDRWLobbyUIOff");
        HUD.SendMessage("HUDRWReadyUIOn");
    }

    public void RWPlayingModeUISetting()
    {
        HUD.SendMessage("HUDRWReadyUIOff");
        HUD.SendMessage("HUDPlayingUIon");
        HUD.SendMessage("HUDRWPlayingUIon");
    }

    public void RWGameOverModeUISetting()
    {
        HUD.SendMessage("HUDPlayingUIoff");
        HUD.SendMessage("HUDRWPlayingUIoff");

        HUD.SendMessage("HUDRWGameOverUIon");
    }

    public void BlockCounterRefreshDelivery(string nCoinCount)
    {
        blockCount = nCoinCount;
        HUD.SendMessage("BlockCounterRefresh", blockCount);
    }

    public void RWGamePauseOnUISetting()
    {
        HUD.SendMessage("HUDRWPaueseUIon");

        HUD.SendMessage("HUDPlayingUIoff");
        HUD.SendMessage("HUDRWPlayingUIoff");

        SendMessage("PauseOn");
    }

    public void RWGamePauseOffUISetting()
    {
        HUD.SendMessage("HUDRWPaueseUIoff");

        HUD.SendMessage("HUDPlayingUIon");
        HUD.SendMessage("HUDRWPlayingUIon");

        SendMessage("PauseOff");
    }

    public void RWGameGiveUpUISetting()
    {
        HUD.SendMessage("HUDRWPaueseUIoff");

        SendMessage("DeliveryScrollOnFalse");
        SendMessage("PauseOff");
    }

    public void RWGameExitUISetting()
    {
        HUD.SendMessage("HUDHUDRWExitPopupon");

        SendMessage("PauseOn");
    }

    public void RWGameExitUICancel()
    {
        HUD.SendMessage("HUDHUDRWExitPopupoff");

        SendMessage("PauseOff");
    }

    public void RWHelmetUISetting()
    {
        HUD.SendMessage("HUDRWHelmetUIon");

        //SendMessage("PauseOn");
    }
    public void RWHelmetUICancel()
    {
        HUD.SendMessage("HUDRWHelmetUIoff");

        //SendMessage("PauseOff");
    }

    public void RWRaffleUISetting()
    {
        HUD.SendMessage("HUDRWHelmetRaffleUIon");
    }

    public void RWRaffleUICancel()
    {
        HUD.SendMessage("HUDRWHelmetRaffleUIoff");
    }


    public void CounCounterRefreshDelivery(int nCoinCount)
    {
        HUD.SendMessage("CoinCounterRefresh", nCoinCount);
    }

    public void CurrentGameCoinTotalDelivery(int nCoinCount)
    {
        HUD.SendMessage("CurrentGameCoinTotalViewer", nCoinCount);
    }

    public void CurrentGameBlockCountTotalDelivery(int nBlockCount)
    {
        HUD.SendMessage("CurrentGameBlockCountTotalViewer", nBlockCount);
    }

    public void BestBlockCountTotalDelivery(int nBlockCount)
    {
        HUD.SendMessage("BestBlockCountTotalViewer", nBlockCount);
    }

    public void AlertPanelSetting(int nAlertType)
    {      
        HUD.SendMessage("AlertPanelon");
        HUD.SendMessage("AlertPanelTextSetting", alertMessage[nAlertType]);
    }

    public void OpeningSkipPanelOffDelivery()
    {
        HUD.SendMessage("OpeningSkipPanelOff");
    }

    public void OpeningSkipInitializeDelivery()
    {
        HUD.SendMessage("OpeningSkipInitialize");
    }

    public void NewRecordSuccess()
    {
        HUD.SendMessage("NewRecordTitleOnDelivery");
    }

}
