using UnityEngine;
using System.Collections;

public class CharacterHelmetHandler : MonoBehaviour {

    public GameObject helmet;
    public Sprite[] helmetSprite;
    public int helmetNumber;
    private Transform helmetPosition;
    private SpriteRenderer useHelmet;

    void Start()
    {
        useHelmet = helmet.GetComponentInChildren<SpriteRenderer>();

        UseHelmetInialize();
    }

    void UseHelmetInialize()
    {
        if (helmetSprite.Length == 0)
        {
            helmet.SetActive(false);
        }
        else if (helmetNumber == -1)
        {
            useHelmet.enabled = false;
        }
        else
        {
            useHelmet.sprite = helmetSprite[helmetNumber];
        }
    }
}
