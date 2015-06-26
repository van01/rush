using UnityEngine;
using System.Collections;

public class CharacterAni : MonoBehaviour {
	public const int SPAWN = 1;		//자기자리 찾아가기
	public const int IDLE = 2;		//대기
	public const int MOVE = 3;		//이동
	public const int RUN = 4;		//달리기
	public const int BATTLE = 5;	//전투
	public const int ATTACK = 6;	//공격
    public const int RUNATTACK = 7;		//달리기 공격
	public const int SKILL = 8;		//스킬
	public const int GUARD = 9;		//방어
	public const int BACK = 10;		//뒤로 이동
    public const int FOWARD = 11;		//앞으로 이동
	public const int DEAD = 12;		//죽음
	public const int JUMP = 13;		//점프 시작
	public const int MIDAIR = 14;	//공중
	public const int LANDING = 15;	//착지
	
	private Animator anim;
    private PlayerState tmpPlayerState;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
        tmpPlayerState = GetComponent<PlayerState>();
	}

    void Update()
    {
        AnimationStateCheck();
    }

	public void ChangeAni(int aniNum){
		anim.SetInteger("aniNumber", aniNum);
	}

    public void AnimationStateCheck()
    {
        if (tmpPlayerState.currentState == CharacterState.State.Back && anim.GetCurrentAnimatorStateInfo(0).nameHash != Animator.StringToHash("Base Layer.Back"))
            ChangeAni(BACK);
        if (tmpPlayerState.currentState == CharacterState.State.Guard && anim.GetCurrentAnimatorStateInfo(0).nameHash != Animator.StringToHash("Base Layer.Guard"))
            ChangeAni(GUARD);
    }
}
