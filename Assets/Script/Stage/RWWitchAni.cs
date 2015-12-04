using UnityEngine;
using System.Collections;

public class RWWitchAni : MonoBehaviour
{

    public const int SIT = 0;
    public const int IDLE = 1;
    public const int OUT = 2;
    public const int RUN = 3;

    private Animator tmpAnimator;

    void Awake()
    {
        tmpAnimator = GetComponent<Animator>();
    }

    public void ChangeAni(int aniNumber)
    {
        tmpAnimator.SetInteger("nAniNumber", aniNumber);
    }
}
