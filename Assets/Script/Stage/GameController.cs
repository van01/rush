using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool characterHealthBar;

    void Start()
    {
        SendMessage("GameStateControll", "Ready"); //임시
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
        print("game over!!!!");
        SendMessage("GameStateControll", "Hold");
    }
}
