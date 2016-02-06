using UnityEngine;
using System.Collections;

public class TimeAttack : MonoBehaviour {

    public float prevTime;  //실제 전투 시간 측정을 위한 이전 플레이 타임 전달
    public float currentTime;

    void Update()
    {
        currentTime = Time.time - prevTime;
    }
}
