using UnityEngine;
using System.Collections;

public class EmotionSimpleType : MonoBehaviour {

    public void EmotionEnd()
    {
        Destroy(transform.parent.gameObject);
    }
}
