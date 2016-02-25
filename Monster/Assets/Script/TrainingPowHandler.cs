using UnityEngine;
using System.Collections;

public class TrainingPowHandler : MonoBehaviour {

    public GameObject sandbagPrefab;
    private GameObject currentSandbag;
    private GameObject currentMonster;

    public GameObject monsterPosition;
    public GameObject sandbagPosition;

    public float sandbagGoalPositionX;
    public float scorollSpeed;

    private bool isMonsterMove;
    private bool isSandbagMove;

    private float prevMonsterPositionX;

    private int attackCount;

    void Start()
    {
        prevMonsterPositionX = monsterPosition.transform.position.x;
    }

    void Update()
    {
        if (isMonsterMove == true)
        {
            if (monsterPosition.transform.position.x <= 0)
            {
                Vector3 monsterScrollValue = Vector3.right * scorollSpeed * Time.deltaTime;
                monsterPosition.transform.Translate(monsterScrollValue, Space.World);
            }
            else
            {
                isMonsterMove = false;
                isSandbagMove = true;
            }
        }
        else if (isSandbagMove == true)
        {
            if (currentSandbag.transform.position.x >= sandbagGoalPositionX)
            {
                Vector3 sandbagScrollValue = Vector3.left * scorollSpeed * Time.deltaTime;
                currentSandbag.transform.Translate(sandbagScrollValue, Space.World);
            }
            else
            {
                isMonsterMove = false;
                isSandbagMove = false;

                //최초 공격, 증가될 능력치 판단
                GetComponent<TrainingDramaticHandler>().gameContoller.SendMessage("CurrentTrainingTurnMountTotalValueInitialize");
                AttackSuccessJudgment();
            }
        }
        //currentSandbag.transform.Translate(scrollValue, Space.World);
    }

    public void PowDirectionStart()
    {
        currentMonster = Instantiate(GetComponent<TrainingDramaticHandler>().gameContoller.GetComponent<MonsterController>().currentMonster) as GameObject;
        currentMonster.transform.position = monsterPosition.transform.position;
        currentMonster.transform.SetParent(monsterPosition.transform);

        currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.Move;
        currentMonster.GetComponent<MonsterState>().CheckMonsterState();

        currentSandbag = Instantiate(sandbagPrefab) as GameObject;
        currentSandbag.transform.position = sandbagPosition.transform.position;
        currentSandbag.transform.SetParent(sandbagPosition.transform);

        isMonsterMove = true;
        attackCount = 0;
    }

    public void PowDirectionDestroy()
    {
        monsterPosition.transform.position = new Vector3(prevMonsterPositionX, 0, 0);

        Destroy(currentMonster);
        Destroy(currentSandbag);
    }

    public void AttackSuccess()
    {
        attackCount++;
        
        StartCoroutine(AttackSuccessWait());

        currentSandbag.GetComponent<ObjectState>().currentState = ObjectState.State.Hit;
        currentSandbag.GetComponent<ObjectState>().CheckObjectState();
    }

    public void AttackFail()
    {
        attackCount++;
        StartCoroutine(AttackSuccessWait());
    }

    IEnumerator AttackSuccessWait()
    {
        currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.AttackWait;
        //currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.Idle;
        currentMonster.GetComponent<MonsterState>().CheckMonsterState();

        yield return new WaitForSeconds(0.6f);
        if (attackCount < 5)
        {
            AttackSuccessJudgment();
        }
        else
        {
            PowDirectionEnd();
        }
    }

    public void PowDirectionEnd()
    {
        //연출 종료 시 호출, 종료 연출 후 축하 연출, 결과 팝업 제공
        currentSandbag.GetComponent<ObjectState>().currentState = ObjectState.State.End;
        currentSandbag.GetComponent<ObjectState>().CheckObjectState();

        currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.Idle;
        currentMonster.GetComponent<MonsterState>().CheckMonsterState();

        SendMessage("SuccessUIOnDelivery");
    }

    public void AttackSuccessJudgment()
    {
        //훈련 성공여부 판단 호출
        bool isSuccess = GetComponent<TrainingDramaticHandler>().gameContoller.GetComponent<TrainingController>().TrainingSuccessJudgment();

        if (isSuccess == true)
        {
            currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.Attack;
        }
        else
            currentMonster.GetComponent<MonsterState>().currentState = MonsterState.State.Fall;
        currentMonster.GetComponent<MonsterState>().CheckMonsterState();
    }
}
