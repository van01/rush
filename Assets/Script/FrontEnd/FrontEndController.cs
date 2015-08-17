using UnityEngine;
using System.Collections;

public class FrontEndController : MonoBehaviour {

    public GameObject[] StageButton;
    public GameObject[] BattlePanel;

    public GameObject CharacterButton;
    public GameObject CharacterPanel;

	// Use this for initialization
	public void SelectStageButton()
    {
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
}
