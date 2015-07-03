using UnityEngine;
using System.Collections;

public class PlayerHitEffect : MonoBehaviour {

    private GameObject target;

    public void PlayerHitColorEffectActive()
    {
        target = GetComponent<PlayerAI>().GetCurrentTarget();

        target.SendMessage("CharacterHitOn");
    }

}
