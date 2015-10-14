using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool characterHealthBar;

    void Start()
    {
        if (GetComponent<StageController>().isRWStage == true)
            SendMessage("GameStateControll", "Lobby");
        else
            SendMessage("GameStateControll", "Ready");

        CharacterHealthBarOff();
    }

    void CharacterHealthBarOff()
    {
        if (characterHealthBar == false)
        {
            SendMessage("PlayerHealthBarOff");
        }
    }

    /// <summary>
    /// Lapick ~ Rushing to Witch ~
    /// </summary>
    /// 
    public void RWGameOver()
    {
        SendMessage("GameStateControll", "Hold");

        SendMessage("RWGameOverModeUISetting");

        SendMessage("PlayerGravityScaleOff");
    }

    public void RetryCharacterPosition()
    {
        SendMessage("RWCharacterPositionInit");     //playercontroller로 이관
        SendMessage("PlayerGravityScaleOn");
    }
}
