using UnityEngine;
using System.Collections;

public class RWPlayerController : MonoBehaviour {

    public GameObject[] playerCharacter;
    public GameObject currentPlayerCharacter;
    private int playerNumber;
    private int helmetNumber;

    void Awake () {
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
                //playerCharacter[i].SendMessage("CharacterStateControll", "RWPlay");
                playerCharacter[i].GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.5f);
                playerCharacter[i].GetComponent<BoxCollider2D>().size = new Vector2(0.3f, 0.75f);

                RWHelmetInitialize();
                SendMessage("PlayerHealthBarOff");
                currentPlayerCharacter = playerCharacter[i];
                RWPlayerCharacterAniSpeedDelivery(1);
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
        RWPlayerCharacterInitialize();
    }

    public void RWHelmetSetting(int nHelmetNumber)
    {
        PlayerPrefs.SetInt("CurrentHelmetNumber", nHelmetNumber);
        print(nHelmetNumber);
        RWHelmetInitialize();
    }

    public void RWPlayerCharacterAniSpeedDelivery(float nSpeed)
    {
        currentPlayerCharacter.SendMessage("RWPlayerCharacterAniSpeed", nSpeed);
    }
}
