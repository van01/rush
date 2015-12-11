using UnityEngine;
using System.Collections;

public class HUDButtonHandler : MonoBehaviour {

    public GameObject disablePanel;

    void Start()
    {
        disablePanel.SetActive(false);
    }

    public void DisableButton()
    {
        disablePanel.SetActive(true);
    }

    public void AbleButton()
    {
        disablePanel.SetActive(false);
    }
}
