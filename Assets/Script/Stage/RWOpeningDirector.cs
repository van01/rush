using UnityEngine;
using System.Collections;

public class RWOpeningDirector : MonoBehaviour {

    public bool openingDirection;

    public GameObject target;

    public GameObject witchCharacter;
    public GameObject emotion;

    public GameObject explosionEffect;

    private int openingTake;

    public GameObject currentPlayerCharacter;
    public GameObject currentWitchCharacter;
    private GameObject currentEmotion;

    private GameObject currentexplosionEffect;

    private float distance;

    private bool openingTake2ActingOn;
    private bool openingTake3ActingOn;
    private bool openingTake4ActingOn;

    void Start()
    {
        if (openingDirection == true)
        {
            currentPlayerCharacter = GetComponent<RWPlayerController>().currentPlayerCharacter;
            
            StartCoroutine("OpeningTake1Acting");
        }
    }

    void Update()
    {
        if (openingDirection == true)
        {
            if (openingTake == 1)
            {
                distance = Vector3.Distance(target.transform.position, currentPlayerCharacter.transform.position);
                if (distance > 1.0f)
                    currentPlayerCharacter.transform.Translate(Vector3.right * Time.deltaTime);
                else
                    openingTake = 2;
            }
            else if (openingTake == 2)
            {
                if (openingTake2ActingOn == false)
                    StartCoroutine("OpeningTake2Acting");
            }
            else if (openingTake == 3)
            {
                if (openingTake3ActingOn == false)
                    OpeningTake3Acting();
            }
            else if (openingTake == 4)
            {               
                if (openingTake4ActingOn == false)
                    OpeningTake4Acting();
                if (currentPlayerCharacter.transform.position.x <= currentPlayerCharacter.GetComponent<PlayerAI>().positionDistance)
                    currentPlayerCharacter.transform.Translate(Vector3.right * Time.deltaTime * 2.0f);
                else
                {
                    currentPlayerCharacter.transform.position = new Vector3 (currentPlayerCharacter.GetComponent<PlayerAI>().positionDistance, 0.4f, 0);    //playcerCharacter 강제이동
                    OpeningEndCheck();
                }
                    
            }
        }
            
    }


    IEnumerator OpeningTake1Acting()
    {
        currentPlayerCharacter.SendMessage("CharacterStateControll", "RWHold");     //발견하는 연출 추가
        
        currentEmotion = Instantiate(emotion, new Vector3(currentPlayerCharacter.transform.position.x + 0.3f, currentPlayerCharacter.transform.position.y - 0.45f, 0), currentPlayerCharacter.transform.rotation) as GameObject;
        currentEmotion.transform.SetParent(currentPlayerCharacter.transform);

        currentEmotion.GetComponent<EmotionHandler>().currentEmotionState = EmotionHandler.EmotionState.Wonder;
        currentEmotion.GetComponent<EmotionHandler>().CheckEmotionState();

        currentWitchCharacter = Instantiate(witchCharacter, new Vector3 (10.0f, 10.0f, 0), target.transform.rotation) as GameObject;    //마녀 생성
        currentWitchCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;

        yield return new WaitForSeconds(1.0f);
        openingTake = 1;
        currentPlayerCharacter.SendMessage("CharacterStateControll", "RWPlay");
    }

    IEnumerator OpeningTake2Acting()
    {
        print("::::::::OpeningTake2Acting::::::::");
        openingTake2ActingOn = true;

        currentPlayerCharacter.SendMessage("attackValueXSetting", 25);
        currentPlayerCharacter.SendMessage("attackValueYSetting", 27);      // 화면 끝에 걸릴 정도로 값 지정

        currentPlayerCharacter.SendMessage("CharacterAddForce");

        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().currentEyeState = CharacterEyeHandler.EyeState.Chaos;
        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().CheckEyeState();

        // 폭발 이펙트 변경 필요
        explosionEffect.SetActive(true);
        explosionEffect.transform.FindChild("explosion_1").SendMessage("RealEffectPlay");
        //currentexplosionEffect = Instantiate(explosionEffect, target.transform.position, target.transform.rotation) as GameObject;

        //currentexplosionEffect.transform.localPosition = new Vector3(1.5f, 0.5f, 0);
        //currentexplosionEffect.transform.localScale = new Vector3(10.0f, 10.0f, 0);
        //currentexplosionEffect.SendMessage("RealEffectPlay");

        currentPlayerCharacter.SendMessage("CharacterStateControll", "Disorder"); //상태이상 적용
        yield return new WaitForSeconds(0.5f);
        
        //currentWitchCharacter = Instantiate(witchCharacter, target.transform.position, target.transform.rotation) as GameObject;    //마녀 생성
        currentWitchCharacter.transform.position = target.transform.position;   //미리 생성해놓은 마녀 타겟으로 이동
        currentWitchCharacter.GetComponent<Rigidbody2D>().gravityScale = 9.0f;

        target.transform.position = currentWitchCharacter.GetComponent<RWWitchHandler>().holdPosition.transform.position;
        target.transform.SetParent(currentWitchCharacter.GetComponent<RWWitchHandler>().holdPosition.transform);        //바구니 이동

        currentWitchCharacter.GetComponent<RWWitchHandler>().currentWitchState = RWWitchHandler.WitchState.Idle;
        currentWitchCharacter.GetComponent<RWWitchHandler>().CheckWitchState();
    }

    public void WitchIdleEnd()
    {
        openingTake = 3;    //마녀 Idle 종료 시점에 이벤트 추가 필요
    }

    void OpeningTake3Acting()
    {
        print("::::::::OpeningTake3Acting::::::::");
        openingTake3ActingOn = true;
        currentPlayerCharacter.SendMessage("CharacterStateControll", "RWHold");

        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().currentEyeState = CharacterEyeHandler.EyeState.Surprise;
        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().CheckEyeState();

        currentEmotion = Instantiate(emotion, new Vector3(currentPlayerCharacter.transform.position.x + 0.25f, currentPlayerCharacter.transform.position.y - 0.2f, 0), currentPlayerCharacter.transform.rotation) as GameObject;
        currentEmotion.transform.SetParent(currentPlayerCharacter.transform);

        currentEmotion.GetComponent<EmotionHandler>().currentEmotionState = EmotionHandler.EmotionState.Surprise;
        currentEmotion.GetComponent<EmotionHandler>().CheckEmotionState();

        currentWitchCharacter.GetComponent<RWWitchHandler>().currentWitchState = RWWitchHandler.WitchState.Out;
        currentWitchCharacter.GetComponent<RWWitchHandler>().CheckWitchState();       
    }

    public void WitchOutEnd()
    {
        openingTake = 4;    //마녀 Out 종료 시점에 이벤트 추가 필요
    }

    public void OpeningTake4Acting()
    {
        if (openingDirection == true)
        {
            print("::::::::OpeningTake4Acting::::::::");
            openingTake4ActingOn = true;
            currentPlayerCharacter.SendMessage("CharacterStateControll", "RWPlay");

            currentPlayerCharacter.GetComponent<CharacterEyeHandler>().currentEyeState = CharacterEyeHandler.EyeState.Normal;
            currentPlayerCharacter.GetComponent<CharacterEyeHandler>().CheckEyeState();

            openingTake = 4;

            target.transform.position = currentWitchCharacter.GetComponent<RWWitchHandler>().holdPosition.transform.position;
            target.transform.SetParent(currentWitchCharacter.GetComponent<RWWitchHandler>().holdPosition.transform);        //바구니 이동

            currentWitchCharacter.GetComponent<RWWitchHandler>().currentWitchState = RWWitchHandler.WitchState.Run;
            currentWitchCharacter.GetComponent<RWWitchHandler>().CheckWitchState();
            currentWitchCharacter.GetComponent<Puppet2D_GlobalControl>().flip = true;

            Destroy(currentWitchCharacter.GetComponent<BoxCollider2D>());
            Destroy(currentWitchCharacter.GetComponent<Rigidbody2D>());

            currentWitchCharacter.SendMessage("FlyingInitialize");

            //currentWitchCharacter.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }

    public void OpeningEndCheck()
    {
        if (currentWitchCharacter.GetComponent<RWWitchHandler>().isFlying == true)
        {
            openingDirection = false;
            SendMessage("StageScrollInialize");
            SendMessage("BaseBlockScrollOnDelivery");
            //오프닝 종료 시점에 스크롤 시작
        }

    }

    public void FlyingInitializeDelivery()
    {
        currentWitchCharacter.SendMessage("FlyingInitialize");
    }

    public void FlyingTheWitchDelivery()
    {
        currentWitchCharacter.SendMessage("FlyingTheWitch");
    }

    public void FlyingTheWitchOffDelivery()
    {
        if (currentWitchCharacter != null)
            currentWitchCharacter.SendMessage("FlyingTheWitchOff");
    }
}
