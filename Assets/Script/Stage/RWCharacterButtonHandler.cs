using UnityEngine;
using System.Collections;

public class RWCharacterButtonHandler : MonoBehaviour {
    public enum CharacterButtonState
    {
        Lock,
        Active,
    }

    public CharacterButtonState currentCharacterButtonState;

    public GameObject tmpCharacterSelectPanal;
    public GameObject selectImage;
    public GameObject LockImage;
    public int characterNomber;
    
    void Start()
    {
        if (currentCharacterButtonState == CharacterButtonState.Lock)
            LockImage.SetActive(true);
        else
            LockImage.SetActive(false);
    }


    public void CharacterSelectButtonActive()
    {
        if (currentCharacterButtonState == CharacterButtonState.Active)
        {
            tmpCharacterSelectPanal.SendMessage("CharacterButtonSelect", name);
            tmpCharacterSelectPanal.SendMessage("CharacterNumberDelivery", characterNomber);
        }
        else
        {
            print("Character Select Error Popup");
        }
    }

    public void SelectImageOn()
    {
        selectImage.SetActive(true);
    }

    public void SelectImageOff()
    {
        selectImage.SetActive(false);
    }

    public void CharacterSelectButtonUnLock()
    {
        currentCharacterButtonState = CharacterButtonState.Active;
        LockImage.SetActive(false);
    }
}
