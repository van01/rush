using UnityEngine;
using System.Collections;

public class PlayerHitEffect : MonoBehaviour {

    private GameObject target;
    private float myAttackAniStopValue = 0.06f;

    public void PlayerHitEffectActive()
    {
        target = GetComponent<PlayerAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");

        StartCoroutine("MyAttackAniStop");
    }

    IEnumerator MyAttackAniStop()
    {
        SendMessage("AnimationStop");
        yield return new WaitForSeconds(myAttackAniStopValue);
        SendMessage("AnimationPlay");
    }

}
