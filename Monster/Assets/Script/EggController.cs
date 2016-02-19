using UnityEngine;
using System.Collections;

public class EggController : MonoBehaviour {

    public GameObject _eggBasket;
    private int _currentUserLevel;
    private int _currentEggNumber;

    public GameObject currentEgg;

    public void EggInitialize(int nCurrentEggNumber)
    {
        _currentUserLevel = GetComponent<GameController>().currentUserLevel;

        _currentEggNumber = nCurrentEggNumber;

        currentEgg = Instantiate(_eggBasket.GetComponent<EggBasket>().eggObjectArray[_currentEggNumber], _eggBasket.transform.position, _eggBasket.transform.rotation) as GameObject;
        currentEgg.transform.SetParent(_eggBasket.transform);

        EggParams pParams = XMLManager.GetEggParamsById(nCurrentEggNumber);
        currentEgg.SendMessage("SetParams", pParams);

        SendMessage("TimerInitialize");

        GetComponent<GameState>().currentState = GameState.State.Egg;       //임시
        GetComponent<GameState>().CheckGameState();

        SendMessage("EggPanelAutoClose");   //current Egg 생성 시 자동으로 팝업창 닫기
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
