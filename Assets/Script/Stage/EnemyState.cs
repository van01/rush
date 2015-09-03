using UnityEngine;
using System.Collections;

public class EnemyState : CharacterState
{
    private GameObject tmpGameController;

	void Start () {
        CharacterStateControll("Battle");
        tmpGameController = GameObject.Find("GameController");
        SendMessage("SearchPlayer");
	}

    public override void BattleAction()
    {
        base.BattleAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);
    }

    public override void AttackAction(){
		base.AttackAction();
        SendMessage("ChangeAni", CharacterAni.ATTACK);

        if (GetComponent<EnemyAbility>().currentAttackWeaponType == EnemyAbility.attackWeaponType.Sword)
            SendMessage("NormalAttackEffectRearOn", "Sword");           
	}

    public override void AttackDelayAction()
    {
        base.AttackDelayAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);
    }

    public override void MoveAction()
    {
        base.MoveAction();

        SendMessage("ChangeAni", CharacterAni.MOVE);
    }

    public override void DeadAction()
    {
        base.DeadAction();

        SendMessage("ChangeAni", CharacterAni.DEAD);
    }
}
