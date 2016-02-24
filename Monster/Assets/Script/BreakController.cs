using UnityEngine;
using System.Collections;

public class BreakController : MonoBehaviour {

    private GameObject currentMonster;

    public void MonsterSleep()
    {
        BreakeInitialize();
        currentMonster.SendMessage("ChangeFatigue", -75.0f);
    }

    public void BreakeInitialize()
    {
        currentMonster = GetComponent<MonsterController>().currentMonster;

        SendMessage("HUDInitializeDelivery");
    }
}
