using UnityEngine;
using System.Collections;

public class DishController : MonoBehaviour
{

    private GameObject currentMonster;

    public void Monster00Dish()
    {
        DishInitialize();
        currentMonster.SendMessage("ChargeHunger", 50.0f);
    }

    public void DishInitialize()
    {
        currentMonster = GetComponent<MonsterController>().currentMonster;

        SendMessage("HUDInitializeDelivery");
    }
}
