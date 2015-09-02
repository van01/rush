using UnityEngine;
using System.Collections;

public class PlayerHitEffect : MonoBehaviour {

    private GameObject target;
    private float myAttackAniStopValue = 0.06f;

    private int attackLightValue = 5;

    public void PlayerHitEffectActive()
    {
        target = GetComponent<PlayerAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");

        if (target.GetComponent<CharacterHandler>().assaultAddforce == true)
        {
            if (target.GetComponent<CharacterHandler>().assaultName == name)
                target.SendMessage("CharacterAddForce", attackLightValue);
        }
        else
            target.SendMessage("CharacterAddPosition");

        //StartCoroutine("MyAttackAniStop");    //해당 기능의 경우 Animator -> Animation 전환 과정에서 무의미해짐 (타격 타이밍 조정), 다시 구축해야 함
    }

    IEnumerator MyAttackAniStop()
    {
        SendMessage("AnimationStop");
        yield return new WaitForSeconds(myAttackAniStopValue);
        SendMessage("AnimationPlay");
    }

    public void AttackLightValueSetting(int Value)
    {
        attackLightValue = Value;       // 스킬 효과 적용 시 세팅
    }
}
