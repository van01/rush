using UnityEngine;
using System.Collections;

public class CharacterEyeHandler : MonoBehaviour
{
    public GameObject eyePosition;

    public GameObject normalEye;
    public GameObject GoodEye;
    public GameObject smileEye;
    public GameObject chaosEye;
    public GameObject surpriseEye;

    public enum EyeState
    {
        Normal,
        Good,
        Smile,
        Chaos,
        Surprise,
    }

    private GameObject currentEye;
    private SpriteRenderer[] myAllSpriteRenderer;

    public EyeState currentEyeState;
    public void CheckEyeState()
    {
        switch (currentEyeState)
        {
            case EyeState.Normal:
                EyeInitialize(normalEye);
                break;
            case EyeState.Good:
                EyeInitialize(GoodEye);
                break;
            case EyeState.Smile:
                EyeInitialize(smileEye);
                break;
            case EyeState.Chaos:
                EyeInitialize(chaosEye);
                break;
            case EyeState.Surprise:
                EyeInitialize(surpriseEye);
                break;
        }
    }

    void EyeInitialize(GameObject nEye)
    {
        Destroy(currentEye);
        ChildDestroyer();

        currentEye = Instantiate(nEye, eyePosition.transform.position, eyePosition.transform.rotation) as GameObject;
        currentEye.transform.SetParent(eyePosition.transform);

        myAllSpriteRenderer = currentEye.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].sortingOrder = 6;
            //currentEye.GetComponent<SpriteRenderer>().sortingOrder = 6;
        }
    }

    void Awake()
    {
        currentEyeState = EyeState.Normal;
        CheckEyeState();
    }

    void ChildDestroyer()
    {
        Transform[] eyePositionChildList = eyePosition.transform.GetComponentsInChildren<Transform>(true);

        if (eyePositionChildList != null)
        {
            for (int i = 1; i < eyePositionChildList.Length; i++)
            {
                if (eyePositionChildList[i] != transform)
                    Destroy(eyePositionChildList[i].gameObject);
            }
        }
    }
}
