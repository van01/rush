using UnityEngine;
using System.Collections;

public class CharacterBattle : MonoBehaviour {

    public GameObject gameController;
    protected int attackActionCount;

    PlayerParams currentPlayerParams;
    EnemyParams currentEnemyParams;

    public void StartBattle()
    {
        currentPlayerParams = GetComponent<PlayerAbility>().GetParams();
        currentEnemyParams = GetComponent<PlayerAI>().target.GetComponent<EnemyAbility>().GetParams();
    }

    public void AttackSuccess()
    {
        //call count에 따라 1회 공격 후 판정, 판정 후 다음 공격, idle로 이동
        attackActionCount++;
        if (attackActionCount == 1)
        {
            currentEnemyParams.curHP -= currentPlayerParams.attack; //임시 공격
            gameController.SendMessage("CharacterInfoUpdate");
        }
    }

    public void AttackEnd()
    {
        attackActionCount = 0;

        GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().currentState = CharacterState.State.Idle;
        GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().CheckCharacterState();

        GetComponent<PlayerControllerHandler>().currentPlayer.transform.localPosition = new Vector3(0, -1, 0);
        //백업 후 초기화하는 형태로 변경 필요

        GetComponent<PlayerAI>().isAttackAble = true;
    }
}
