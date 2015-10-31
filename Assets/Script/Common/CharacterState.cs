using UnityEngine;
using System.Collections;

public class CharacterState : MonoBehaviour {

	public enum State{
		Spawn,		    //자기자리 찾아가기
		Idle,		    //대기
		Move,		    //이동
		Run,		    //달리기
		Battle,		    //전투
		Attack,		    //공격
        AttackDelay,	//공격 후 딜레이
		Skill,		    //스킬
		Guard,		    //방어
		Back,		    //후퇴
		Down,	        //앉기
        DownMove,       //누워서 앞으로
        DownBack,	    //누워서 뒤로
        Dead,		    //죽음
		Jump,		    //점프 시작
		Midair,		    //공중
		Landing,	    //착지
        Disorder,
        RWPlay,
        RWHold,
    }

	public State currentState;

	public virtual void CharacterStateControll(string s){
		if(s == "Spawn")
			currentState = State.Spawn;
		if(s == "Idle")
			currentState = State.Idle;
		if(s == "Move")
			currentState = State.Move;
		if(s == "Run")
			currentState = State.Run;
		if(s == "Battle")
			currentState = State.Battle;
		if(s == "Attack")
			currentState = State.Attack;
        if (s == "AttackDelay")
            currentState = State.AttackDelay;
		if(s == "Skill")
			currentState = State.Skill;
		if(s == "Guard")
			currentState = State.Guard;
		if(s == "Back")
			currentState = State.Back;
		if(s == "Down")
			currentState = State.Down;
        if (s == "DownMove")
            currentState = State.DownMove;
        if (s == "DownBack")
            currentState = State.DownBack;
        if (s == "Dead")
			currentState = State.Dead;
		if(s == "Jump")
			currentState = State.Jump;
		if(s == "Midair")
			currentState = State.Midair;
		if(s == "Landing")
			currentState = State.Landing;
        if (s == "Disorder")
            currentState = State.Disorder;
        if (s == "RWPlay")
            currentState = State.RWPlay;
        if (s == "RWHold")
            currentState = State.RWHold;

        CheckCharacterState();
	}

	public void CheckCharacterState(){
		switch(currentState){
		case State.Spawn:
			SpawnAction();
			break;
		case State.Idle:
			IdleAction();
			break;
		case State.Move:
			MoveAction();
			break;
		case State.Run:
			RunAction();
			break;
		case State.Battle:
			BattleAction();
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
		case State.Guard:
			GuardAction();
			break;
		case State.Back:
			BackAction();
			break;
		case State.Down:
            DownAction();
			break;
        case State.DownMove:
            DownMoveAction();
            break;
        case State.DownBack:
            DownBackAction();
            break;
            case State.Dead:
			DeadAction();
			break;
		case State.Jump:
			JumpAction();
			break;
		case State.Midair:
			MidairAction();
			break;
		case State.Landing:
			LandingAction();
			break;
        case State.Disorder:
            DisorderAction();
            break;
        case State.RWPlay:
            RWPlayAction();
            break;
        case State.RWHold:
            RWHoldAction();
            break;
        }
	}

	public virtual void SpawnAction(){
		//Debug.Log(":::Character State::: Character Spawn");
	}

	public virtual void IdleAction(){
		//Debug.Log(":::Character State::: Character Idle");
	}

	public virtual void MoveAction(){
		//Debug.Log(":::Character State::: Character Move");
	}

	public virtual void RunAction(){
		//Debug.Log(":::Character State::: Character Run");
	}

	public virtual void BattleAction(){
		//Debug.Log(":::Character State::: Character Battle");
	}

	public virtual void AttackAction(){
		//Debug.Log(":::Character State::: Character Attack");
	}

    public virtual void AttackDelayAction()
    {
        //Debug.Log(":::Character State::: Character Attack Delay");
    }

	public virtual void SkillAction(){
		//Debug.Log(":::Character State::: Character Skill");
	}

	public virtual void GuardAction(){
		//Debug.Log(":::Character State::: Character Guard");
	}

	public virtual void BackAction(){
		//Debug.Log(":::Character State::: Character Back");
	}

	public virtual void DownAction(){
		//Debug.Log(":::Character State::: Character Forward");
	}

    public virtual void DownMoveAction()
    {
        //Debug.Log(":::Character State::: Character Forward");
    }

    public virtual void DownBackAction()
    {
        //Debug.Log(":::Character State::: Character Forward");
    }

    public virtual void DeadAction(){
		//Debug.Log(":::Character State::: Character Dead");
	}

	public virtual void JumpAction(){
		//Debug.Log(":::Character State::: Character Jump");
	}

	public virtual void MidairAction(){
		//Debug.Log(":::Character State::: Character Midair");
	}

	public virtual void LandingAction(){
		//Debug.Log(":::Character State::: Character Landing");
	}

    public virtual void DisorderAction()
    {
        //Debug.Log(":::Character State::: Character Disorder");
    }

    public virtual void RWPlayAction()
    {
        //Debug.Log(":::Character State::: Character RWPlayAction");
    }

    public virtual void RWHoldAction()
    {
        //Debug.Log(":::Character State::: Character RWHoldAction");
    }
}
