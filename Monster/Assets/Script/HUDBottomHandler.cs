using UnityEngine;
using System.Collections;

public class HUDBottomHandler : MonoBehaviour {

    public GameObject homePanel;
    public GameObject dishPanel;
    public GameObject trainingPanel;
    public GameObject adventurePanel;
    public GameObject breakPanel;

    private int currentPanelNumber;

    void Start()
    {
        HomeButtonActive();
    }

    public void HomeButtonActive()
    {
        homePanel.SetActive(true);
        dishPanel.SetActive(false);
        trainingPanel.SetActive(false);
        adventurePanel.SetActive(false);
        breakPanel.SetActive(false);

        currentPanelNumber = 0;

        MonsterInfoInitialIzeRefresh();
    }

    public void DishButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(true);
        trainingPanel.SetActive(false);
        adventurePanel.SetActive(false);
        breakPanel.SetActive(false);

        currentPanelNumber = 1;
    }

    public void TrainingButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(false);
        trainingPanel.SetActive(true);
        adventurePanel.SetActive(false);
        breakPanel.SetActive(false);

        currentPanelNumber = 2;
    }

    public void AdventureButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(false);
        trainingPanel.SetActive(false);
        adventurePanel.SetActive(true);
        breakPanel.SetActive(false);

        currentPanelNumber = 3;
    }

    public void BreakButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(false);
        trainingPanel.SetActive(false);
        adventurePanel.SetActive(false);
        breakPanel.SetActive(true);

        currentPanelNumber = 4;
    }

    public void MonsterInfoInitialIzeRefresh()
    {
        if (currentPanelNumber == 0)
            homePanel.SendMessage("MonsterInfoInitialIze");
    }
}
