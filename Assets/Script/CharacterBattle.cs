using UnityEngine;
using System.Collections;

public class CharacterBattle : MonoBehaviour {

	protected float attackDelay = 3.0f;

	protected PlayerParams playerParams;
	protected EnemyParams enemyParams;

	protected CharacterState myState;

	public virtual void StartBattle(){

	}

	public virtual void DoBattle(){

	}
}
