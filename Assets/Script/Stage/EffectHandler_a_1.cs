using UnityEngine;
using System.Collections;

public class EffectHandler_a_1 : MonoBehaviour {

    Animator animator;

    int i = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RealEffectPlay()
    {
        animator.SetInteger("effectOn", (int)Random.RandomRange(1,5));
    }

    public void EffectStop()
    {
        animator.SetInteger("effectOn", 0);
    }
}
