using UnityEngine;
using System.Collections;

public class CharacterAni : MonoBehaviour {
	public const int SPAWN = 1;		//자기자리 찾아가기
	public const int IDLE = 2;		//대기
	public const int MOVE = 3;		//이동
	public const int RUN = 4;		//달리기
	public const int BATTLE = 5;	//전투
	public const int ATTACK = 6;	//공격
	public const int SKILL = 7;		//스킬
	public const int GUARD = 8;		//방어
	public const int BACK = 9;		//뒤로 이동
	public const int DEAD = 10;		//죽음
	public const int JUMP = 11;		//점프 시작
	public const int MIDAIR = 12;	//공중
	public const int LANDING = 13;	//착지
	
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	public void ChangeAni(int aniNum){
		anim.SetInteger("aniNumber", aniNum);
	}
}
