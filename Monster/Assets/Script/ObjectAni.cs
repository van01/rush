using UnityEngine;
using System.Collections;

public class ObjectAni : MonoBehaviour {

    public const int IDLE = 1; //대기
    public const int HIT = 2; //피격
    public const int END = 3; //종료

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
