using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float attackDistance = 1.5f;

    private Transform target;
    private GameObject[] arrPlayers;

    private GameObject tmpGameController;
    private bool attDistance = false;
    private int actionNumber = 0;

    void Start()
    {
        tmpGameController = GameObject.Find("GameController");
    }

    void Update()
    {
        CheckDistanceFromTarget();
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
    }

    void CheckDistanceFromTarget()
    {
        if (target == null)
        {
            //SendMessage("CharacterStateMoveOn");      //업데이트 마다 무브를 걸어주니 오류생김
            return;
        }

        float distance = Vector3.Distance(target.position, transform.position);

        distance = distance - ((target.GetComponent<BoxCollider2D>().size.x - target.GetComponent<BoxCollider2D>().offset.x) * target.transform.localScale.x / 2);

        if (distance > attackDistance)
        {
            if (actionNumber == 0)
            {
                attDistance = false;
                SendMessage("BattleStop");
                SendMessage("BattlingOn");
                actionNumber = 1;
            }
        }
        else if (distance < attackDistance)
            {
                if (actionNumber == 1)
                {
                    attDistance = true;
                    actionNumber = 2;
                }
            }

        if (attDistance == true)
        {
            if (actionNumber == 2)
            {
                SendMessage("CharacterStateControll", "Battle");
                actionNumber = 0;
            }
        }
    }

    public GameObject GetCurrentTarget()
    {
        return target.gameObject;
    }
}
