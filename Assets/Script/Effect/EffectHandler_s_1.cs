using UnityEngine;
using System.Collections;

public class EffectHandler_s_1 : MonoBehaviour {

    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<MeshRenderer>().sortingLayerName = "Effect";
    }

    public void EffectPlay()
    {
        animator.SetInteger("effectOn", 1);
    }

    public void EffectStop()
    {
        animator.SetInteger("effectOn", 2);
    }
}
