using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDQuestDramaticPanelHandler : MonoBehaviour {

    public GameObject confirmPopup;
    public GameObject confirmPopupTxtBox;

    private string confirmPopupTxtBoxString;

    public void ConfirmPopupOn()
    {
        confirmPopup.SetActive(true);

        confirmPopupTxtBox.GetComponent<Text>().text = confirmPopupTxtBoxString;
    }

    public void ConfirmPopupOff()
    {
        confirmPopup.SetActive(false);
    }

    public void TextBoxStringSetting(string nCurrentString)
    {
        confirmPopupTxtBoxString = nCurrentString;
    }
}
