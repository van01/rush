using UnityEngine;
using System.Collections;

public class EnemyState : CharacterState
{
    private GameObject tmpGameController;
    private bool battling = false;
    private bool beginningJoin = true;

	void Start () {
        CharacterStateControll("Battle");
        tmpGameController = GameObject.Find("GameController");
        SendMessage("SearchPlayer");
	}

    public override void BattleAction()
    {
        base.BattleAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);

        StartCoroutine("BattleWait");
    }

    public override void AttackAction(){
		base.AttackAction();
        SendMessage("ChangeAni", CharacterAni.ATTACK);
	}

    private IEnumerator BattleWait()
    {
        float attackWaitTime = 1.0f;

        if (beginningJoin == true)
        {
            if (battling == true)
            {
                SendMessage("StartBattle");

                beginningJoin = false;
            }
        }

        yield return new WaitForSeconds(attackWaitTime);

        if (battling == true)
        {
            SendMessage("StartBattle");
        }
    }

    public override void MoveAction()
    {
        base.MoveAction();
        beginningJoin = true;
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
