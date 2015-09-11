using UnityEngine;
using System.Collections;

public class EffectHandler_f_1_f : MonoBehaviour {

    Animator animator;
    public bool isSpriteRenderer;

    public GameObject tmpParent;

    int i = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (isSpriteRenderer != true)
            GetComponent<MeshRenderer>().sortingLayerName = "Effect";
    }

    public void RealEffectPlay()
    {
        animator.SetInteger("effectOn", 1);
    }

    public void EffectStop()
    {
        animator.SetInteger("effectOn", 0);
    }

    public void DestroyProjectileActive()
    {
        tmpParent.SendMessage("DestroyProjectile");
    }
        
}
