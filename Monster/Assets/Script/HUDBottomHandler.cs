using UnityEngine;
using System.Collections;

public class HUDBottomHandler : MonoBehaviour {

    public GameObject homePanel;
    public GameObject dishPanel;
    public GameObject playPanel;
    public GameObject workPanel;
    public GameObject AdventurePanel;

    void Start()
    {
        HomeButtonActive();
    }

    public void HomeButtonActive()
    {
        homePanel.SetActive(true);
        dishPanel.SetActive(false);
        playPanel.SetActive(false);
        workPanel.SetActive(false);
        AdventurePanel.SetActive(false);
    }

    public void DishButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(true);
        playPanel.SetActive(false);
        workPanel.SetActive(false);
        AdventurePanel.SetActive(false);
    }

    public void PlayButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(false);
        playPanel.SetActive(true);
        workPanel.SetActive(false);
        AdventurePanel.SetActive(false);
    }

    public void WorkButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(false);
        playPanel.SetActive(false);
        workPanel.SetActive(true);
        AdventurePanel.SetActive(false);
    }

    public void AdventureButtonActive()
    {
        homePanel.SetActive(false);
        dishPanel.SetActive(false);
        playPanel.SetActive(false);
        workPanel.SetActive(false);
        AdventurePanel.SetActive(true);
    }
}
