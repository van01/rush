using UnityEngine;
using System.Collections;

public class EffectHandler_a_1 : MonoBehaviour {

    Animator animator;
    public GameObject parent_a_1;

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
        if (parent_a_1 != null)
            parent_a_1.SendMessage("BaseAttackEffectRandomRotate");
    }
}
