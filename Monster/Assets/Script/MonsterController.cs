using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public GameObject _monsterBasket;

    private int _currentUserLevel;

    public GameObject currentMonster;

    private int monsterAttributeNumber;
    private Vector4 monsterApplyColor;

    private MonsterParams currentMonsterParams;
    private MonsterState.Condition prevCondition;

    public void MonsterInitialize(int _currentMonsterNumber)
    {
        _currentUserLevel = GetComponent<GameController>().currentUserLevel;

        Destroy(currentMonster);
        currentMonsterParams = null;

        MonsterAttributeRandom();

        currentMonster = Instantiate(_monsterBasket.GetComponent<MonsterBasket>().monsterObjectArray[_currentMonsterNumber], transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        currentMonster.transform.SetParent(_monsterBasket.transform);

        MonsterParams pParams = XMLManager.GetMonsterParamsById(currentMonster.GetComponent<MonsterAbility>().monsterDataID);
        currentMonster.SendMessage("SetParams", pParams);

        currentMonster.SendMessage("MonsterSpriteColorApplyDelivery", monsterApplyColor);

        currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.Spawn;
        currentMonster.GetComponent<MonsterState>().CheckMonsterState();

        currentMonster.GetComponent<MonsterState>().currentCondition = MonsterState.Condition.Happy;

        currentMonsterParams = currentMonster.GetComponent<MonsterAbility>().GetParams();

        SendMessage("TimerInitialize");

        //if (GetComponent<GameState>().currentState == GameState.State.MonsterEnd)
        //{
        //    GetComponent<GameState>().currentState = GameState.State.Monster;
        //    GetComponent<GameState>().CheckGameState();
        //}
    }

    public void MonsterEnd()
    {
        Destroy(currentMonster);
    }

    void MonsterAttributeRandom()
    {
        monsterAttributeNumber = (int)Random.RandomRange(0, 5);

        switch (monsterAttributeNumber)
        {
            case 0:
                monsterApplyColor = new Vector4(0.98f, 0.78f, 0.43f, 1.0f);
                break;
            case 1:
                monsterApplyColor = new Vector4(1.0f, 0.78f, 0.95f, 1.0f);
                break;
            case 2:
                monsterApplyColor = new Vector4(0.54f, 0.98f, 0.52f, 1.0f);
                break;
            case 3:
                monsterApplyColor = new Vector4(0.66f, 0.82f, 1.0f, 1.0f);
                break;
            case 4:
                monsterApplyColor = new Vector4(0.76f, 1.0f, 0.82f, 1.0f);
                break;
        }
    }

    void Update()
    {
        if (currentMonster != null)
        {
            if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.2f)
                CurrentMonsterAutoConditionChange(MonsterState.Condition.Bad);
            else if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.4f)
                CurrentMonsterAutoConditionChange(MonsterState.Condition.NotBad);
            else if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.6f)
                CurrentMonsterAutoConditionChange(MonsterState.Condition.Normal);
            else if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.8f)
                CurrentMonsterAutoConditionChange(MonsterState.Condition.Good);
            else
                CurrentMonsterAutoConditionChange(MonsterState.Condition.Happy);
        }
    }

    void CurrentMonsterAutoConditionChange(MonsterState.Condition nCondition)
    {
        currentMonster.GetComponent<MonsterState>().currentCondition = nCondition;
        if (prevCondition != nCondition)
        {
            currentMonster.GetComponent<MonsterState>().CheckMonsterCondition();
            prevCondition = nCondition;
        }
    }

    public void MonsterScoutSuccess()
    {
        Destroy(currentMonster);

        GetComponent<GameState>().currentState = GameState.State.StandBy;
        GetComponent<GameState>().CheckGameState();
        //임시, 스카우트 연출 추가 및 재화 증가 처리 필요
    }

    public void MonsterHidePosition()
    {
        _monsterBasket.transform.position = new Vector3(-10.0f, -10.0f, 0);
    }

    public void MonsterRestorePosition()
    {
        _monsterBasket.transform.position = new Vector3(0, 0, 0);
    }
}
