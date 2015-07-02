﻿using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState {

	private GameObject tmpGameController;
    private bool battling = true;
    private bool beginningJoin = true;


	void Start(){
		CharacterStateControll("Spawn");
		tmpGameController = GameObject.Find("GameController");
	}

	public override void SpawnAction(){
		base.SpawnAction();

		SendMessage("ChangeAni", CharacterAni.MOVE);
	}

	public override void IdleAction(){
		base.IdleAction();

		SendMessage("ChangeAni", CharacterAni.IDLE);
	}

	public override void MoveAction(){
		base.MoveAction();

		SendMessage("ChangeAni", CharacterAni.MOVE);
		SendMessage("SearchEnemy");

        if (transform.position.x != GetComponent<PlayerAI>().positionDistance)
        {
            SendMessage("CharacterPositionInialize", 0.5f);
        }
        
	}

	public override void RunAction(){
		base.RunAction();
        
		SendMessage("ChangeAni", CharacterAni.RUN);
	}

	public override void BattleAction(){
		base.BattleAction();
		SendMessage("ChangeAni", CharacterAni.BATTLE);

        StartCoroutine("BattleWait");
		
        SendMessage("CharacterBackPositionOff");
        SendMessage("CharacterFowardPositionOff");
	}

	public override void AttackAction(){
		base.AttackAction();
        SendMessage("ChangeAni", CharacterAni.ATTACK);
	}

	public override void GuardAction(){
		base.GuardAction();

        SendMessage("BattleStop");

		SendMessage("ChangeAni", CharacterAni.GUARD);
	}

	public override void BackAction(){
		base.BackAction();
        SendMessage("BattleStop");

		SendMessage("ChangeAni", CharacterAni.BACK);
		SendMessage("CharacterBackPositionOn");
	}

	public override void ForwardAction(){
		base.ForwardAction();
		
		SendMessage("CharacterFowardPositionOn"); // test
	}

	public override void CharacterStateControll(string s){
		base.CharacterStateControll(s);
	}

	private IEnumerator BattleWait(){
		float attackWaitTime = 1.0f;

        if (beginningJoin == true)
        {
            if (battling == true)
            {
                SendMessage("StartBattle");

                beginningJoin = false;
            }
        }

		yield return new WaitForSeconds (attackWaitTime);

        if (battling == true)
        {
            SendMessage("StartBattle");
        }
	}

    public void BattlingOff()
    {
        battling = false;
    }

    public void BattlingOn()
    {
        battling = true;
    }

    public void beginningJoinOn()
    {
        beginningJoin = true;
    }
}
