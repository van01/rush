using UnityEngine;
using System.Collections;

public class RWWitchHandler : MonoBehaviour
{

    public GameObject holdPosition;

    private SpriteRenderer[] myAllSpriteRenderer;

    public enum WitchState
    {
        Sit,
        Idle,
        Out,
        Run,
    }

    public WitchState currentWitchState;

    public void CheckWitchState()
    {
        switch (currentWitchState)
        {
            case WitchState.Sit:
                SitAction();
                break;
            case WitchState.Idle:
                IdleAction();
                break;
            case WitchState.Out:
                OutAction();
                break;
            case WitchState.Run:
                RunAction();
                break;
        }
    }

    public GameObject bust;

    private GameObject tmpGameController;

    public bool isFlying;
    private bool isFlyingRight;
    private bool isFlyingLeft;

    private bool flyingRightChangeOn;
    private bool flyingLeftChangeOn;

    private float positionYMin = 2.5f;
    private float positionYMax = 3.0f;

    private float positionXMin = 1.3f;
    private float positionXMax = 7.0f;

    private float currentPositionXMin;    

    private float currentPositionY;

    private float moveSpeed;

    void SitAction()
    {
        SendMessage("ChangeAni", RWWitchAni.SIT);
    }

    void IdleAction()
    {
        SendMessage("ChangeAni", RWWitchAni.IDLE);
    }

    void OutAction()
    {
        SendMessage("ChangeAni", RWWitchAni.OUT);
    }

    void RunAction()
    {
        SendMessage("ChangeAni", RWWitchAni.RUN);
    }

    void Awake()
    {
        tmpGameController = GameObject.Find("GameController");
        myAllSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (isFlying == true)
        {
            if (isFlyingRight == true)
            {
                if (transform.position.x >= currentPositionXMin)
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                else
                {
                    if (flyingRightChangeOn == false)
                    {
                        StartCoroutine("FlyingRightChange");

                        flyingRightChangeOn = true;
                    }
                }
            }
            else if (isFlyingLeft == true)
            {
                if (transform.position.x <= positionXMax)
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                else
                {
                    if (flyingLeftChangeOn == false)
                    {
                        StartCoroutine("FlyingLeftChange");

                        flyingLeftChangeOn = true;
                    }
                }
            }
        }
    }

    public void FlyingInitialize()
    {
        transform.position = new Vector3(10.0f, 10.0f, 0);
        isFlying = true;                                //게임 오버 등의 상태에서 false로 만들어 주는 기능 필요
    }

    public void FlyingTheWitch()
    {
        StartCoroutine("FlyingPositionInitialize");
    }

    public void FlyingTheWitchOff()
    {
        FlyingInitialize();
    }

    IEnumerator FlyingPositionInitialize()
    {
        float nSeconds = Random.RandomRange(10.0f, 30.0f);
        yield return new WaitForSeconds(nSeconds);

        moveSpeed = Random.RandomRange(0.1f, 1.0f);
        currentPositionY = Random.RandomRange(positionYMin, positionYMax);
        currentPositionXMin = Random.RandomRange(positionXMin, positionYMax);

        transform.position = new Vector3(positionXMax, currentPositionY, 0);
        isFlyingRight = true;
    }

    IEnumerator FlyingRightChange()
    {
        float nSeconds = Random.RandomRange(0.5f, 1.0f);
        yield return new WaitForSeconds(nSeconds);

        isFlyingRight = false;
        isFlyingLeft = true;

        flyingRightChangeOn = false;
    }

    IEnumerator FlyingLeftChange()
    {
        float nSeconds = Random.RandomRange(10.0f, 30.0f);
        yield return new WaitForSeconds(nSeconds);

        isFlyingRight = true;
        isFlyingLeft = false;

        StartCoroutine("FlyingPositionInitialize");

        flyingLeftChangeOn = false;
    }

    public void WitchIdleEndDelivery()
    {
        tmpGameController.SendMessage("WitchIdleEnd");
    }

    public void WitchOutEndDelivery()
    {
        tmpGameController.SendMessage("WitchOutEnd");
    }

    public void AllSpriteRendererSortingLayerUI()
    {
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].sortingLayerName = "UI";
            myAllSpriteRenderer[i].sortingOrder = myAllSpriteRenderer[i].sortingOrder + 1;
        }
        bust.GetComponent<Renderer>().sortingLayerName = "UI";
    }
}
