﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int currentUserLevel;

    void Start()
    {
        currentUserLevel = GetComponent<UserLevelHandler>()._currentUserLevel;

        GetComponent<GameState>().currentState = GameState.State.Egg;       //임시
        GetComponent<GameState>().CheckGameState();
    }
}