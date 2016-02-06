using UnityEngine;
using System.Collections;

public class EnemySkillTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.root.SendMessage("EnemySkillPlayerHit");
        }
    }
}
