using UnityEngine;
using System.Collections;

public class RWHelmetActiveButtonHandler : MonoBehaviour {
    public enum HelmetActiveButtonState
    {
        Lock,
        Active,
    }

    public HelmetActiveButtonState currentHelmetButtonState;

    public GameObject ActiveButton;
    public GameObject LockButton;

    public void ButtonStateControll(RWHelmetButtonHandler.HelmetButtonState nState)
    {
        if (nState == RWHelmetButtonHandler.HelmetButtonState.Active)
            currentHelmetButtonState = HelmetActiveButtonState.Active;
        else
            currentHelmetButtonState = HelmetActiveButtonState.Lock;

        HelmetActiveButtonStateCheck();
    }

    void HelmetActiveButtonStateCheck()
    {
        switch (currentHelmetButtonState)
        {
            case HelmetActiveButtonState.Lock:
                ActiveButtonLockInitialize();
                break;
            case HelmetActiveButtonState.Active:
                ActiveButtonActiveInitialize();
                break;
        }
    }

    void ActiveButtonLockInitialize()
    {
        LockButton.SetActive(true);
        ActiveButton.SetActive(false);
    }

    void ActiveButtonActiveInitialize()
    {
        LockButton.SetActive(false);
        ActiveButton.SetActive(true);
    }
}
