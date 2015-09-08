using UnityEngine;
using System.Collections;

public class EffectHandler_p_2 : MonoBehaviour {

    public GameObject bullet;

    public void BulletDestroyPass()
    {
        bullet.SendMessage("BulletDestroy");
    }
}
