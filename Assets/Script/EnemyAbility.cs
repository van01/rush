using UnityEngine;
using System.Collections;

public class EnemyAbility : MonoBehaviour {

	EnemyParams myParams = new EnemyParams();
	
	public void SetParams(EnemyParams tParams){
		myParams = tParams;
	}
	
	public EnemyParams GetParams(){
		return myParams;
	}
}
