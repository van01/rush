using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    protected float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        MonsterInitTime();
        //print(_timer);
    }

    public void TimerInitialize()
    {
        _timer = 0;
    }

    public void TimerAccel()
    {
        _timer += 1.0f;
    }

    protected void MonsterInitTime()
    {
        if (GetComponent<GameState>().currentState == GameState.State.Egg)
        {
            if (_timer >= 10.0f)
            {
                GetComponent<GameState>().currentState = GameState.State.EggEnd;
                GetComponent<GameState>().CheckGameState();
            }
        }
    }
}
