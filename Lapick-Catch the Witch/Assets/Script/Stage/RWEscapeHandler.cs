using UnityEngine;
using System.Collections;

public class RWEscapeHandler : MonoBehaviour {

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (GetComponent<GameState>().currentState == GameState.State.Lobby)
                {
                    SendMessage("RWGameExitUISetting");
                }
                else if (GetComponent<GameState>().currentState == GameState.State.Ready)
                {
                    SendMessage("GameStateControll", "Playing");
                }
                else if (GetComponent<GameState>().currentState == GameState.State.Playing)
                {
                    SendMessage("RWGamePauseOnUISetting");
                }
            }
        }
    }

}
