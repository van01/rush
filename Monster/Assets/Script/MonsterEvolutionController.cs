using UnityEngine;
using System.Collections;

public class MonsterEvolutionController : MonoBehaviour {

    public GameObject[] _nextEvolutionMonster;

    protected MonsterParams currentMonsterParams;
    protected MonsterParams nextMonsterParams;
    protected ArrayList nextEveutionCandidateMonster;
    protected bool isEvolutionActiveOn;

    public void NextEvolutionMonsterInitilize()
    {
        _nextEvolutionMonster = GetComponent<MonsterController>().currentMonster.GetComponent<MonsterEvolutionHandler>().nextEvolutionMonster;
        currentMonsterParams = GetComponent<MonsterController>().currentMonster.GetComponent<MonsterAbility>().GetParams();

        nextEveutionCandidateMonster = new ArrayList();
        isEvolutionActiveOn = false;

        //NextEvolutionMonsterCheck();
    }

    public void NextEvolutionMonsterCheck()
    {
        int _candidateMonsterNumber = 0;
        //진화 가능 존재 여부 확인 로직 확인 필요, 진화 조건에 맞지 않는데 진화되는 현상 존재 + minLevel 기능 추가, 동일한 조건일 경우 랜덤 진화
        for (int i = 0; i < _nextEvolutionMonster.Length; i++)
        {
            nextMonsterParams = XMLManager.GetMonsterParamsById(_nextEvolutionMonster[i].GetComponent<MonsterAbility>().monsterDataID);

            if (currentMonsterParams.level >= nextMonsterParams.evolMinLevel)
            {
                if (currentMonsterParams.statPow >= nextMonsterParams.statPow)
                {
                    if (currentMonsterParams.statVit >= nextMonsterParams.statVit)
                    {
                        if (currentMonsterParams.statDex >= nextMonsterParams.statDex)
                        {
                            if (currentMonsterParams.statAgr >= nextMonsterParams.statAgr)
                            {
                                if (currentMonsterParams.statInt >= nextMonsterParams.statInt)
                                {
                                    if (currentMonsterParams.statMal >= nextMonsterParams.statMal)
                                    {
                                        nextEveutionCandidateMonster.Add(i);

                                        isEvolutionActiveOn = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        NextEvolutionMonsterInitialize();
    }

    public void NextEvolutionMonsterInitialize()
    {
        //진화 몬스터 초기화 준비, 실질적인 작업은 monsterController에서 수행
        if (isEvolutionActiveOn == true)
        {
            int _currentNextEvolutionMonsterNumber = 0;

            if (1 < nextEveutionCandidateMonster.Count)
            {
                float _randomValue = Random.RandomRange(0, (float)nextEveutionCandidateMonster.Count);

                _currentNextEvolutionMonsterNumber = (int)nextEveutionCandidateMonster[(int)_randomValue];
            }
            else
                _currentNextEvolutionMonsterNumber = (int)nextEveutionCandidateMonster[0];

            SendMessage("NextEvolutionMonsterNumberSetting", _nextEvolutionMonster[_currentNextEvolutionMonsterNumber].GetComponent<MonsterAbility>().monsterDataID); //state에 id 전달
            print(_nextEvolutionMonster[_currentNextEvolutionMonsterNumber].GetComponent<MonsterAbility>().monsterDataID);

            GetComponent<GameState>().isEvolutionActive = true;
            GetComponent<GameState>().currentState = GameState.State.MonsterEnd;
            SendMessage("CheckGameState");
        }
    }
}
