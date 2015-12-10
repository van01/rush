using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {

    public GameObject _eggBasket;
    private int _currentUserLevel;
    private int _currentEggNumber;

    public GameObject currentEgg;

    public void EggInitialize()
    {
        _currentUserLevel = GetComponent<GameController>().currentUserLevel;

        _currentEggNumber = 0;        // 사용자 레벨 및 기타 점수에 따라 랜덤으로 현재 생성할 몬스터 Egg 설정

        currentEgg = Instantiate(_eggBasket.GetComponent<EggBasket>().eggObjectArray[_currentEggNumber], _eggBasket.transform.position, _eggBasket.transform.rotation) as GameObject;
        currentEgg.transform.SetParent(_eggBasket.transform);

        EggParams pParams = XMLManager.GetEggParamsById(0);
        currentEgg.SendMessage("SetParams", pParams);

        SendMessage("TimerInitialize");
    }

    public void EggEnd()
    {
        currentEgg.SendMessage("CurrentEggEndDelivery");
    }

    public void CurrentEggDestroy()
    {
        Destroy(currentEgg);

        GetComponent<GameState>().currentState = GameState.State.Monster;
        GetComponent<GameState>().CheckGameState();
    }
}
