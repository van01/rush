using UnityEngine;
using System.Collections;

public class MonsterAni : MonoBehaviour {

    public const int SPAWN = 1; // 스폰
    public const int IDLE = 2; // 스폰

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
