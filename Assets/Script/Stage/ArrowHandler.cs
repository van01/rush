using UnityEngine;
using System.Collections;

public class ArrowHandler : MonoBehaviour {

    bool isFlying = false;

    void Start()
    {
        StartCoroutine("AutoDestroy");
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
    }

    IEnumerator FlyingOnWait()
    {
        yield return new WaitForSeconds(0.28f);
        isFlying = true;
    }
}
