using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {

	private Transform target;
	private float attackDistance = 1.5f;
	private GameObject[] arrMonsters;

	private GameObject tmpGameController;
	
	void Update(){					//틱 추가 후 교체 필요
		CheckDistanceFromTarget();
	}

	void Start(){
		tmpGameController = GameObject.Find("GameController");
	}

	public void SearchEnemy(){
		arrMonsters = GameObject.FindGameObjectsWithTag("Enemy");

		if(arrMonsters != null && arrMonsters.Length > 0){
			float shortDist = Vector3.Distance(transform.position, arrMonsters[0].transform.position);

			target = arrMonsters[0].transform;

			if (arrMonsters.Length > 1){
				for (int i = 1; i < arrMonsters.Length; i++){
					float distance = Vector3.Distance(transform.position, arrMonsters[i].transform.position);

					if (distance < shortDist){
						shortDist = distance;
						target = arrMonsters[i].transform;
					}
				}
			}
		}
	}

	void CheckDistanceFromTarget(){
		if (target == null){
			SendMessage("CharacterStateMoveOn");
			return;
		}

		PlayerState tmpPlayerState = GetComponent<PlayerState>();

		if (tmpPlayerState.currentState == CharacterState.State.Move || tmpPlayerState.currentState == CharacterState.State.Run){
			float distance = Vector3.Distance(target.position, transform.position);

			if (distance < attackDistance){
				SendMessage("CharacterStateBattleOn");
				SendMessage("GameStateHoldOn");
			}
		}
	}

	public GameObject GetCurrentTarget(){
		return target.gameObject;
	}
}
