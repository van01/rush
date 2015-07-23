using UnityEngine;
using System.Collections;

public class EnemyHitEffect : MonoBehaviour {

    private GameObject target;
    private float myAttackAniStopDelay = 0.06f;

    public void EnemyHitEffectActive()
    {
        target = GetComponent<EnemyAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");

        StartCoroutine("MyAttackAniStop");
    }

    IEnumerator MyAttackAniStop()
    {
        SendMessage("AnimationStop");
        yield return new WaitForSeconds(myAttackAniStopDelay);
        SendMessage("AnimationPlay");
    }
}
