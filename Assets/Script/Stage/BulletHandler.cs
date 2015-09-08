using UnityEngine;
using System.Collections;

public class BulletHandler : MonoBehaviour {

    private bool isFlying = false;
    private bool attackProssible = false;

    public GameObject afterEffect;
    private Animator afterEffectAnimator;

    public enum LunchForce
    {
        Player,
        Enemy,
    }

    public LunchForce currentLunchForce;

    void Start()
    {
        StartCoroutine("AutoDestroy");

        if (currentLunchForce == LunchForce.Player)
            tag = "Player";
        else if (currentLunchForce == LunchForce.Enemy)
            tag = "Enemy";

        //afterEffectAnimator = afterEffect.GetComponent<Animator>();

        afterEffect.GetComponent<Animator>().SetInteger("effectOn", 1);
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        BulletAfterEffectDestroyPlay();
    }

    public void BulletAfterEffectDestroyPlay()
    {
        afterEffect.GetComponent<Animator>().SetInteger("effectOn", 2);
    }

    public void BulletDestroy()
    {
        Destroy(gameObject);
    }

    public void FlyingOn()
    {
        isFlying = true;
        attackProssible = true;
    }
    
    public void LunchForceSetting(string sLunchForce)
    {
        if (sLunchForce == "Player")
            currentLunchForce = LunchForce.Player;
        else if (sLunchForce == "Enemy")
            currentLunchForce = LunchForce.Enemy;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            if (attackProssible == true)
            {
                isFlying = false;

                Rigidbody2D tmpRigidbody2D = GetComponent<Rigidbody2D>();
                BoxCollider2D tmpBoxCollider2D = GetComponent<BoxCollider2D>();

                Destroy(tmpRigidbody2D);
                Destroy(tmpBoxCollider2D);

                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);

                gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackSuccess();
                attackProssible = false;

                BulletAfterEffectDestroyPlay();
            }
        }
    }
}
