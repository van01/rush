using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour
{

    public float attackDistance = 1.5f;
    public float positionDistance = 0f;
    public float backStepSpeed = 4.0f;
    public float fowardStepSpeed = 4.0f;

    private float setPositionTime;

    private Transform target;
    public GameObject[] arrMonsters;

    private GameObject tmpGameController;
    private bool setPosition = false;
    private bool backSetPosition = false;
    private bool fowardSetPosition = false;
    private float setPositionSpeed;

    private float tmpPositionDistance;
    private PlayerState tmpMyState;

    private bool HealthBarOn = true;

    private int i = 0;

    protected float distance;

    protected bool checkDistanceFromTargetUnused = false;

    protected bool saveSkillOn = false;
    protected string saveSkillID;

    void Start()
    {
        tmpMyState = GetComponent<PlayerState>();
        tmpGameController = GameObject.Find("GameController");
    }

    void Update()
    {
        if (checkDistanceFromTargetUnused != true)
            if (tmpMyState.currentState != CharacterState.State.Dead)
                CheckDistanceFromTarget();

        //캐릭터 상태에 따라 gameState 조정, 해당 부분은 gameController로 이동 필요
        if (tmpMyState.currentState == CharacterState.State.Spawn || tmpMyState.currentState == CharacterState.State.Move)
        {
            SendMessage("CharacterStateMoveOn");
            //SendMessage("CharacterStateControll", "Move");
            tmpGameController.SendMessage("GameStateControll", "Playing");
        }

        //캐릭터 백스탭 위치 잡기
        if (backSetPosition == true)
        {
            if (transform.position.x >= -7.0f)
            {
                transform.Translate(-Time.deltaTime * backStepSpeed, 0, 0);
            }
        }

        //캐릭터 태클 위치 잡기
        if (fowardSetPosition == true)
        {
            if (transform.position.x <= 7.0f)
            {
                transform.Translate(Time.deltaTime * fowardStepSpeed, 0, 0);
            }
        }

        //체력 게이지 위치 잡기
        if (HealthBarOn == true)
        {
            SendMessage("HealthBarPositionUpdate", transform.position);
        }

        if (saveSkillOn == true)
        {
            if (GetComponent<PlayerState>().currentState != CharacterState.State.Attack)
            {
                ActivePlayerSkillOn(saveSkillID);
                saveSkillOn = false;
            }
        }
    }

    public void SearchEnemy()
    {
        arrMonsters = GameObject.FindGameObjectsWithTag("Enemy");

        if (arrMonsters != null && arrMonsters.Length > 0)
        {
            float shortDist = Vector3.Distance(transform.position, arrMonsters[0].transform.position);

            target = arrMonsters[0].transform;

            if (arrMonsters.Length > 1)
            {
                for (int i = 1; i < arrMonsters.Length; i++)
                {
                    float distance = Vector3.Distance(transform.position, arrMonsters[i].transform.position);

                    if (distance < shortDist)
                    {
                        shortDist = distance;
                        target = arrMonsters[i].transform;
                    }
                }
            }
        }

        if (arrMonsters.Length == 0)
        {
            target = null;
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

        //print("Distance ::::: " + distance + "  Attack Distance ::::: " + attackDistance);
        if (distance > attackDistance)
        {
            if (tmpMyState.currentState != CharacterState.State.Attack)
            {
                SendMessage("CharacterStateControll", "Move");
            }
        }
        else if (distance < attackDistance)
        {
            if (target.GetComponent<EnemyState>().currentState != CharacterState.State.Dead)
            {
                if (tmpMyState.currentState != CharacterState.State.Attack)
                {
                    SendMessage("CharacterStateControll", "Battle");
                    SendMessage("CharacterStateBattleOn");    //사정거리 진입 시 해당 캐릭터만 전투 모드 변경으로 변경하려고 했으나 해당 함수에 포함된 기능으로인해 보류

                    SendMessage("StartBattle");

                    tmpPositionDistance = positionDistance;
                    positionDistance = transform.position.x;
                }
            }            
        }
    }

    private void PlayerPositionInit()
    {
        //캐릭터 기본 위치 잡기, 기존 Update 함수에서 백업

        //if (tmpMyState.currentState == CharacterState.State.Spawn || tmpMyState.currentState == CharacterState.State.Move)
        if (transform.position.x != positionDistance)
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

                    if (tmpMyState.currentState == CharacterState.State.Spawn || tmpMyState.currentState == CharacterState.State.Move)
                    {
                        SendMessage("CharacterStateMoveOn");
                        //SendMessage("CharacterStateControll", "Move");
                        tmpGameController.SendMessage("GameStateControll", "Playing");
                    }
                    if (tmpMyState.currentState == CharacterState.State.Run)
                    {
                        tmpGameController.SendMessage("GameStateControll", "Playing");
                        tmpGameController.SendMessage("RunScrollOn");
                    }
                }
            }
        }
    }

    public GameObject GetCurrentTarget()
    {
        return target.gameObject;
    }

    public void CharacterPositionInialize(float f)
    {
        setPosition = true;
        setPositionTime = f;

        setPositionSpeed = (positionDistance - transform.position.x) / setPositionTime;
        CharacterBackPositionOff();
        CharacterFowardPositionOff();
    }

    public void CharacterBackPositionOn()
    {
        backSetPosition = true;
        setPosition = false;
    }
    
    public void CharacterBackPositionOff()
    {
        backSetPosition = false;
        setPosition = true;
    }

    public void CharacterFowardPositionOn()
    {
        fowardSetPosition = true;
        setPosition = false;
    }

    public void CharacterFowardPositionOff()
    {
        fowardSetPosition = false;
        setPosition = true;
    }

    public void PositionDistanceReset()
    {
        positionDistance = tmpPositionDistance;
    }

    public void HealthBarOff()
    {
        HealthBarOn = false;
    }

    public void ActivePlayerSkillOn(string activeSkillID)
    {
        if (GetComponent<PlayerState>().currentState == CharacterState.State.Attack)
        {
            saveSkillOn = true;
            saveSkillID = activeSkillID;
        }
        else
        {
            SendMessage("AttackEnd");

            SendMessage("BattleStop");
            SendMessage("AttackSuccessWaitStop");

            SendMessage("CharacterStateControll", "Skill");         //여기에서 어떤 스킬인지 판단해 거리 측정 등 수행 필요
            SendMessage("attackProssibleOn");
            SendMessage("ActiveSkillOn");
            CheckDistanceFromTargetUnusedOn();                      //CheckDistanceFromTargetOff
        }
    }

    public void ActivePlayerSkillOff(string activeSkillID)
    {
        SendMessage("ActiveSkillOff");
        CheckDistanceFromTargetUnusedOff();                      //CheckDistanceFromTargetOn
    }

    public void CheckDistanceFromTargetUnusedOn()
    {
        checkDistanceFromTargetUnused = true;
    }

    public void CheckDistanceFromTargetUnusedOff()
    {
        checkDistanceFromTargetUnused = false;
    }
}
