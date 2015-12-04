using UnityEngine;
using System.Collections;

public class CharacterBackHandler : MonoBehaviour {

    public GameObject back;
    public Sprite[] backSprite;
    public int backNumber;
    private Transform backPosition;
    private SpriteRenderer useBack;

    void Start()
    {
        useBack = back.GetComponentInChildren<SpriteRenderer>();

        UseHelmetInialize();
    }

    void UseHelmetInialize()
    {
        if (backSprite.Length == 0)
        {
            back.SetActive(false);
        }
        else if (backNumber == -1)
        {
            useBack.enabled = false;
        }
        else
        {
            useBack.sprite = backSprite[backNumber];
        }
    }
}
