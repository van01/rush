using UnityEngine;
using System.Collections;

public class CharacterHelmetHandler : MonoBehaviour {

    public GameObject helmet;
    public int helmetNumber;

    private Sprite[] helmetSprite;
    private Transform helmetPosition;
    private SpriteRenderer useHelmet;

    private GameObject tmpItemHandler;
    void Awake()
    {
        tmpItemHandler = GetComponent<CharacterItemHandler>().tmpItemHandler;
        helmetSprite = new Sprite[tmpItemHandler.GetComponent<CharacterHelmetBasket>().CharacterHelmetSprite.Length];
        HelmetSpriteInialize();

        useHelmet = helmet.GetComponentInChildren<SpriteRenderer>();
    }

    void HelmetSpriteInialize()
    {
        for (int i = 0; i < helmetSprite.Length; i++)
        {
            helmetSprite[i] = tmpItemHandler.GetComponent<CharacterHelmetBasket>().CharacterHelmetSprite[i];
        }
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
            useHelmet.enabled = true;
            useHelmet.sprite = helmetSprite[helmetNumber];
        }
    }

    public void EquipHelmet(int nHelmetNumber)
    {
        helmetNumber = nHelmetNumber;
        UseHelmetInialize();
    }
}
