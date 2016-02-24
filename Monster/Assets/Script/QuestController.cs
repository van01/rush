using UnityEngine;
using System.Collections;

public class QuestController : MonoBehaviour {

    public GameObject _questBasket;

    public bool isQuestMonster;

    public void QuestMonsterOn()
    {
        isQuestMonster = true;
    }

    public void QuestMonsterOff()
    {
        isQuestMonster = false;
    }
}
