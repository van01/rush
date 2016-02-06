using UnityEngine;
using System.Collections;

public class PlayerControllerHandler : MonoBehaviour {

    private float moveSpeed = 10.0f;
    public GameObject currentPlayer;

    Vector3 transformPosition;
    Vector3 direction;

    private GameObject target;

    void Start()
    {
        target = GetComponent<PlayerAI>().target;
    }

	public void PlayerMove(Vector2 axis)
    {
        transformPosition = new Vector3(axis.x, 0, axis.y);
        //print(transformPosition);
        //currentPlayer.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(transformPosition.x, transformPosition.z) * Mathf.Rad2Deg, transform.eulerAngles.z);

            
    }

    void Update()
    {
        transform.Translate(transformPosition * moveSpeed * 0.01f);

        Vector3 vec = target.transform.position - transform.position;
        vec.Normalize();
        
        Quaternion q = Quaternion.LookRotation(vec);

        q.x = 0;
        q.z = 0;

        transform.rotation = q;

        float rotateDegree = Mathf.Atan2(transformPosition.x, transformPosition.z) * Mathf.Rad2Deg;
        currentPlayer.transform.localEulerAngles = new Vector3(0, rotateDegree, 0);     //이동 방향으로 회전, 부모와 관계없이 회전
    }
}
