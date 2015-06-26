using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {

	public float attackDistance = 1.5f;
	public float positionDistance = 0f;
    public float backStepSpeed = 4.0f;
    public float fowardStepSpeed = 4.0f;

	private float setPositionTime;

	private Transform target;
	private GameObject[] arrMonsters;

	private GameObject tmpGameController;
	private bool setPosition = false;
	private bool backSetPosition = false;
	private bool fowardSetPosition = false;
	private float setPositionSpeed;

    private float tmpPositionDistance;
    private PlayerState tmpPlayerState;

    private bool attDistance = true;

    void Start()
    {
        tmpPlayerState = GetComponent<PlayerState>();
        tmpGameController = GameObject.Find("GameController");
    }

	void Update(){					//틱 추가 후 교체 필요
		CheckDistanceFromTarget();
		//캐릭터 기본 위치 잡기
        if (tmpPlayerState.currentState == CharacterState.State.Spawn || tmpPlayerState.currentState == CharacterState.State.Move)
        {
            if (setPosition == true)
            {
                if (transform.position.x <= positionDistance)
                {
                    transform.Translate(Time.deltaTime * setPositionSpeed, 0, 0);
                }
                else if (transform.position.x >= positionDistance - 0.1f)
                {
                    setPosition = false;
                    transform.position = new Vector3(positionDistance, 0, 0);
                    SendMessage("CharacterStateMoveOn");
                    SendMessage("CharacterStateControll", "Move");
                    tmpGameController.SendMessage("GameStateControll", "Playing");
                }
            }
        }

		//캐릭터 백스탭 위치 잡기
		if (backSetPosition == true){
            if (transform.position.x >= -7.0f) { 
                transform.Translate(-Time.deltaTime * backStepSpeed, 0, 0);
            }
		}

		//캐릭터 태클 위치 잡기
		if (fowardSetPosition == true){
            if (transform.position.x <= 7.0f)
            {
                transform.Translate(Time.deltaTime * fowardStepSpeed, 0, 0);
            }
		}
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
			//SendMessage("CharacterStateMoveOn");      //업데이트 마다 무브를 걸어주니 오류생김
			return;
		}


        if (tmpPlayerState.currentState == CharacterState.State.Move || tmpPlayerState.currentState == CharacterState.State.Run)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance < attackDistance)
            {
                attDistance = true;
            }
            else if (distance > attackDistance)
            {
                attDistance = false;
            }

            if (attDistance == true)
            {
                SendMessage("CharacterStateBattleOn");
                tmpPositionDistance = positionDistance;
                positionDistance = transform.position.x;
            }
        }

        if(tmpPlayerState.currentState == CharacterState.State.Back)
        {
            attDistance = false;
        }
	}

	public GameObject GetCurrentTarget(){
		return target.gameObject;
	}

	public void CharacterPositionInialize(float f){
		setPosition = true;
		setPositionTime = f;
        
		setPositionSpeed = (positionDistance - transform.position.x)/setPositionTime;
		CharacterBackPositionOff();
		CharacterFowardPositionOff();
	}

	public void CharacterBackPositionOn(){
		backSetPosition = true;
        setPosition = false;
	}

	public void CharacterBackPositionOff(){
		backSetPosition = false;
        setPosition = true;
	}

	public void CharacterFowardPositionOn(){
		fowardSetPosition = true;
        setPosition = false;
	}
	
	public void CharacterFowardPositionOff(){
		fowardSetPosition = false;
        setPosition = true;
	}

    public void PositionDistanceReset()
    {
        positionDistance = tmpPositionDistance;
    }
    
    public void AttDistanceOn()
    {
        attDistance = true;
    }

    public void AttDistanceOff()
    {
        attDistance = false;
    }
}
