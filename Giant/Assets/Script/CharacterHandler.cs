using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

    public GameObject playerObject;
    public GameObject targetObject;

    private GameObject currentPlayer;

    void Awake()
    {
        currentPlayer = playerObject.GetComponent<PlayerControllerHandler>().currentPlayer;
    }

    public void currentPlayerIdle()
    {
        currentPlayer.GetComponent<PlayerState>().currentState = CharacterState.State.Idle;
        currentPlayer.GetComponent<PlayerState>().CheckCharacterState();
    }

    public void currentPlayerRun()
    {
        currentPlayer.GetComponent<PlayerState>().currentState = CharacterState.State.Run;
        currentPlayer.GetComponent<PlayerState>().CheckCharacterState();
    }
}
