using UnityEngine;
using System.Collections;

public class PlayerHitEffect : MonoBehaviour {

    private GameObject target;
    private float myAttackAniStopValue = 0.06f;

    public void PlayerHitEffectActive()
    {
        target = GetComponent<PlayerAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");

        //StartCoroutine("MyAttackAniStop");    //해당 기능의 경우 Animator -> Animation 전환 과정에서 무의미해짐 (타격 타이밍 조정), 다시 구축해야 함
    }

    IEnumerator MyAttackAniStop()
    {
        SendMessage("AnimationStop");
        yield return new WaitForSeconds(myAttackAniStopValue);
        SendMessage("AnimationPlay");
    }

}
