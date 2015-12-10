using UnityEngine;
using System.Collections;

public class MonsterEvolutionHandler : MonoBehaviour {

    public GameObject[] nextEvolutionMonster;

    protected MonsterParams currentMonsterParams;
    protected MonsterParams nextMonsterParams;

    private int nextEvolutionCheckCount;

    void Start()
    {
        currentMonsterParams = GetComponent<MonsterAbility>().GetParams();
    }

    public void NextEvolutionMonsterCheck()
    {
        for (int i = 0; i < nextEvolutionMonster.Length; i++)
        {
            nextMonsterParams = XMLManager.GetMonsterParamsById(nextEvolutionMonster[i].GetComponent<MonsterAbility>().monsterDataID);

            if (currentMonsterParams.statPow >= nextMonsterParams.statPow)
                nextEvolutionCheckCount++;
            if (currentMonsterParams.statVit >= nextMonsterParams.statVit)
                nextEvolutionCheckCount++;
            if (currentMonsterParams.statDex >= nextMonsterParams.statDex)
                nextEvolutionCheckCount++;
            if (currentMonsterParams.statAgr >= nextMonsterParams.statAgr)
                nextEvolutionCheckCount++;
            if (currentMonsterParams.statInt >= nextMonsterParams.statInt)
                nextEvolutionCheckCount++;
            if (currentMonsterParams.statMal >= nextMonsterParams.statMal)
                nextEvolutionCheckCount++;

            if (nextEvolutionCheckCount >= 6)
            {
                transform.root.GetComponent<MonsterBasket>().tmpGameController.SendMessage("NextEvolutionMonsterNumberSetting", nextEvolutionMonster[i].GetComponent<MonsterAbility>().monsterDataID); //state에 id 전달

                transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().currentState = GameState.State.MonsterEnd;
                transform.root.GetComponent<MonsterBasket>().tmpGameController.SendMessage("CheckGameState");
            }
        }
    }
}
