using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RWHelmetRaffleTreasureBoxHandler : MonoBehaviour {

    public GameObject treasureBoxBody;
    public GameObject treasureBoxTop;

    public Sprite[] treasureBoxBodySprite;
    public Sprite[] treasureBoxTopSprite;

    public GameObject openEffect;

    private Animator animator;
    private Animator openEffectAnimator;

    private Image currentTreasureBoxBodyImage;
    private Image currenttreasureBoxTopImage;

    void Start()
    {
        animator = GetComponent<Animator>();
        openEffectAnimator = openEffect.GetComponent<Animator>();

        currentTreasureBoxBodyImage = treasureBoxBody.GetComponent<Image>();
        currenttreasureBoxTopImage = treasureBoxTop.GetComponent<Image>();

        TreasureBoxInitialize();
    }

    public void AttackButtonEndDelivery()
    {
        transform.parent.SendMessage("AttackButtonEnd");
        //TreasureBoxInitialize();
    }

    public void TreasureBoxHit()
    {
        animator.SetInteger("aniNumber", 1);
    }

    public void TreasureBoxHitEnd()
    {
        animator.SetInteger("aniNumber", 0);
    }

    public void TreasureBoxOpen()
    {
        animator.SetInteger("aniNumber", 2);
        
    }

    public void TreasureBoxInitialize()
    {
        int treasureBoxNumber = (int)Random.RandomRange(0, treasureBoxBodySprite.Length);

        currentTreasureBoxBodyImage.sprite = treasureBoxBodySprite[treasureBoxNumber];
        currenttreasureBoxTopImage.sprite = treasureBoxTopSprite[treasureBoxNumber];

        animator.SetInteger("aniNumber", 0);
        openEffectAnimator.SetInteger("effectOn", 0);
    }

    public void WhitePanelEffectActiveOn()
    {
        transform.parent.transform.parent.SendMessage("WhitePanelEffectActiveDelivery", transform);
    }

    public void TreasureBoxOpenEffectOn()
    {
        openEffectAnimator.SetInteger("effectOn", 1);
    }
}
