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
        Rotate,
        None,
    }

    public projectileType currentProjectileType;

    void Start()
    {
        StartCoroutine("AutoDestroy");

        //if (currentlaunchForce == launchForce.Player)
        //    tag = "Player";
        //else if (currentlaunchForce == launchForce.Enemy)
        //    tag = "Enemy";

        animator = GetComponent<Animator>();

        GetComponent<MeshRenderer>().sortingLayerName = "Effect";

    }

    void Update()
    {
        //if (currentProjectileType == projectileType.Rotate)
        //{
        //    if (isFlying == true)
        //    {
        //        transform.Rotate(new Vector3(0, 0, angleRotateValue));
        //    }
        //}
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

        animator.SetInteger("effectOn", 2);
    }

    public void ArrowDestroy()
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
        if (c.tag == "Enemy")
        {
            if (attackProssible == true)
            {
                isFlying = false;

                GetComponent<MeshRenderer>().sortingLayerName = "Default";

                Rigidbody2D tmpRigidbody2D = GetComponent<Rigidbody2D>();
                BoxCollider2D tmpBoxCollider2D = GetComponent<BoxCollider2D>();

                Destroy(tmpRigidbody2D);
                Destroy(tmpBoxCollider2D);

                transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(0.1f, 0.3f), 0);

                gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackSuccess();

                transform.SetParent(c.transform);
                attackProssible = false;
            }
        }

        else if (c.tag == "Player")
        {
            if (attackProssible == true)
            {
                isFlying = false;

                GetComponent<MeshRenderer>().sortingLayerName = "Default";

                Rigidbody2D tmpRigidbody2D = GetComponent<Rigidbody2D>();
                BoxCollider2D tmpBoxCollider2D = GetComponent<BoxCollider2D>();

                Destroy(tmpRigidbody2D);
                Destroy(tmpBoxCollider2D);

                transform.position = new Vector3(transform.position.x, transform.position.y - Random.Range(0.1f, 0.3f), 0);

                gameObject.transform.parent.transform.parent.GetComponent<EnemyBattle>().AttackSuccess();

                transform.SetParent(c.transform);
                attackProssible = false;
            }
        }

        else if (LayerMask.LayerToName(c.gameObject.layer) == "Floor")
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
}
