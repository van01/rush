using UnityEngine;
using System.Collections;

public class CharacterAttackHandler : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (transform.root.GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().currentState == CharacterState.State.Attack)
        {
            if (other.transform.tag == "Enemy")
            {
                transform.root.SendMessage("AttackSuccess");
            }
        }
    }
}
