using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private GameObject[] tmpMonsters;

    void Awake()
    {
        tmpMonsters = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Start()
    {
        EnemyCharacterSorting();
    }

    public void EnemyStateBattleInfection(int nBaseGroupValue)
    {
        tmpMonsters = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < tmpMonsters.Length; i++)
        {
            if (nBaseGroupValue == tmpMonsters[i].GetComponent<EnemyAI>().groupValue)
            {
                if (tmpMonsters[i].GetComponent<EnemyState>().currentState == CharacterState.State.Battle)
                {
                    tmpMonsters[i].gameObject.SendMessage("ChasePlayer");
                }
            }
        }
    }

    void EnemyCharacterSorting()
    {
        for (int i = 1; i < tmpMonsters.Length; i++)
        {
            tmpMonsters[i].gameObject.SendMessage("CharacterSorting", i);
        }
    }
}
