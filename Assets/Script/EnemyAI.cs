﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float attackDistance;
    public int groupValue;

    public float chaseSpeed;        // 임시

    private Transform target;
    private GameObject[] arrPlayers;

    private GameObject tmpGameController;
    private bool attDistance = false;
    private int actionNumber = 0;

    private float distance;

    private bool chasePlayer = false;

    void Start()
    {
        tmpGameController = GameObject.Find("GameController");
        attackDistance = Random.RandomRange(1.0f, attackDistance);
    }

    void Update()
    {
        CheckDistanceFromTarget();

        //체력 게이지 위치 잡기
        if (GetComponent<EnemyState>().currentState != CharacterState.State.Dead)
        {
            SendMessage("HealthBarPositionUpdate", transform.position);
            Debug.DrawLine(new Vector3(transform.position.x, -1.0f, 0), new Vector3(distance, -1.0f, 0), Color.red);
        }

        if (chasePlayer == true)
        {
            transform.Translate(Vector3.left * chaseSpeed * Time.deltaTime, Space.World);
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
            if (actionNumber == 0)
            {
                attDistance = false;
                //SendMessage("BattleStop");
                //SendMessage("BattlingOn");        //20150730  해당 부분 때문에 시작과 동시에 자동으로 Move State로 교체되고 있었음 
                actionNumber = 1;
                
            }
        }
        else if (distance < attackDistance)
            {
                if (actionNumber == 1)
                {
                    SendMessage("BattlingOn");
                    attDistance = true;
                    actionNumber = 2;
                }
            }

        if (attDistance == true)
        {
            if (actionNumber == 2)
            {
                SendMessage("CharacterStateControll", "Battle");
                tmpGameController.SendMessage("EnemyStateBattleInfection", groupValue);
                actionNumber = 0;
                chasePlayer = false;
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
}
