﻿using UnityEngine;
using System.Collections;

public class HUDHandler : MonoBehaviour {

	public GameObject tmpGameController;

	public GameObject hitZone_L;
	public GameObject hitZone_R;

	void LeftHitZoneTriggerDown(){
		tmpGameController.SendMessage("LeftHitZoneDown");
	}

	void LeftHitZoneTriggerUp(){
		tmpGameController.SendMessage("LeftHitZoneUp");
	}

	void RightHitZoneTriggerDown(){
		tmpGameController.SendMessage("RightHitZoneDown");
	}

	void RightHitZoneTriggerUp(){
		tmpGameController.SendMessage("RightHitZoneUp");
	}

	public void HitZoneDisable(){
		hitZone_L.SetActive(false);
		hitZone_R.SetActive(false);
	}

	public void HitZoneAble(){
		hitZone_L.SetActive(true);
		hitZone_R.SetActive(true);
	}


    //new input System 20150723

    void Left01ButtonDown()
    {
        tmpGameController.SendMessage("Left01Down");
    }

    void Left01ButtonUp()
    {
        tmpGameController.SendMessage("Lef01Up");
    }

    void Left02ButtonDown()
    {
        tmpGameController.SendMessage("Left02Down");
    }

    void Left02ButtonUp()
    {
        tmpGameController.SendMessage("Left02Up");
    }

    void Right01ButtonDown()
    {
        tmpGameController.SendMessage("Right01Down");
    }

    void Right01ButtonUp()
    {
        tmpGameController.SendMessage("Right01Up");
    }

    void Right02ButtonDown()
    {
        tmpGameController.SendMessage("Right02Down");
    }

    void Right02ButtonUp()
    {
        tmpGameController.SendMessage("Right02Up");
    }
}
