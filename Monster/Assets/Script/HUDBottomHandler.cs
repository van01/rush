using UnityEngine;
using System.Collections;

public class HUDBottomHandler : MonoBehaviour {

    public GameObject homePanel;
    public GameObject dishPanel;
    public GameObject trainingPanel;
    public GameObject adventurePanel;
    public GameObject breakPanel;
    public GameObject infoPanel;

    public GameObject menuPanel;

    private int currentPanelNumber;

    void Start()
    {   //small on/off에 따라 
        HomeButtonActive();
    }

    public void HomeButtonActive()
    {
        if (transform.root.GetComponent<HUDHandler>().isCurrentBottomPanel == true)
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
        }
        else
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
            currentPanelNumber = 0;
        }

        MonsterInfoInitialIzeRefresh();
    }

    public void DishButtonActive()
    {
        if (transform.root.GetComponent<HUDHandler>().isCurrentBottomPanel == true)
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(true);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
        }
        else
        {
            homePanel.SetActive(false);
            dishPanel.SetActive(true);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
            currentPanelNumber = 1;
        }       
    }

    public void TrainingButtonActive()
    {
        if (transform.root.GetComponent<HUDHandler>().isCurrentBottomPanel == true)
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(true);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
        }
        else
        {
            homePanel.SetActive(false);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(true);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
            currentPanelNumber = 2;
        }
    }

    public void AdventureButtonActive()
    {
        if (transform.root.GetComponent<HUDHandler>().isCurrentBottomPanel == true)
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(true);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
        }
        else
        {
            homePanel.SetActive(false);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(true);
            breakPanel.SetActive(false);
            infoPanel.SetActive(false);
            currentPanelNumber = 3;
        }
    }

    public void BreakButtonActive()
    {
        if (transform.root.GetComponent<HUDHandler>().isCurrentBottomPanel == true)
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(true);
            infoPanel.SetActive(false);
        }
        else
        {
            homePanel.SetActive(false);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(true);
            infoPanel.SetActive(false);
            currentPanelNumber = 4;
        }
    }

    public void InfoButtonActive()
    {
        if (transform.root.GetComponent<HUDHandler>().isCurrentBottomPanel == true)
        {
            homePanel.SetActive(true);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(true);
        }
        else
        {
            homePanel.SetActive(false);
            dishPanel.SetActive(false);
            trainingPanel.SetActive(false);
            adventurePanel.SetActive(false);
            breakPanel.SetActive(false);
            infoPanel.SetActive(true);
            currentPanelNumber = 5;
        }
    }

    public void MonsterInfoInitialIzeRefresh()
    {
        if (currentPanelNumber == 0)
            //if (transform.root.GetComponent<HUDHandler>().tmpGameController.GetComponent<MonsterController>().currentMonster != null)
            homePanel.SendMessage("MonsterInfoInitialIze");
    }
}
