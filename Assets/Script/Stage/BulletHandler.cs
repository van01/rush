using UnityEngine;
using System.Collections;

public class BulletHandler : MonoBehaviour {

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

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3.0f);
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

                gameObject.transform.parent.transform.parent.GetComponent<PlayerBattle>().AttackSuccess();
                attackProssible = false;
            }
        }
    }
}
