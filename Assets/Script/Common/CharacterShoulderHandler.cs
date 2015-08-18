using UnityEngine;
using System.Collections;

public class CharacterShoulderHandler : MonoBehaviour {

    public GameObject shoulder;
    public Sprite[] shoulderSprite;
    public int shoulderNumber;
    private Transform shoulderPosition;
    private SpriteRenderer useShoulder;

    void Start()
    {
        useShoulder = shoulder.GetComponentInChildren<SpriteRenderer>();

        UseHelmetInialize();
    }

    void UseHelmetInialize()
    {
        if (shoulderSprite.Length == 0)
        {
            shoulder.SetActive(false);
        }
        else if (shoulderNumber == -1)
        {
            useShoulder.enabled = false;
        }
        else
        {
            useShoulder.sprite = shoulderSprite[shoulderNumber];
        }
    }
}
