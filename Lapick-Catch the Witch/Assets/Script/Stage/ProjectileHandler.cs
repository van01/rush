using UnityEngine;
using System.Collections;

public class ProjectileHandler : MonoBehaviour {
    private bool isFlying = false;
    private bool attackProssible = false;

    protected float angleRotateValue;
    protected float flyingOnDylay;

    Animator animator;

    public enum launchForce
    {
        Player,
        Enemy,
    }

    public launchForce currentlaunchForce;

    public enum projectileType
    {
        Arrow,
        LightBall,
        None,
    }

    public projectileType currentProjectileType;

    public GameObject afterEffect;
    public GameObject explosion;

    public bool spriteRenderer;

    public GameObject[] light;
    public GameObject ball;
    public GameObject ring;

    void Start()
    {
        StartCoroutine("AutoDestroy");

        //if (currentlaunchForce == launchForce.Player)
        //    tag = "Player";
        //else if (currentlaunchForce == launchForce.Enemy)
        //    tag = "Enemy";

        animator = GetComponent<Animator>();

        if (currentProjectileType != projectileType.LightBall)
        {
            if (spriteRenderer == true)
                animator.SetInteger("effectOn", 1);
            else
                GetComponent<MeshRenderer>().sortingLayerName = "Effect";
        }
        
        if (afterEffect != null)
            afterEffect.GetComponent<Animator>().SetInteger("effectOn", 1);

        if (currentProjectileType == projectileType.LightBall)
        {
            for (int i = 0; i < light.Length; i++)
            {
                light[i].SendMessage("RealEffectSetting", 1);
            }
            ball.SendMessage("RealEffectSetting", 2);
            ring.SendMessage("RealEffectSetting", 3);
        }
    }

    void Update()
    {
        if (currentProjectileType == projectileType.LightBall)
        {
            transform.Rotate(new Vector3(0, 0, 2.0f));
        }
    }

    public void RotateValue(float fRotateValue)
    {
        angleRotateValue = 6.0f - fRotateValue;
        if (angleRotateValue <= 3.0f)
            angleRotateValue = 3.0f;

        angleRotateValue = angleRotateValue * -1f;
        flyingOnDylay = fRotateValue * 0.1f;
        if (flyingOnDylay >= 0.5f)
            flyingOnDylay = 0.5f;
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3.0f);
    
        if (afterEffect != null)
            afterEffect.GetComponent<Animator>().SetInteger("effectOn", 2);

        if (currentProjectileType == projectileType.LightBall)
            LightballDestroy();

        if (spriteRenderer == true)
            StartCoroutine("SpriteDestroy");
        else
            animator.SetInteger("effectOn", 2);      
    }

    public void ArrowDestroy()
    {
        DestroyProjectile();
    }

    public void CompletDestroy()
    {
        DestroyProjectile();
    }

    public void BulletDestroy()
    {
        //if (explosion == null)
            DestroyProjectile();
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

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public void FlyingOn()
    {
        StartCoroutine("FlyingOnWait");
        attackProssible = true;
    }

    IEnumerator FlyingOnWait()
    {
        yield return new WaitForSeconds(flyingOnDylay);
        isFlying = true;

        for (float i = 1; i >= 0; i -= 0.03f)
        {
            if (isFlying == true)
            {
                transform.Rotate(new Vector3(0, 0, angleRotateValue));
                yield return new WaitForFixedUpdate();
            }
        }   
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
        if (c.tag == "Enemy" && currentlaunchForce == launchForce.Player)
        {
            if (attackProssible == true)
            {
                isFlying = false;

                if (spriteRenderer != true && currentProjectileType != projectileType.LightBall)
                    GetComponent<MeshRenderer>().sortingLayerName = "Default";

                Rigidbody2D tmpRigidbody2D = GetComponent<Rigidbody2D>();
                BoxCollider2D tmpBoxCollider2D = GetComponent<BoxCollider2D>();

                Destroy(tmpRigidbody2D);
                Destroy(tmpBoxCollider2D);

                if (currentProjectileType == projectileType.Arrow)
                    transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(0.1f, 0.3f), 0);
                if (currentProjectileType == projectileType.None)
                    transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);

                gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackSuccess();

                transform.SetParent(c.transform);
                attackProssible = false;

                if (afterEffect == true)
                    afterEffect.GetComponent<Animator>().SetInteger("effectOn", 2);

                if (explosion != null)
                    explosion.SendMessage("RealEffectPlay");

                if (spriteRenderer == true)
                    StartCoroutine("SpriteDestroy");

                if (currentProjectileType == projectileType.LightBall)
                    LightballDestroy();
                else 
                    animator.SetInteger("effectOn", 2);
            }
        }

        else if (c.tag == "Player" && currentlaunchForce == launchForce.Enemy)
        {
            if (attackProssible == true)
            {
                isFlying = false;

                if (spriteRenderer != true && currentProjectileType != projectileType.LightBall)
                    GetComponent<MeshRenderer>().sortingLayerName = "Default";

                Rigidbody2D tmpRigidbody2D = GetComponent<Rigidbody2D>();
                BoxCollider2D tmpBoxCollider2D = GetComponent<BoxCollider2D>();

                Destroy(tmpRigidbody2D);
                Destroy(tmpBoxCollider2D);

                if (currentProjectileType == projectileType.Arrow)
                    transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(0.1f, 0.3f), 0);
                if (currentProjectileType == projectileType.None)
                    transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, 0);

                gameObject.transform.parent.transform.parent.GetComponent<EnemyBattle>().AttackSuccess();

                transform.SetParent(c.transform);
                attackProssible = false;

                if (afterEffect == true)
                    afterEffect.GetComponent<Animator>().SetInteger("effectOn", 2);

                if (explosion != null)
                    explosion.SendMessage("RealEffectPlay");

                if (spriteRenderer == true)
                    StartCoroutine("SpriteDestroy");

                if (currentProjectileType == projectileType.LightBall)
                    LightballDestroy();
                else 
                    animator.SetInteger("effectOn", 2);
            }
        }

        else if (LayerMask.LayerToName(c.gameObject.layer) == "Floor" && currentProjectileType != projectileType.LightBall)
        {
            if (attackProssible == true)
            {
                isFlying = false;

                Rigidbody2D tmpRigidbody2D = GetComponent<Rigidbody2D>();
                BoxCollider2D tmpBoxCollider2D = GetComponent<BoxCollider2D>();

                Destroy(tmpRigidbody2D);
                Destroy(tmpBoxCollider2D);

                transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(0.1f, 0.1f), 0);

                if (tag == "Player")
                    gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackFail();
                else
                    gameObject.transform.parent.transform.parent.GetComponent<EnemyBattle>().AttackFail();

                transform.SetParent(GameObject.FindGameObjectWithTag("Stage").GetComponent<StageScroll>().distanteA[GameObject.FindGameObjectWithTag("Stage").GetComponent<StageScroll>().distanteA.Length - 1].transform);
                attackProssible = false;
            }
        }
    }


    IEnumerator SpriteDestroy()
    {
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForFixedUpdate();
        }
    }
}
