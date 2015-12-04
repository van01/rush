using UnityEngine;
using System.Collections;

public class EffectMessenger_a_1 : MonoBehaviour
{
    public GameObject a_1_0;
    public GameObject a_1_60;
    public GameObject a_1_120;
    public GameObject a_1_180;
    public GameObject a_1_240;
    public GameObject a_1_300;

    public void EffectPlay(){
        a_1_0.SendMessage("RealEffectPlay");
        a_1_60.SendMessage("RealEffectPlay");
        a_1_120.SendMessage("RealEffectPlay");
        a_1_180.SendMessage("RealEffectPlay");
        a_1_240.SendMessage("RealEffectPlay");
        a_1_300.SendMessage("RealEffectPlay");
    }

    public void BaseAttackEffectRandomRotate()
    {
        float randomZ = Random.RandomRange(0.0f, 60.0f);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, randomZ);
    }
}
