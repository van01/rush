using UnityEngine;
using System.Collections;

public class EnemyHitEffect : MonoBehaviour {

    private GameObject target;
    private float myAttackAniStopDelay = 0.06f;

    private int attackLightValue = 1;

    public void EnemyHitEffectActive()
    {
        target = GetComponent<EnemyAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");

        if (target.GetComponent<CharacterHandler>().assaultAddforce == true)
            target.SendMessage("CharacterAddForce", attackLightValue);
        else
            target.SendMessage("CharacterAddPosition");

        //StartCoroutine("MyAttackAniStop");    //해당 기능의 경우 Animator -> Animation 전환 과정에서 무의미해짐 (타격 타이밍 조정), 다시 구축해야 함
    }

    IEnumerator MyAttackAniStop()
    {
        SendMessage("AnimationStop");
        yield return new WaitForSeconds(myAttackAniStopDelay);
        SendMessage("AnimationPlay");
    }

    public void AttackLightValueSetting(int Value)
    {
        attackLightValue = Value;       // 스킬 효과 적용 시 세팅
    }

}
