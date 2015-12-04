using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RWAlertPanelHandler : MonoBehaviour {

    public GameObject text;

	public void AlertMessageSetting(string nAlertMessage)
    {
        text.GetComponent<Text>().text = nAlertMessage;
    }
}
