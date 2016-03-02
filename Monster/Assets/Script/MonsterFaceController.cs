using UnityEngine;
using System.Collections;

public class MonsterFaceController : MonoBehaviour {

    public GameObject eyePosition;
    public GameObject mouthPosition;

    public GameObject eyeNormal;
    public GameObject eyeFunny;
    public GameObject eyeHappy;
    public GameObject eyeSurprise;
    public GameObject eyeChaos;

    public GameObject mouthNormal;
    public GameObject mouthSmile;
    public GameObject mouthSerious;
    public GameObject mouthOpen;
    public GameObject mouthScream;

    private GameObject currentEye;
    private GameObject currentMouth;

    public enum FaceState
    {
        Good,       //일반 - 좋은
        Normal,     //일반 - 보통
        NotBad,     //일반 - 나쁘지 않은
        Bad,        //일반 - 나쁜
        Funny,      //재미있는
        Happy,      //행복한
        Painful,    //괴로운
        Hard,       //힘든
        Success,    //성공
        Fail,       //실패
    }
    public FaceState currentFaceState;
    public void CheckFaceState()
    {
        switch (currentFaceState)
        {
            case FaceState.Good:
                FaceInitialize(eyeNormal, mouthSmile);
                break;
            case FaceState.Normal:
                FaceInitialize(eyeNormal, mouthNormal);
                break;
            case FaceState.NotBad:
                FaceInitialize(eyeNormal, mouthSerious);
                break;
            case FaceState.Bad:
                FaceInitialize(eyeSurprise, mouthSerious);
                break;
            case FaceState.Funny:
                FaceInitialize(eyeFunny, mouthSmile);
                break;
            case FaceState.Happy:
                FaceInitialize(eyeHappy, mouthSmile);
                break;
            case FaceState.Painful:
                FaceInitialize(eyeChaos, mouthOpen);
                break;
            case FaceState.Hard:
                FaceInitialize(eyeSurprise, mouthOpen);
                break;
            case FaceState.Success:
                FaceInitialize(eyeFunny, mouthScream);
                break;
            case FaceState.Fail:
                FaceInitialize(eyeSurprise, mouthScream);
                break;
        }
    }

    void FaceInitialize(GameObject nEye, GameObject nMouth)
    {
        Destroy(currentEye);
        Destroy(currentMouth);
        ChildDestroyer();

        currentEye = Instantiate(nEye, eyePosition.transform.position, eyePosition.transform.rotation) as GameObject;
        currentMouth = Instantiate(nMouth, mouthPosition.transform.position, mouthPosition.transform.rotation) as GameObject;

        currentEye.transform.SetParent(eyePosition.transform);
        currentMouth.transform.SetParent(mouthPosition.transform);

        currentEye.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        currentMouth.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        currentEye.GetComponent<SpriteRenderer>().sortingLayerName = "Monster";
        currentMouth.GetComponent<SpriteRenderer>().sortingLayerName = "Monster";

        //표정 변경할 때 마다 색상 재적용
        SendMessage("MonsterColorApply");
    }

    void ChildDestroyer()
    {
        Transform[] eyePositionChildList = eyePosition.transform.GetComponentsInChildren<Transform>(true);
        Transform[] mouthPositionChildList = mouthPosition.transform.GetComponentsInChildren<Transform>(true);

        if (eyePositionChildList != null)
        {
            for (int i = 1; i < eyePositionChildList.Length; i++)
            {
                if (eyePositionChildList[i] != transform)
                    Destroy(eyePositionChildList[i].gameObject);
            }
        }

        if (mouthPositionChildList != null)
        {
            for (int i = 1; i < mouthPositionChildList.Length; i++)
            {
                if (mouthPositionChildList[i] != transform)
                    Destroy(mouthPositionChildList[i].gameObject);
            }
        }
    }
}
