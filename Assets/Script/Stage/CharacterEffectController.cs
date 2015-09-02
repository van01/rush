using UnityEngine;
using System.Collections;

public class CharacterEffectController : MonoBehaviour {
    public GameObject s_1;
    public GameObject a_1;
    private string rootName;

    protected bool skillOn;

    public void NormalAttackEffectRearOn(string sName)
    {
        rootName = sName;

        StartCoroutine("NormalAttackEffectWait");
    }

    IEnumerator NormalAttackEffectWait()
    {
        if (rootName == "Pawn")
        {
            yield return new WaitForSeconds(0.25f);
            s_1.SendMessage("EffectPlay");
            
        }
    }

    public void Skill01AttackEffectRearOn(string sName)
    {
        rootName = sName;

        StartCoroutine("Skill01AttackEffectWait");
    }

    IEnumerator Skill01AttackEffectWait()
    {
        if (rootName == "Pawn")
        {
            yield return new WaitForSeconds(0.4f);
            s_1.SendMessage("EffectPlay");
        }
    }

    public void NormalAttackEffectOn(Vector3 vHitPoint)
    {
        a_1.transform.position = vHitPoint;
        if (skillOn == true)
            a_1.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        else
            a_1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        a_1.SendMessage("EffectPlay");
    }

    public void ActiveSkillOn()
    {
        skillOn = true;
    }

    public void ActiveSkillOff()
    {
        skillOn = false;
    }
}
