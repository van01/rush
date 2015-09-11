using UnityEngine;
using System.Collections;

public class EffectMessenger : MonoBehaviour {

    public GameObject[] effectPrefab;

    public void EffectPlay()
    {
        for (int i = 0; effectPrefab.Length > i; i++)
        {
            effectPrefab[i].SendMessage("RealEffectPlay");
        }
    }

}
