using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState
{

    private GameObject tmpGameController;

    private Vector2 backupColliderOffset;
    private Vector2 backupColliderSize;

    void Start()
    {
        //CharacterStateControll("Spawn");
        if (tag == "Player")
            CharacterStateControll("RWPlay");   ////////
        else
            CharacterStateControll("RWHold");   ////////

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

        CharacterColliderReset();
    }

    public override void MoveAction()
    {
        base.MoveAction();

        SendMessage("ChangeAni", CharacterAni.MOVE);
        //SendMessage("SearchEnemy");       //if insert

        if (transform.position.x != GetComponent<PlayerAI>().positionDistance)
        {
            SendMessage("CharacterPositionInialize", 0.5f);
        }

        CharacterColliderReset();
    }

    public override void RunAction()
    {
        base.RunAction();

        SendMessage("ChangeAni", CharacterAni.RUN);

        CharacterColliderReset();
    }

    public override void BattleAction()
    {
        base.BattleAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);

        SendMessage("CharacterBackPositionOff");
        SendMessage("CharacterFowardPositionOff");

        CharacterColliderReset();
    }

    public override void AttackAction()
    {
        base.AttackAction();

        if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Sword)
            SendMessage("NormalAttackEffectRearOn", "Sword");
        else if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Spear)
            SendMessage("NormalAttackEffectRearOn", "Spear");
        else if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Gun)
            SendMessage("NormalAttackEffectRearOn", "Gun");
        else if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Bazooka)
            SendMessage("NormalAttackEffectRearOn", "Bazooka");
        else if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Staff)
            SendMessage("NormalAttackEffectRearOn", "Staff");
        else if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Wand)
            SendMessage("NormalAttackEffectRearOn", "Wand");

        SendMessage("ChangeAni", CharacterAni.ATTACK);

        CharacterColliderReset();
    }

    public override void AttackDelayAction()
    {
        base.AttackDelayAction();
        SendMessage("ChangeAni", CharacterAni.BATTLE);

        CharacterColliderReset();
    }

    public override void SkillAction()
    {
        base.SkillAction();

        SendMessage("BattleStop");

        SendMessage("ChangeAni", CharacterAni.SKILL);

        if (GetComponent<PlayerAbility>().currentAttackWeaponType == PlayerAbility.attackWeaponType.Sword)
            SendMessage("Skill01AttackEffectRearOn", "Sword");

        CharacterColliderReset();
    }

    public override void GuardAction()
    {
        base.GuardAction();

        

        SendMessage("ChangeAni", CharacterAni.GUARD);

        CharacterColliderReset();
    }

    public override void BackAction()
    {
        base.BackAction();
        SendMessage("BattleStop");

        SendMessage("ChangeAni", CharacterAni.BACK);
        SendMessage("CharacterBackPositionOn");

        CharacterColliderReset();
    }

    public override void DownAction()
    {
        base.DownAction();

        SendMessage("ChangeAni", CharacterAni.DOWN);

        CharacterColliderDownSetting();

        SendMessage("CharacterPositionHold");
    }

    public override void DownMoveAction()
    {
        base.DownMoveAction();

        SendMessage("ChangeAni", CharacterAni.DOWNMOVE);

        CharacterColliderDownSetting();

        SendMessage("CharacterPositionHold");
    }

    public override void DownBackAction()
    {
        base.DownBackAction();

        SendMessage("ChangeAni", CharacterAni.DOWNBACK);

        CharacterColliderDownSetting();

        SendMessage("CharacterPositionHold");
    }

    public override void DeadAction()
    {
        base.DeadAction();
        print("Dead!!!!!!");
        SendMessage("BattleEnd");
        SendMessage("ChangeAni", CharacterAni.DEAD);
    }

    public override void RWPlayAction()
    {
        base.RWPlayAction();
        SendMessage("ChangeAni", CharacterAni.RWPlay);
    }

    public override void RWHoldAction()
    {
        base.RWHoldAction();
        SendMessage("ChangeAni", CharacterAni.RWHold);
    }

    public override void CharacterStateControll(string s)
    {
        base.CharacterStateControll(s);
    }

    void CharacterColliderDownSetting()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.12f, -0.74f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 0.4f);
    }

    void CharacterColliderReset()
    {
        gameObject.GetComponent<BoxCollider2D>().offset = backupColliderOffset;
        gameObject.GetComponent<BoxCollider2D>().size = backupColliderSize;
    }
}
