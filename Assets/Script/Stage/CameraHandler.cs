using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            c.GetComponent<BoxCollider2D>().isTrigger = false;
            c.GetComponent<Rigidbody2D>().gravityScale = 3f;


        }
    }

}
