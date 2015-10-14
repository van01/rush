using UnityEngine;
using System.Collections;

public class RWCharacterPanelHandler : MonoBehaviour {
    public GameObject[] CharacterSelectButton;
    public GameObject tmpGameController;

    private string[] ActivePlayerCharacter;

    void Start()
    {
        ActivePlayerCharacter = new string[CharacterSelectButton.Length];
        ButtonInit(PlayerPrefs.GetInt("PlayerCharacterNumber"));

        CharacterActiveStringArrayInit();
        CharacterNumberSettingDelivery();
        testLockButton();
    }

    public void CharacterButtonSelect(string sButtonName)
    {
        for (int i = 0; i < CharacterSelectButton.Length; i++)
        {
            if (CharacterSelectButton[i].name == sButtonName)
                CharacterSelectButton[i].SendMessage("SelectImageOn");
            else
                CharacterSelectButton[i].SendMessage("SelectImageOff");
        }
    }

    public void CharacterNumberDelivery(int nCharacterNumber)
    {
        tmpGameController.SendMessage("RWPlayerCHaracterSetting", nCharacterNumber);
    }

    void ButtonInit(int nCharacterNumber)
    {
        for (int i = 0; i < CharacterSelectButton.Length; i++)
        {
            if (i == nCharacterNumber)
                CharacterSelectButton[i].SendMessage("SelectImageOn");
            else
                CharacterSelectButton[i].SendMessage("SelectImageOff");
        }
    }

    void CharacterActiveStringArrayInit()
    {
        for (int i = 0; i < ActivePlayerCharacter.Length; i++)
        {
            ActivePlayerCharacter[i] = "ActivePlayerCharacter" + i;

            if (PlayerPrefs.GetInt(ActivePlayerCharacter[i]) == 1)
            {
                CharacterSelectButton[i].SendMessage("CharacterSelectButtonUnLock");
            }
        }
    }

    void CharacterNumberSettingDelivery()
    {
        for (int i = 0; i < CharacterSelectButton.Length; i++)
        {
            CharacterSelectButton[i].SendMessage("CharacterNumberSetting", i);
        }
    }

        void testLockButton()
    {
        for (int i = 2; i < 7; i++)
        {
            PlayerPrefs.SetInt(ActivePlayerCharacter[i], 0);
        }
    }
}
