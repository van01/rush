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
    public const string FOWARD = "Foward_Baked";	//앞으로 이동
    public const string DEAD = "Die_Baked";		//죽음
    public const string JUMP = "Jump_Baked";		//점프 시작
    public const string MIDAIR = "Midair_Baked";	//공중
    public const string LANDING = "Landing_Baked";	//착지

    private PlayerState tmpPlayerState;
    private Animation tmpAnimation;

    private string currentAniClip;

    private bool attack = false;
    private bool skill = false;

    protected float attackSuccessDelay;

	// Use this for initialization
	void Awake () {
        tmpPlayerState = GetComponent<PlayerState>();
	}

    void Start()
    {
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
        if (aniClipName == ATTACK)
        {
            tmpAnimation.Play(aniClipName);

            //해당 기능 다른 곳으로 분리 필요
            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackDistanceType == PlayerAbility.attackDistanceType.melee || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackDistanceType == EnemyAbility.attackDistanceType.melee)
                StartCoroutine("AttackSuccessWait");
            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackDistanceType == PlayerAbility.attackDistanceType.longDistance || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackDistanceType == EnemyAbility.attackDistanceType.longDistance)
                SendMessage("LongDistanceLunchHandler");

            attack = true;
        }
        else if (aniClipName == SKILL)
        {
            tmpAnimation.Play(aniClipName, PlayMode.StopAll);

            if (tag == "Player" && GetComponent<PlayerAbility>().currentAttackDistanceType == PlayerAbility.attackDistanceType.melee || tag == "Enemy" && GetComponent<EnemyAbility>().currentAttackDistanceType == EnemyAbility.attackDistanceType.melee)
            {
                attackSuccessDelay = 0.5f;      //임시
                StartCoroutine("AttackSuccessWait");
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

    IEnumerator AttackSuccessWait()
    {
        yield return new WaitForSeconds(attackSuccessDelay);

        SendMessage("AttackSuccessCall");
    }

    public void AttackSuccessWaitStop()
    {
        StopCoroutine("AttackSuccessWait");
    }

    public void attackSuccessDelayValueSetting(float fAttackSuccessDelay)
    {
        attackSuccessDelay = fAttackSuccessDelay;
    }
}
