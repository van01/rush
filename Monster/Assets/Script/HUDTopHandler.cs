using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDTopHandler : MonoBehaviour {

    public GameObject currentDayTxt;
    public GameObject questGoalPanel;
    public GameObject questLeftDayTxt;

    public GameObject currentGoldTxt;
    public GameObject currentRubyTxt;

    private GameObject tmpGameController;

    void Start()
    {
        tmpGameController = transform.root.GetComponent<HUDHandler>().tmpGameController;
    }

    public void TopPanelInfoInitilize()
    {
        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.StandBy)
        {
            CurrentDayRefresh("-");
            questGoalPanel.SetActive(false);

            //재화 변화 시 해당 함수 호출
            CurrentGoldRefresh();
            CurrentRubyRefresh();
        }
    }

    public void CurrentDayRefresh(string nCurrentDay)
    {
        currentDayTxt.GetComponent<Text>().text = nCurrentDay;
    }

    public void CurrentGoldRefresh()
    {
        //PlayerPrefab에서 직접 접근해 출력
        currentGoldTxt.GetComponent<Text>().text = "";
    }

    public void CurrentRubyRefresh()
    {
        //PlayerPrefab에서 직접 접근해 출력
        currentRubyTxt.GetComponent<Text>().text = "";
    }
}
