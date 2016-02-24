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
        //진화 가능 존재 여부 확인 로직 확인 필요, 진화 조건에 맞지 않는데 진화되는 현상 존재 + minLevel 기능 추가, 동일한 조건일 경우 랜덤 진화
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
