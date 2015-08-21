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
		Forward,	    //전방으로
		Dead,		    //죽음
		Jump,		    //점프 시작
		Midair,		    //공중
		Landing,	    //착지
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
		if(s == "Forward")
			currentState = State.Forward;
		if(s == "Dead")
			currentState = State.Dead;
		if(s == "Jump")
			currentState = State.Jump;
		if(s == "Midair")
			currentState = State.Midair;
		if(s == "Landing")
			currentState = State.Landing;

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
		case State.Forward:
			ForwardAction();
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

	public virtual void ForwardAction(){
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
}
