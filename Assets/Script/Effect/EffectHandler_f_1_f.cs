using UnityEngine;
using System.Collections;

public class EffectHandler_f_1_f : MonoBehaviour {

    Animator animator;
    public bool isSpriteRenderer;

    public GameObject tmpParent;

    int i = 0;

    void Awake()
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
        if (tmpParent == null)
            Destroy(gameObject);
        else
            tmpParent.SendMessage("DestroyProjectile");
    }
        
}
