using UnityEngine;
using System.Collections;

public class FireballHandler : MonoBehaviour {

    private bool isFlying = false;
    private bool attackProssible = false;

    public GameObject explosion;

    private Animator animator;

    public enum launchForce
    {
        Player,
        Enemy,
    }

    public launchForce currentlaunchForce;

    void Start()
    {
        StartCoroutine("AutoDestroy");

        if (currentlaunchForce == launchForce.Player)
        {
            tag = "Player";
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else if (currentlaunchForce == launchForce.Enemy)
            tag = "Enemy";

        //afterEffectAnimator = afterEffect.GetComponent<Animator>();

        animator = GetComponent<Animator>();
        animator.SetInteger("effectOn", 1);
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("FireballDestroy");
    }

    IEnumerator FireballDestroy()
    {
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForFixedUpdate();
        }

        
    }

    public void FlyingOn()
    {
        isFlying = true;
        attackProssible = true;
    }

    public void launchForceSetting(string slaunchForce)
    {
        if (slaunchForce == "Player")
            currentlaunchForce = launchForce.Player;
        else if (slaunchForce == "Enemy")
            currentlaunchForce = launchForce.Enemy;
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

                transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, 0);

                gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackSuccess();
                attackProssible = false;

                if (explosion != null)
                    explosion.SendMessage("RealEffectPlay");

                StartCoroutine("FireballDestroy");
            }
        }
    }

    public void DestroyProjectile(){
        Destroy(gameObject);
    }
}
