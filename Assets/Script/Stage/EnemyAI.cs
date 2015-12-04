using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float attackDistance;
    public int groupValue;

    public float chaseDistance = 10.0f;

    public float chaseSpeed;        // 임시

    private Transform target;
    private GameObject[] arrPlayers;

    private GameObject tmpGameController;
    //private bool attDistance = false;
    //private int actionNumber = 0;

    private float distance;

    private bool chasePlayer = false;
    private bool chasePlayerOn = false;
    private bool HealthBarOn = true;

    private EnemyState tmpMyState;

    public enum assultType
    {
        offense,
        defense,
        immovable,
    }

    public assultType currentAssulttype;

    void Start()
    {
        tmpGameController = GameObject.Find("GameController");
        tmpMyState = GetComponent<EnemyState>();

        attackDistance = Random.RandomRange(attackDistance - 0.2f, attackDistance + 0.2f);
        //print(attackDistance);
    }

    void Update()
    {
        if (tmpMyState.currentState != CharacterState.State.Dead)
            CheckDistanceFromTarget();

        //체력 게이지 위치 잡기
        if (HealthBarOn == true)
        {
            SendMessage("HealthBarPositionUpdate", transform.position);
        }

        if (chasePlayer == true)
        {
            transform.Translate(Vector3.left * chaseSpeed * Time.deltaTime, Space.World);
            SendMessage("CharacterStateControll", "Move");
        }
    }

    public void SearchPlayer()
    {
        arrPlayers = GameObject.FindGameObjectsWithTag("Player");

        if (arrPlayers != null && arrPlayers.Length > 0)
        {
            float shortDist = Vector3.Distance(transform.position, arrPlayers[0].transform.position);

            target = arrPlayers[0].transform;
            
            if (arrPlayers.Length > 1)
            {
                for (int i = 1; i < arrPlayers.Length; i++)
                {
                    float distance = Vector3.Distance(transform.position, arrPlayers[i].transform.position);

                    if (distance < shortDist)
                    {
                        shortDist = distance;
                        target = arrPlayers[i].transform;
                    }
                }
            }   
        }

        if (arrPlayers.Length == 0)
        {
            target = null;
            print("game end");
        }
    }

    void CheckDistanceFromTarget()
    {
        if (target == null)
        {
            //SendMessage("CharacterStateMoveOn");      //업데이트 마다 무브를 걸어주니 오류생김
            return;
        }

        distance = Vector3.Distance(target.position, transform.position);
        distance = distance - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);
        
        if (distance > attackDistance)
        {
            if (currentAssulttype == assultType.offense)
                if (distance < chaseDistance)
                    ChasePlayer();
            else if (tmpMyState.currentState != CharacterState.State.Attack)
            {
                if (chasePlayerOn == true)
                {
                    ChasePlayer();
                    SendMessage("BattleStop");
                }
                else
                {
                    SendMessage("CharacterStateControll", "Battle");
                }
            }             
        }

        else if (distance < attackDistance)
        {
            if (target.GetComponent<PlayerState>().currentState != CharacterState.State.Dead)
            {
                if (tmpMyState.currentState != CharacterState.State.Attack)
                {
                    if (tmpMyState.currentState == CharacterState.State.Move)
                        SendMessage("CharacterStateControll", "Battle"); //해당 부분에서 멈추는 현상 발생
                    SendMessage("TargetDistance", distance);

                    SendMessage("StartBattle");

                    tmpGameController.SendMessage("EnemyStateBattleInfection", groupValue); //해당 함수에 판단자 추가 필요
                    
                    chasePlayer = false;
                    chasePlayerOn = true;
                }
            }
        }
    }

    public GameObject GetCurrentTarget()
    {
        return target.gameObject;
    }

    public void ChasePlayer()
    {
        distance = Vector3.Distance(target.position, transform.position);

        distance = distance - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);

        if (distance > attackDistance)
        {
            SendMessage("CharacterStateControll", "Move");
            chasePlayer = true;
        }
    }

    public void HealthBarOff()
    {
        HealthBarOn = false;
    }

}
