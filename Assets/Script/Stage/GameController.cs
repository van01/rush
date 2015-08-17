using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float CharacterPositionInializeTime = 1.0f;

	private GameObject[] tmpPlayer;
	private bool characterEnterCheckTrueValue = false;

	private bool characterMovePredicate = false;
	private bool characterBattlePredicate = false;

    private GameObject[] tmpMonsters;

	public enum States{
		Spawns,		//자기자리 찾아가기
		Idles,		//대기
		Moves,		//이동
		Runs,		//달리기
		Battles,		//전투
		Attacks,		//공격
		Skills,		//스킬
		Guards,		//방어
		Backs,		//후퇴
		Forwards,	//전방으로
		Deads,		//죽음
		Jumps,		//점프 시작
		Midairs,		//공중
		Landings,	//착지
	}

    public States currentStates;
    public States previousStates;

	void Awake() {
		characterMovePredicate = true;

        SendMessage("GameStateControll", "Ready"); //임시

        CharacterActionCheck();

        PlayerCharacterSorting();
        EnemyCharacterSorting();
	}
	
	// Update is called once per frame
	public void CharacterInialize(){
        tmpPlayer = GameObject.FindGameObjectsWithTag("Player");
        tmpMonsters = GameObject.FindGameObjectsWithTag("Enemy");

		for (int i = 0; i < tmpPlayer.Length; i++){
			tmpPlayer[i].gameObject.SendMessage("CharacterPositionInialize", CharacterPositionInializeTime);
		}
	}

	private void CharacterStateChange(string s){
		for (int i = 0; i < tmpPlayer.Length; i++){
			tmpPlayer[i].gameObject.SendMessage("CharacterStateControll", s);
		}
	}

	public void CharacterEnterCheck(){
		if(characterEnterCheckTrueValue == true){
			characterMovePredicate = false;
			characterBattlePredicate = true;
		}
	}

	public void CharacterEnterCheckTrue(){
		characterEnterCheckTrueValue = true;
	}

	public void CharacterActionCheck(){
		switch(currentStates){
		case States.Spawns:
			CharacterStateChange("Spawn");
			break;
        case States.Idles:
			CharacterStateChange("Idle");
			break;
        case States.Moves:
			CharacterStateChange("Move");
			break;
        case States.Runs:
			CharacterStateChange("Run");
			break;
        case States.Battles:
			CharacterStateChange("Battle");
			break;
        case States.Guards:
			CharacterStateChange("Guard");
			break;
        case States.Backs:
			CharacterStateChange("Back");
			break;
        case States.Forwards:
			CharacterStateChange("Forward");
			break;
		}
	}

	public void CharacterMovePredicateOn(){
        previousStates = currentStates;
        currentStates = States.Moves;
        //SendMessage("GameStateControll", "Playing");
		CharacterActionCheck();
	}
	
	public void CharacterMovePredicateOff(){
        currentStates = previousStates;
		CharacterActionCheck();
	}
	
	public void CharacterGuardPredicateOn(){
		SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.Guards;
		CharacterActionCheck();
	}
	
	public void CharacterGuardPredicateOff(){
        if (characterBattlePredicate == true)
            SendMessage("GameStateControll", "Hold");
        else
            SendMessage("GameStateControll", "Playing");
        
        //currentStates = previousStates;	-- ㄱㅐㅅㅓㄴ ㅍㅣㄹㅇㅛ
		currentStates = States.Moves;
		CharacterActionCheck();
	}
	
	public void CharacterBattlePredicateOn(){
        SendMessage("GameStateControll", "Hold");
		characterBattlePredicate = true;
        previousStates = currentStates;
        //currentStates = States.Battles;
		//CharacterActionCheck();
	}
	
	public void CharacterBattlePredicateOff(){
		characterBattlePredicate = false;
        currentStates = previousStates;
		CharacterActionCheck();
	}

	public void CharacterRunPredicateOn(){
        previousStates = currentStates;
        currentStates = States.Runs;
		CharacterActionCheck();
	}

	public void CharacterRunPredicateOff(){
        if (characterBattlePredicate == true)
			SendMessage("GameStateControll", "Hold");
		else
			SendMessage("GameStateControll", "Playing");
		
        
        //currentStates = previousStates; -- 개선필요
		currentStates = States.Moves;
        CharacterActionCheck();
	}

	private void CharacterBattleStop(){
		for (int i = 0; i < tmpPlayer.Length; i++){
			tmpPlayer[i].gameObject.SendMessage("BattleStop");
		}
	}

	public void CharacterBackPredicateOn(){
		SendMessage("GameStateControll", "Hold");
        previousStates = currentStates;
        currentStates = States.Backs;
		CharacterActionCheck();
	}
	
	public void CharacterBackPredicateOff(){
        currentStates = States.Moves;
		CharacterActionCheck();
	}

	public void CharacterFowardPredicateOn(){
        previousStates = currentStates;
        currentStates = States.Forwards;
		CharacterActionCheck();
        CharacterFowardColliderOn();
	}
	
	public void CharacterFowardPredicateOff(){
        //currentStates = previousStates;	-- ㄱㅐㅅㅓㄴ ㅍㅣㄹㅇㅛ
		currentStates = States.Moves;
		CharacterActionCheck();
        CharacterFowardColliderOff();
	}

    public void CharacterBattlingOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("BattlingOn");
        }
    }

    public void CharacterBattlingOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("BattlingOff");
        }
    }

    public void CharacterAttactDistanceOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("AttDistanceOn");
        }
    }

    public void CharacterAttactDistanceOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("AttDistanceOff");
        }
    }

    public void CharacterFowardColliderOn()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("WeaponColliderOff");
        }
    }

    public void CharacterFowardColliderOff()
    {
        for (int i = 0; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("FowardColliderOff");
            tmpPlayer[i].gameObject.SendMessage("WeaponColliderReset");
        }
    }

    public void EnemyStateBattleInfection(int nBaseGroupValue)
    {
        tmpMonsters = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < tmpMonsters.Length; i++)
        {
            if (nBaseGroupValue == tmpMonsters[i].GetComponent<EnemyAI>().groupValue)
            {
                if (tmpMonsters[i].GetComponent<EnemyState>().currentState == CharacterState.State.Battle)
                {
                    tmpMonsters[i].gameObject.SendMessage("ChasePlayer");
                }
            }
        }
    }

    void PlayerCharacterSorting()
    {
        for (int i = 1; i < tmpPlayer.Length; i++)
        {
            tmpPlayer[i].gameObject.SendMessage("CharacterSorting",i);
        }
    }

    void EnemyCharacterSorting()
    {
        for (int i = 1; i < tmpMonsters.Length; i++)
        {
            tmpMonsters[i].gameObject.SendMessage("CharacterSorting", i);
        }
    }
}
