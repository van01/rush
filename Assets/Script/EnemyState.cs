using UnityEngine;
using System.Collections;

public class EnemyState : CharacterState
{
    private GameObject tmpGameController;
    private bool battling = false;

	void Start () {
        CharacterStateControll("Battle");
        tmpGameController = GameObject.Find("GameController");
        SendMessage("SearchPlayer");
	}

    public override void BattleAction()
    {
        base.BattleAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);

        if (battling == true)
        {
            SendMessage("StartBattle");
        }
    }

    public override void AttackAction(){
		base.AttackAction();
        SendMessage("ChangeAni", CharacterAni.ATTACK);
	}

    public override void MoveAction()
    {
        base.MoveAction();

        SendMessage("ChangeAni", CharacterAni.MOVE);
    }

    public void BattlingOff()
    {
        battling = false;
        CheckCharacterState();
    }

    public void BattlingOn()
    {
        battling = true;
        CheckCharacterState();
    }
}
