using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState
{

    private GameObject tmpGameController;
    private bool battling = true;

    private Vector2 backupColliderOffset;
    private Vector2 backupColliderSize;

    void Start()
    {
        CharacterStateControll("Spawn");
        tmpGameController = GameObject.Find("GameController");

        backupColliderOffset = gameObject.GetComponent<BoxCollider2D>().offset;
        backupColliderSize = gameObject.GetComponent<BoxCollider2D>().size;
    }

    public override void SpawnAction()
    {
        base.SpawnAction();

        SendMessage("ChangeAni", CharacterAni.MOVE);
    }

    public override void IdleAction()
    {
        base.IdleAction();

        SendMessage("ChangeAni", CharacterAni.IDLE);
    }

    public override void MoveAction()
    {
        base.MoveAction();

        SendMessage("ChangeAni", CharacterAni.MOVE);
        SendMessage("SearchEnemy");

        if (transform.position.x != GetComponent<PlayerAI>().positionDistance)
        {
            SendMessage("CharacterPositionInialize", 0.5f);
        }

    }

    public override void RunAction()
    {
        base.RunAction();

        SendMessage("ChangeAni", CharacterAni.RUN);
    }

    public override void BattleAction()
    {
        base.BattleAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);

        if (battling == true)
        {
            SendMessage("StartBattle");
        }

        SendMessage("CharacterBackPositionOff");
        SendMessage("CharacterFowardPositionOff");
    }

    public override void AttackAction()
    {
        base.AttackAction();
        SendMessage("ChangeAni", CharacterAni.ATTACK);
    }

    public override void GuardAction()
    {
        base.GuardAction();

        SendMessage("BattleStop");

        SendMessage("ChangeAni", CharacterAni.GUARD);
    }

    public override void BackAction()
    {
        base.BackAction();
        SendMessage("BattleStop");

        SendMessage("ChangeAni", CharacterAni.BACK);
        SendMessage("CharacterBackPositionOn");
    }

    public override void ForwardAction()
    {
        base.ForwardAction();

        SendMessage("ChangeAni", CharacterAni.FOWARD);
        FowardColliderSetting();
    }

    public override void DeadAction()
    {
        base.DeadAction();

        SendMessage("ChangeAni", CharacterAni.DEAD);
    }

    public override void CharacterStateControll(string s)
    {
        base.CharacterStateControll(s);
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

    void FowardColliderSetting()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.12f, -0.74f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 0.4f);
    }

    void FowardColliderOff()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = backupColliderOffset;
        gameObject.GetComponent<BoxCollider2D>().size = backupColliderSize;
    }
}
