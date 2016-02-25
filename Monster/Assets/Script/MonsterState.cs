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
        AttackWait,     //공격 후 대기
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
            case State.AttackWait:
                AttackWaitAction();
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
        SendMessage("ChangeAni", MonsterAni.SPAWN);

        GetComponent<MonsterFaceController>().currentFaceState = MonsterFaceController.FaceState.Funny;
        GetComponent<MonsterFaceController>().CheckFaceState();
    }

    void IdleAction()
    {
        SendMessage("ChangeAni", MonsterAni.IDLE);

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
        //print("Move Action!!!!!!!!");
        //현재 훈련 연출용 몬스터가 무브로 갔다가 바로 아이들로 돌아가는 이슈 존재
        SendMessage("ChangeAni", MonsterAni.MOVE);
    }

    void AttackAction()
    {
        //print("Attack Action!!!!!!!!");
        SendMessage("ChangeAni", MonsterAni.ATTACK);
    }

    void AttackWaitAction()
    {
        SendMessage("ChangeAni", MonsterAni.ATTACKWAIT);
    }

    void FallAction()
    {
        if (transform.root.GetComponent<TrainingDramaticHandler>().gameContoller.GetComponent<TrainingController>().currentTraining == TrainingController.TrainingType.Pow)
            SendMessage("ChangeAni", MonsterAni.ATTACKFAIL);
    }

    void SpawnAniEnd()
    {
        if (currentState == State.Spawn)
        {
            currentState = State.Idle;
            CheckMonsterState();
        }

        //if (transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().currentState != GameState.State.Monster)
        //{
        //    transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().currentState = GameState.State.Monster;
        //    transform.root.GetComponent<MonsterBasket>().tmpGameController.GetComponent<GameState>().CheckGameState();
        //}
        //currentState = State.Monster;
        //CheckGameState();
    }
}