using UnityEngine;
using System.Collections;

public class EffectHandler_m_2_p : MonoBehaviour {

    Animator animator;
    public bool isSpriteRenderer;

    public GameObject tmpParent;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (isSpriteRenderer != true)
            GetComponent<MeshRenderer>().sortingLayerName = "Effect";
    }

    public void RealEffectSetting(int i)
    {
        animator.SetInteger("effType", i); 
    }

    public void EffectStop()
    {
        animator.SetInteger("effectOn", 0);
    }
    public void EffectDestroy()
    {
        Destroy(gameObject);
        if (tmpParent != null)
            tmpParent.SendMessage("CompletDestroy");
    }

}
