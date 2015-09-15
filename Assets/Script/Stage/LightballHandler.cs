using UnityEngine;
using System.Collections;

public class LightballHandler : MonoBehaviour {

    private bool isFlying = false;
    private bool attackProssible = false;

    public GameObject[] light;
    public GameObject ball;
    public GameObject ring;

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

        for(int i = 0; i < light.Length; i++){
            light[i].SendMessage("RealEffectSetting", 1);
        }
        ball.SendMessage("RealEffectSetting", 2);
        ring.SendMessage("RealEffectSetting", 3);

        //animator.SetInteger("effectOn", 1);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 2.0f));
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(10.0f);
        LightballDestroy(); // 임시
    }

    void LightballDestroy()
    {
        for (int i = 0; i < light.Length; i++)
        {
            light[i].SendMessage("EffectStop");
        }
        ball.SendMessage("EffectStop");
        ring.SendMessage("EffectStop");
    }

    public void CompletDestroy()
    {
        Destroy(gameObject);
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

                LightballDestroy(); // 임시
            }
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
