using UnityEngine;
using System.Collections;

public class DishController : MonoBehaviour
{

    private GameObject currentMonster;

    public void Monster00Dish()
    {
        DishInitialize();
        currentMonster.SendMessage("ChangeHunger", 30.0f);
    }

    public void DishInitialize()
    {
        currentMonster = GetComponent<MonsterController>().currentMonster;

        SendMessage("HUDInitializeDelivery");
    }
}
