using UnityEngine;
using System.Collections;

public class CharacterAni : MonoBehaviour {

    public const int IDLE       = 0;	//대기
    public const int SPAWN      = 1;	//시작
    public const int RUN        = 2;	//달리기
    public const int DASH       = 3;	//대쉬
    public const int DEAD       = 4;	//죽음
    public const int DISORDER   = 5;	//상태이상
    public const int ROLL       = 6;	//구르기
    public const int ATTACK1    = 7;	//공격1
    public const int ATTACK2    = 8;	//공격2
    public const int ATTACK3    = 9;	//공격3
    public const int SKILL      = 10;   //스킬

    public bool isAttackAniPlay;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAni(int aniNum)
    {
        animator.SetInteger("aniNumber", aniNum);

    }

    public void AttackEndDelivery()
    {
        if (transform.root.tag == "Player")
        {
            transform.root.GetComponent<CharacterBattle>().AttackEnd();
        }
    }

    public void AttackAniPlayCheck()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Punch0")) isAttackAniPlay = true;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Punch1")) isAttackAniPlay = true;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Punch2")) isAttackAniPlay = true;
        else isAttackAniPlay = false;
    }
}
