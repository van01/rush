using UnityEngine;
using System.Collections;

public class ObjectState : MonoBehaviour
{

    public enum State
    {
        Idle,           //대기
        Hit,           //피격
        End,           //종료
    }

    public State currentState;

    public void CheckObjectState()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleAction();
                break;
            case State.Hit:
                HitAction();
                break;
            case State.End:
                EndAction();
                break;
        }
    }

    void IdleAction()
    {
        SendMessage("ChangeAni", ObjectAni.IDLE);
    }

    void HitAction()
    {
        SendMessage("ChangeAni", ObjectAni.HIT);
    }

    void EndAction()
    {
        SendMessage("ChangeAni", ObjectAni.END);
    }

    public void HitAnimEnd()
    {
        currentState = State.Idle;
        CheckObjectState();
    }
}
