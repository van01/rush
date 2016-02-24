using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDQuestMenuButtonHandler : MonoBehaviour {

    public GameObject questNameTxt;
    public GameObject questButtonDescTxt;

    private int currentQuestNumber;

    public void QuestMenuButtonInitialize(int nQuestNumber)
    {
        GetComponent<Button>().onClick.AddListener(delegate { QuestButtonCall(); });

        currentQuestNumber = nQuestNumber;
    }

    void QuestButtonCall()
    {
        transform.root.SendMessage("QuestDramaticPanelOn", currentQuestNumber);
        //print("Quest Menu Button Call :: " + currentQuestNumber);
    }
}
