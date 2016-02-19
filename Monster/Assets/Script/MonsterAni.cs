using UnityEngine;
using System.Collections;

public class MonsterAni : MonoBehaviour {

    public const int SPAWN = 1; // 스폰
    public const int IDLE = 2; // 스폰
    public const int MOVE = 3; // 이동
    public const int ATTACK = 4; // 공격
    public const int ATTACKWAIT = 5; // 공격대기

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeAni(int aniClipName)
    {
        _animator.SetInteger("aniNumber", aniClipName);
    }
}
