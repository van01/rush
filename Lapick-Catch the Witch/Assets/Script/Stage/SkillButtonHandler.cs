using UnityEngine;
using System.Collections;

public class SkillButtonHandler : MonoBehaviour {
    public GameObject tmpHUDHandler;
    string id;

    public void OnClickSkillButtonSelfSetting()
    {
        id = name;

        tmpHUDHandler.SendMessage("OnClickSkillButton", id);
    }
}
