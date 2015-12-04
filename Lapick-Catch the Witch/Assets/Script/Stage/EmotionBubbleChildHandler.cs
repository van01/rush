using UnityEngine;
using System.Collections;

public class EmotionBubbleChildHandler : MonoBehaviour {

    public void EmotionEntityPlayEnd()
    {
        transform.parent.SendMessage("EmotionBubbleOutPlay");
        GetComponent<Animator>().SetInteger("aniNum", 2);
    }
}
