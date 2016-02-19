using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDScoutPanelHandler : MonoBehaviour {

    public GameObject confirmPopup;
    public GameObject textBox;

    private string textBoxString;

    public void ConfirmPopupOn()
    {
        confirmPopup.SetActive(true);

        textBox.GetComponent<Text>().text = textBoxString;
    }

    public void ConfirmPopupOff()
    {
        confirmPopup.SetActive(false);
    }

    public void TextBoxStringSetting(string nCurrentString)
    {
        textBoxString = nCurrentString;
    }
}
