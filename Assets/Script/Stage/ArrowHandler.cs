using UnityEngine;
using System.Collections;

public class ArrowHandler : MonoBehaviour {

    private bool isFlying = false;
    private bool attackProssible = false;

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
    }

	void Update () {
        if (isFlying == true)
        {
            transform.Rotate(new Vector3(0, 0, -2.8f));
        }
	}

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    public void FlyingOn()
    {
        StartCoroutine("FlyingOnWait");
        attackProssible = true;
    }

    IEnumerator FlyingOnWait()
    {
        yield return new WaitForSeconds(0.2f);
        isFlying = true;
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
        if(c.tag == "Enemy")
        {
            if (attackProssible == true)
            {
                isFlying = false;

                GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //GetComponent<Rigidbody2D>().angularVelocity = Vector2.zero;

                gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackSuccess();
                attackProssible = false;
            }
        }
    }
}
