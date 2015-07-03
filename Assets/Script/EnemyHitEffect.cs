using UnityEngine;
using System.Collections;

public class EnemyHitEffect : MonoBehaviour {

    private GameObject target;

    public void EnemyHitColorEffectActive()
    {
        target = GetComponent<EnemyAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");
    }
}
