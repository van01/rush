using UnityEngine;
using System.Collections;

public class EffectHandler_p_2 : MonoBehaviour {

    public GameObject bullet;

    void Start()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "Effect";
    }

    public void BulletDestroyPass()
    {
        bullet.SendMessage("BulletDestroy");
    }
}
