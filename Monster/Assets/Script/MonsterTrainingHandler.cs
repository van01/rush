using UnityEngine;
using System.Collections;

public class MonsterTrainingHandler : MonoBehaviour {

	public void TrainingAttackSuccess()
    {
        transform.root.SendMessage("AttackSuccess");
    }
}
