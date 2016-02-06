using UnityEngine;
using System.Collections;

public class CharacterState : MonoBehaviour {

	public enum State
    {
        Idle,           //대기
        Spawn,          //시작
        Run,            //달리기
        Dash,           //대쉬
        Attack,		    //공격
        AttackDelay,    //공격 후 딜레이
        Skill,          //스킬
        Roll,           //구르기
        Dead,           //죽음
        Disorder,       //상태이상
    }

    public State currentState;

    public void CheckCharacterState()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleAction();
                break;
            case State.Spawn:
                SpawnAction();
                break;
            case State.Run:
                RunAction();
                break;
            case State.Dash:
                DashAction();
                break;
            case State.Attack:
                AttackAction();
                break;
            case State.AttackDelay:
                AttackDelayAction();
                break;
            case State.Skill:
                SkillAction();
                break;
            case State.Roll:
                RollAction();
                break;
            case State.Dead:
                DeadAction();
                break;
            case State.Disorder:
                DisorderAction();
                break;

        }
    }

    public virtual void IdleAction()
    {

    }

    public virtual void SpawnAction()
    {

    }

    public virtual void RunAction()
    {

    }

    public virtual void DashAction()
    {

    }

    public virtual void AttackAction()
    {

    }

    public virtual void AttackDelayAction()
    {

    }

    public virtual void SkillAction()
    {

    }

    public virtual void RollAction()
    {

    }

    public virtual void DeadAction()
    {

    }

    public virtual void DisorderAction()
    {

    }

    }
