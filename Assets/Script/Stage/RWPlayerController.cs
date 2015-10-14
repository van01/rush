using UnityEngine;
using System.Collections;

public class RWPlayerController : MonoBehaviour {

    public GameObject[] playerCharacter;
    private int playerNumber;

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
                SendMessage("PlayerHealthBarOff");
            }
            else
                playerCharacter[i].SetActive(false);
        }
    }

    public void RWPlayerCHaracterSetting(int nCharacterNumber)
    {
        PlayerPrefs.SetInt("PlayerCharacterNumber", nCharacterNumber);
        print(nCharacterNumber);
        RWPlayerCharacterInitialize();
    }
}
