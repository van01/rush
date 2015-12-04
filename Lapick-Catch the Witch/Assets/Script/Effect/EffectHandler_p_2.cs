using UnityEngine;
using System.Collections;

public class EffectHandler_p_2 : MonoBehaviour {

    public GameObject tmpParent;

    void Start()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "Effect";
    }

    public void BulletDestroyPass()
    {
        tmpParent.SendMessage("BulletDestroy");
    }
}
