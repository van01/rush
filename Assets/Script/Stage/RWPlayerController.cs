using UnityEngine;
using System.Collections;

public class RWPlayerController : MonoBehaviour {

    public GameObject[] playerCharacter;
    private int playerNumber;
    private int helmetNumber;

    void Start () {
        RWPlayerCharacterInitialize();
    }
	
	void RWPlayerCharacterInitialize()
    {
        playerNumber = PlayerPrefs.GetInt("PlayerCharacterNumber");
        
        for (int i = 0; i < playerCharacter.Length; i++)
        {
            if (i == playerNumber)
            {
                playerCharacter[i].SetActive(true);
                playerCharacter[i].SendMessage("CharacterStateControll", "RWPlay");
                
                RWHelmetInitialize();
                SendMessage("PlayerHealthBarOff");
            }
            else
                playerCharacter[i].SetActive(false);
        }
    }

    void RWHelmetInitialize()
    {
        helmetNumber = PlayerPrefs.GetInt("CurrentHelmetNumber");

        for (int i = 0; i < playerCharacter.Length; i++)
        {
            if (i == playerNumber)
                playerCharacter[i].SendMessage("EquipHelmet", helmetNumber);

        }
    }

    public void RWPlayerCHaracterSetting(int nCharacterNumber)
    {
        PlayerPrefs.SetInt("PlayerCharacterNumber", nCharacterNumber);
        print(nCharacterNumber);
        RWPlayerCharacterInitialize();
    }

    public void RWHelmetSetting(int nHelmetNumber)
    {
        PlayerPrefs.SetInt("CurrentHelmetNumber", nHelmetNumber);
        print(nHelmetNumber);
        RWHelmetInitialize();
    }


}
