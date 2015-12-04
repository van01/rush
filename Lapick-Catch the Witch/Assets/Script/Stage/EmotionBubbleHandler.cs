﻿using UnityEngine;
using System.Collections;

public class EmotionBubbleHandler : MonoBehaviour {

    public GameObject emotion01;

    public void EmotionBubbleAppearEnd()
    {
        emotion01.GetComponent<Animator>().SetInteger("aniNum", 1);
    }

    public void EmotionBubbleOutPlay()
    {
        GetComponent<Animator>().SetInteger("aniNum", 2);
    }

    public void EmotionEnd()
    {
        Destroy(transform.parent.gameObject);
    }
}