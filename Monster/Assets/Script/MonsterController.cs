using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public GameObject _monsterBasket;
    private int _currentUserLevel;
    private int _currentMonsterNumber;

    private GameObject currentMonster;

    public void MonsterInitialize()
    {
        _currentUserLevel = GetComponent<GameController>().currentUserLevel;

        _currentMonsterNumber = 0;        // 사용자 레벨 및 기타 점수에 따라 랜덤으로 현재 생성할 몬스터 Egg 설정

        if (currentMonster == null)
            currentMonster = Instantiate(_monsterBasket.GetComponent<MonsterBasket>().monsterObjectArray[_currentMonsterNumber], transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;

        SendMessage("TimerInitialize");
    }

    public void MonsterEnd()
    {
        Destroy(currentMonster);
    }
}
