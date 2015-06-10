using UnityEngine;
using System.Collections;

public class CharacterState : MonoBehaviour {

	public enum State{
		Spawn,		//자기자리 찾아가기
		Idle,		//대기
		Move,		//이동
		Run,		//달리기
		Battle,		//전투
		Attack,		//공격
		Skill,		//스킬
		Guard,		//방어
		Back,		//후퇴
		Dead,		//죽음
		Jump,		//점프 시작
		Midair,		//공중
		Landing,	//착지
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
		if(s == "Skill")
			currentState = State.Skill;
		if(s == "Guard")
			currentState = State.Guard;
		if(s == "Back")
			currentState = State.Back;
		if(s == "Dead")
			currentState = State.Dead;
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
		case State.Skill:
			SkillAction();
			break;
		case State.Guard:
			GuardAction();
			break;
		case State.Back:
			BackAction();
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
		SendMessage("ChangeAni", 3);
		print ("Character Spawn");
	}

	public virtual void IdleAction(){
		print ("Character Idle");
	}

	public virtual void MoveAction(){
		SendMessage("ChangeAni", 3);
		print ("Character Move");
	}

	public virtual void RunAction(){
		SendMessage("ChangeAni", 4);
		print ("Character Run");
	}

	public virtual void BattleAction(){
		print ("Character Attack");
	}

	public virtual void AttackAction(){
		print ("Character Attack");
	}

	public virtual void SkillAction(){
		print ("Character Skill");
	}

	public virtual void GuardAction(){
		print ("Character Guard");
	}

	public virtual void BackAction(){
		print ("Character Back");
	}

	public virtual void DeadAction(){
		print ("Character Dead");
	}

	public virtual void JumpAction(){
		print ("Character Jump");
	}

	public virtual void MidairAction(){
		print ("Character Midair");
	}

	public virtual void LandingAction(){
		print ("Character Landing");
	}
}
