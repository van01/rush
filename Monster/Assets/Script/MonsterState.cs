using UnityEngine;
using System.Collections;

public class MonsterState : MonoBehaviour
{
    public enum State
    {
        Spawn,          //출현
        Idle,           //대기
        Bored,          //심심한 상태
        Happy,          //행복
        Hungry,         //배고픈 상태
        Tired,          //피곤
        Move,           //이동
        Attack,		    //공격
        Fall,           //넘어짐
    }

    public State currentState;

    public void CheckMonsterState()
    {
        switch (currentState)
        {
            case State.Spawn:
                SpawnAction();
                break;
            case State.Idle:
                IdleAction();
                break;
            case State.Bored:
                BoredAction();
                break;
            case State.Happy:
                HappyAction();
                break;
            case State.Hungry:
                HungryAction();
                break;
            case State.Tired:
                TiredAction();
                break;
            case State.Move:
                MoveAction();
                break;
            case State.Attack:
                AttackAction();
                break;
            case State.Fall:
                FallAction();
                break;
        }
    }

    public enum Condition
    {
        Happy,      //행복한
        Good,       //좋은
        Normal,     //보통
        NotBad,     //나쁘지않은
        Bad,        //나쁜
    }

    public Condition currentCondition;

    public void CheckMonsterCondition()
    {
        switch (currentCondition)
        {
            case Condition.Happy:
                GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.Happy;
                GetComponent<MonsterFaceController>().CheckFaceState();
                break;
            case Condition.Good:
                GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.Good;
                GetComponent<MonsterFaceController>().CheckFaceState();
                break;
            case Condition.Normal:
                GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.Normal;
                GetComponent<MonsterFaceController>().CheckFaceState();
                break;
            case Condition.NotBad:
                GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.NotBad;
                GetComponent<MonsterFaceController>().CheckFaceState();
                break;
            case Condition.Bad:
                GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.Bad;
                GetComponent<MonsterFaceController>().CheckFaceState();
                break;
        }
    }

    void SpawnAction()
    {
        GetComponent<MonsterAni>().SendMessage("ChangeAni", MonsterAni.SPAWN);

        GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.Funny;
        GetComponent<MonsterFaceController>().CheckFaceState();
    }

    void IdleAction()
    {
        GetComponent<MonsterAni>().SendMessage("ChangeAni", MonsterAni.IDLE);

        CheckMonsterCondition();
    }

    void BoredAction()
    {

    }

    void HappyAction()
    {

    }

    void HungryAction()
    {

    }

    void TiredAction()
    {

    }

    void MoveAction()
    {

    }

    void AttackAction()
    {

    }

    void FallAction()
    {

    }

    void SpawnAniEnd()
    {
        currentState = State.Idle;
        CheckMonsterState();

        //if (transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().currentState != GameState.State.Monster)
        //{
        //    transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().currentState = GameState.State.Monster;
        //    transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().CheckGameState();
        //}
        //currentState = State.Monster;
        //CheckGameState();
    }
}