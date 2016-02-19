using UnityEngine;
using System.Collections;

public class HUDMenuButtonHandler : MonoBehaviour {

    public GameObject homeButton;
    public GameObject dishButton;
    public GameObject trainingButton;
    public GameObject adventureButton;
    public GameObject breakButton;

    public void AllButtonDisable()
    {
        dishButton.SendMessage("DisableButton");
        trainingButton.SendMessage("DisableButton");
        //adventureButton.SendMessage("DisableButton");
        //breakButton.SendMessage("DisableButton");
    }

    public void AllButtonAble()
    {
        dishButton.SendMessage("AbleButton");
        trainingButton.SendMessage("AbleButton");
        //adventureButton.SendMessage("AbleButton");
        //breakButton.SendMessage("AbleButton");
    }
}
