using UnityEngine;
using System.Collections;

public class PlayerAI : MonoBehaviour {

    public GameObject target;
    public float attackDistance = 0.5f;
    public bool isAttackAble = false;

    
    private bool isAutoMove = false;
    
    private Vector3 prevPos;
    private Vector3 toTarget;

    private float ratio;
    private float deltaRatio;

    protected float distance;

    void Start()
    {
        isAttackAble = true;
    }

    void Update()
    {
        if (isAutoMove == true)
        {
            ratio += deltaRatio * Time.deltaTime;

            if (ratio > 1.0f)
            {
                ratio = 1.0f;
            }

            transform.position = prevPos + toTarget * ratio;
            //자동 이동

            CheckDistanceFromTarget();
        }
    }

    public void AttackWarmUp()
    {
        //공격 가능 상태인지 체크
        GetComponent<PlayerControllerHandler>().currentPlayer.SendMessage("AttackAniPlayCheck");

        if (GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<CharacterAni>().isAttackAniPlay == false)
        {
            CheckDistanceFromTarget();
        }
    }

    void CheckDistanceFromTarget()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);
        distance = distance - ((target.GetComponent<BoxCollider>().size.x * target.transform.localScale.x - target.GetComponent<BoxCollider>().center.x));  //콜라이더 사이즈에 따라 거리 재측정, 검증 필요

        if (isAttackAble == true)
        {
            AutoMoveDistance();

            if (distance > attackDistance)
            {
                //공격 불가능 상태에서 공격 시, 몬스터에게 자동 이동
                isAutoMove = true;

                GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().currentState = CharacterState.State.Dash;
                GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().CheckCharacterState();
            }
            else if (distance <= attackDistance)
            {
                //공격 가능 범위 일경우 공격 실행
                isAutoMove = false;

                GetComponent<CharacterBattle>().StartBattle();

                GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().currentState = CharacterState.State.Attack;
                GetComponent<PlayerControllerHandler>().currentPlayer.GetComponent<PlayerState>().CheckCharacterState();

                isAttackAble = false;

                ratio = 0;
            }
        }
    }

    void AutoMoveDistance()
    {
        prevPos = transform.position;
        toTarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - prevPos;

        deltaRatio = 8.0f / toTarget.sqrMagnitude;

        //타겟과의 거리 및 이동 속도 계산
    }
}
