using UnityEngine;
using System.Collections;

public class FrontEndController : MonoBehaviour {

    public GameObject[] StageButton;
    public GameObject[] BattlePanel;

    public GameObject CharacterButton;
    public GameObject CharacterPanel;

	// Use this for initialization
	public void onClickBattleButton()
    {
        PlayerPrefs.GetInt("currentStage");
        Application.LoadLevel("Stage");
    }

    public void OnClickStageButton(string selfName)
    {
        //Battle 패널 On
        for (int i = 0; i < StageButton.Length; i++)
        {
            if (StageButton[i].name == selfName)
            {
                BattlePanel[i].SetActive(true);
                CurrentBattleSetting(StageButton[i]);
            }
        }
    }

    public void OnClickPanelCloseButton(string parentName)
    {
        //Battle 패널 Off
        for (int i = 0; i < BattlePanel.Length; i++)
        {
            if (BattlePanel[i].name == parentName)
            {
                BattlePanel[i].SetActive(false);
            }
        }
        //Character 패널 Off
        if (CharacterPanel.name == parentName)
            CharacterPanel.SetActive(false);
    }

    public void OnClickCharacterButton()
    {
        CharacterPanel.SetActive(true);
    }

    protected void CurrentBattleSetting(GameObject currentStageButton)
    {
        if (currentStageButton.GetComponent<StageButtonHandler>().currentStage == StageButtonHandler.StageType.DiceForest)
            PlayerPrefs.SetInt("currentStage", 0);
        if (currentStageButton.GetComponent<StageButtonHandler>().currentStage == StageButtonHandler.StageType.Kingdom)
            PlayerPrefs.SetInt("currentStage", 1);
    }
}
