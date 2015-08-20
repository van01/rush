using UnityEngine;
using System.Collections;

public class CharacterAni : MonoBehaviour {
    //public const int SPAWN = 1;		//자기자리 찾아가기
    //public const int IDLE = 2;		//대기
    //public const int MOVE = 3;		//이동
    //public const int RUN = 4;		//달리기
    //public const int BATTLE = 5;	//전투
    //public const int ATTACK = 6;	//공격
    //public const int RUNATTACK = 7;	//달리기 공격
    //public const int SKILL = 8;		//스킬
    //public const int GUARD = 9;		//방어
    //public const int BACK = 10;		//뒤로 이동
    //public const int FOWARD = 11;	//앞으로 이동
    //public const int DEAD = 12;		//죽음
    //public const int JUMP = 13;		//점프 시작
    //public const int MIDAIR = 14;	//공중
    //public const int LANDING = 15;	//착지

    public const string SPAWN = "Spawn_Baked";		//자기자리 찾아가기
    public const string IDLE = "Idle_Baked";		//대기
    public const string MOVE = "Move_Baked";		//이동
    public const string RUN = "Run_Baked";		//달리기
    public const string BATTLE = "Battle_Baked";	//전투
    public const string ATTACK = "Attack01_Baked";	//공격
    public const string RUNATTACK = "RunAttack_Baked";	//달리기 공격
    public const string SKILL = "Skill_Baked";		//스킬
    public const string GUARD = "Guard_Baked";		//방어
    public const string BACK = "Back_Baked";		//뒤로 이동
    public const string FOWARD = "Foward_Baked";	//앞으로 이동
    public const string DEAD = "Die_Baked";		//죽음
    public const string JUMP = "Jump_Baked";		//점프 시작
    public const string MIDAIR = "Midair_Baked";	//공중
    public const string LANDING = "Landing_Baked";	//착지
	
	private Animator anim;
    private PlayerState tmpPlayerState;
    private Animation tmpAnimation;

    private bool attackAni = false;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
        tmpPlayerState = GetComponent<PlayerState>();
	}

    void Start()
    {
        tmpAnimation = GetComponent<Animation>();
        
    }

    void Update()
    {
        //if (CompareTag("Player"))
        //{
        //    AnimationStateCheck();
        //}
        if (attackAni == true)
        {
            if (tmpAnimation.isPlaying == false)
            {
                SendMessage("AttackEnd");
                attackAni = false;
            }
        }
    }
    

    //public void ChangeAni(int aniNum){
    //    anim.SetInteger("aniNumber", aniNum);
    //    if (aniNum == ATTACK)
    //    {
    //        int i = (int)Random.RandomRange(1.0f, 3.0f);
    //        anim.SetInteger("attNumber", i);
    //    }
    //}

    public void ChangeAni(string aniClipNum)
    {
        if (aniClipNum == ATTACK)
        {
            attackAni = true;
            tmpAnimation.Play(aniClipNum);
        }

        tmpAnimation.CrossFade(aniClipNum);

        //anim.SetInteger("aniNumber", aniClipNum);
        //if (aniNum == ATTACK)
        //{
        //    int i = (int)Random.RandomRange(1.0f, 3.0f);
        //    anim.SetInteger("attNumber", i);
        //}
    }

    public void AttackAniInit()
    {
        anim.SetInteger("attNumber", 0);
    }

    public void AnimationStateCheck()
    {
        if (tmpPlayerState.currentState == CharacterState.State.Back && anim.GetCurrentAnimatorStateInfo(0).nameHash != Animator.StringToHash("Base Layer.Back"))
            ChangeAni(BACK);
        if (tmpPlayerState.currentState == CharacterState.State.Guard && anim.GetCurrentAnimatorStateInfo(0).nameHash != Animator.StringToHash("Base Layer.Guard"))
            ChangeAni(GUARD);
        if (tmpPlayerState.currentState == CharacterState.State.Attack && anim.GetCurrentAnimatorStateInfo(0).nameHash != Animator.StringToHash("Base Layer.Attack01"))
            ChangeAni(ATTACK);
    }

    public void AnimationStop()
    {
        anim.speed = 0.1f;
    }

    public void AnimationPlay()
    {
        anim.speed = 1.0f;
    }
}
