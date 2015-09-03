using UnityEngine;
using System.Collections;

public class CharacterEffectController : MonoBehaviour {
    public GameObject s_1;
    public GameObject a_1;
    private string WeaponType;

    protected bool skillOn;

    public void NormalAttackEffectRearOn(string sWeaponType)
    {
        WeaponType = sWeaponType;

        StartCoroutine("NormalAttackEffectWait");
    }

    IEnumerator NormalAttackEffectWait()
    {
        if (WeaponType == "Sword")
        {
            yield return new WaitForSeconds(0.25f);
            s_1.SendMessage("EffectPlay");
        }

        if (WeaponType == "Spear")
        {
            yield return new WaitForSeconds(0.5f);
            s_1.SendMessage("EffectPlay");
        }
    }

    public void Skill01AttackEffectRearOn(string sWeaponType)
    {
        WeaponType = sWeaponType;

        StartCoroutine("Skill01AttackEffectWait");
    }

    IEnumerator Skill01AttackEffectWait()
    {
        if (WeaponType == "Sword")
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

    public void BaseAttackEffectRotate()
    {
        a_1.SendMessage("BaseAttackEffectRandomRotate");
    }
}
