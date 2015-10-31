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
    public const string SKILL = "Skill01_Baked";		//스킬
    public const string GUARD = "Guard_Baked";		//방어
    public const string BACK = "Back_Baked";		//뒤로 이동
    public const string DOWN = "Down_Baked";	//눕기
    public const string DOWNMOVE = "Down_Front_Baked";	//눕기
    public const string DOWNBACK = "Down_Back_Baked";	//눕기
    public const string DEAD = "Die_Baked";		//죽음
    public const string JUMP = "Jump_Baked";		//점프 시작
    public const string MIDAIR = "Midair_Baked";	//공중
    public const string LANDING = "Landing_Baked";	//착지
    public const string Drop = "Drop_Baked";

    public const string RWPlay = "EmptyHanded_Move_Baked";
    public const string RWHold = "Hold_Baked";

    private PlayerState tmpPlayerState;
    private Animation tmpAnimation;

    private string currentAniClip;

    private bool attack = false;
    private bool skill = false;

    protected float attackSuccessDelay;
    private float aniSpeed;

	// Use this for initialization
	void Awake () {
        tmpPlayerState = GetComponent<PlayerState>();
        tmpAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        if (attack == true)
        {
            if (tmpAnimation.IsPlaying(ATTACK) == false)
            {
                SendMessage("AttackEnd");

                attack = false;
            }
        }
        else if (skill == true)
        {
            if (tmpAnimation.IsPlaying(SKILL) == false)
            {
                SendMessage("AttackEnd");

                skill = false;
            }
        }
    }
    
    public void ChangeAni(string aniClipName)
    {
        if (aniClipName == RWPlay)
        {
            tmpAnimation[aniClipName].speed = aniSpeed;
            tmpAnimation.Play(aniClipName);
        }
        else if (aniClipName == ATTACK)
        {
            tmpAnimation.Play(aniClipName);

            //해당 기능 다른 곳으로 분리 필요
            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackDistanceType == PlayerAbility.attackDistanceType.melee || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackDistanceType == EnemyAbility.attackDistanceType.melee)
                StartCoroutine("MeleeAttackSuccessWait");
            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackDistanceType == PlayerAbility.attackDistanceType.longDistance || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackDistanceType == EnemyAbility.attackDistanceType.longDistance)
                StartCoroutine("LongDistanceAttackSuccessWait");

            attack = true;
        }
        else if (aniClipName == SKILL)
        {
            tmpAnimation.Play(aniClipName, PlayMode.StopAll);

            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackDistanceType == PlayerAbility.attackDistanceType.melee || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackDistanceType == EnemyAbility.attackDistanceType.melee)
            {
                attackSuccessDelay = 0.5f;      //임시
                StartCoroutine("MeleeAttackSuccessWait");
            }
            skill = true;
        }

        else if (aniClipName == DEAD)
        {
            tmpAnimation.Play(aniClipName, PlayMode.StopAll);
        }

        else
        {
            tmpAnimation.CrossFade(aniClipName);
        }

        currentAniClip = aniClipName;
    }

    IEnumerator MeleeAttackSuccessWait()
    {
        yield return new WaitForSeconds(attackSuccessDelay);

        SendMessage("AttackSuccessCall");
    }

    IEnumerator LongDistanceAttackSuccessWait()
    {
        yield return new WaitForSeconds(attackSuccessDelay);

        SendMessage("LongDistancelaunchHandler");
    }

    public void AttackSuccessWaitStop()
    {
        StopCoroutine("AttackSuccessWait");
    }

    public void attackSuccessDelayValueSetting(float fAttackSuccessDelay)
    {
        attackSuccessDelay = fAttackSuccessDelay;
    }

    public void AniStop()
    {
        tmpAnimation.Stop();
    }

    public void RWPlayerCharacterAniSpeed(float nSpeed)
    {
        aniSpeed = nSpeed;
        if (currentAniClip != null)
            ChangeAni(currentAniClip);
    }
}
