using UnityEngine;
using System.Collections;

public class EggBasket : MonoBehaviour {

    public GameObject[] eggObjectArray;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetInteger("AniNumber", 0);
    }

    public void CurrentEggItchy()
    {
        animator.SetInteger("AniNumber", 1);
    }

    public void CurrentEggEnd()
    {
        animator.SetInteger("AniNumber", 2);
    }

    public void CurrentEggItchyEnd()
    {
        animator.SetInteger("AniNumber", 0);
    }
}
