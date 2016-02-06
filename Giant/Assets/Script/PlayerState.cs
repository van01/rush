using UnityEngine;
using System.Collections;

public class PlayerState : CharacterState {

    private int attackCount;
    private float currentTime;
    private float attack1Time;
    private float attack2Time;

    public override void IdleAction()
    {
        base.IdleAction();
        SendMessage("ChangeAni", CharacterAni.IDLE);
        transform.localPosition = new Vector3(0, -1, 0);

        transform.root.GetComponent<PlayerAI>().isAttackAble = true;
    }

    public override void RunAction()
    {
        base.RunAction();
        SendMessage("ChangeAni", CharacterAni.RUN);
    }

    public override void DashAction()
    {
        base.DashAction();
        SendMessage("ChangeAni", CharacterAni.RUN);
    }

    public override void AttackAction()
    {
        base.AttackAction();
        currentTime = transform.root.GetComponent<CharacterBattle>().gameController.GetComponent<TimeAttack>().currentTime;

        if (currentTime - attack2Time <= 1f)
        {
            SendMessage("ChangeAni", CharacterAni.ATTACK3);
        }
        else if (currentTime - attack1Time <= 1f)
        {
            SendMessage("ChangeAni", CharacterAni.ATTACK2);
            attack2Time = currentTime;
        }
        else
        {
            SendMessage("ChangeAni", CharacterAni.ATTACK1);
            attack1Time = currentTime;
        }
            
        //}

        //else if (attackCount == 2)
        //{
        //    SendMessage("ChangeAni", CharacterAni.ATTACK2);
        //    currentAttackTime = transform.root.GetComponent<CharacterBattle>().gameController.GetComponent<TimeAttack>().currentTime;
        //}

        //else if (attackCount == 3)
        //{
        //    SendMessage("ChangeAni", CharacterAni.ATTACK3);
        //    currentAttackTime = transform.root.GetComponent<CharacterBattle>().gameController.GetComponent<TimeAttack>().currentTime;
        //    attackCount = 0;
        //}

        //attack 상태에서 멈춰있는 현상 발생 재생하는 애니메이션 시간 이후엔 무조건 풀리는 기능 추가 필요
        //attack success 되기 전에 입력 시 오류 발생
    }
}
