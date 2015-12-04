using UnityEngine;
using System.Collections;

public class EmotionHandler : MonoBehaviour
{
    public enum EmotionState
    {
        Wonder,
        Surprise,
    }

    public EmotionState currentEmotionState;

    public GameObject wonderGameObject;
    public GameObject SurpriseGameObject;

    public void CheckEmotionState()
    {
        switch (currentEmotionState)
        {
            case EmotionState.Wonder:
                WonderAction();
                break;
            case EmotionState.Surprise:
                SurpriseAction();
                break;
        }
    }

    void WonderAction()
    {
        wonderGameObject.SetActive(true);
    }

    void SurpriseAction()
    {
        SurpriseGameObject.SetActive(true);
    }
}