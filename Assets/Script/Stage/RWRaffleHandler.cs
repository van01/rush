using UnityEngine;
using System.Collections;

public class RWRaffleHandler : MonoBehaviour {
    public GameObject CharacterItemHandler;

    public GameObject resultPanel;

    private string[] nonHelmetSpriteName;
    private Sprite[] nonHelmetSprite;
    private Sprite[] characterHelmetSprite;
    private int nonHelmetCount;

    protected int presentHelmetNum;
    protected int globalHelmetNum;

    void Start()
    {
        HelmetDataInitialize();
        characterHelmetSprite = CharacterItemHandler.GetComponent<CharacterHelmetBasket>().CharacterHelmetSprite;
    }

    protected void HelmetDataInitialize()
    {
        CharacterItemHandler.GetComponent<CharacterHelmetBasket>().HelmetCheck();

        nonHelmetCount = CharacterItemHandler.GetComponent<CharacterHelmetBasket>().nonItemCount;
        nonHelmetSpriteName = new string[CharacterItemHandler.GetComponent<CharacterHelmetBasket>().nonItemSpriteName.Length];
        nonHelmetSprite = new Sprite[CharacterItemHandler.GetComponent<CharacterHelmetBasket>().nonItemSprite.Length];

        if (nonHelmetCount == 0)
        {
            SendMessage("ItemfullPanelOn");
        }

        else
        {
            SendMessage("ItemfullPanelOff");
            for (int i = 0; i < nonHelmetSpriteName.Length; i++)
            {
                nonHelmetSpriteName[i] = CharacterItemHandler.GetComponent<CharacterHelmetBasket>().nonItemSpriteName[i];
                nonHelmetSprite[i] = CharacterItemHandler.GetComponent<CharacterHelmetBasket>().nonItemSprite[i];
            }
        }
    }

    public void HelmetRaffleActive()
    {
        presentHelmetNum = (int)Random.RandomRange(0, nonHelmetCount);
        GetHelmetItem(presentHelmetNum);
        HelmetDataInitialize();
    }

    protected void GetHelmetItem(int nHelmetNumber)
    {
        PlayerPrefs.SetInt(nonHelmetSpriteName[nHelmetNumber], 1);
        CharacterItemHandler.GetComponent<CharacterHelmetBasket>().HelmetCheck();
        CharacterHelmetNumberCalculation(nHelmetNumber);

        print("getHelmetName :::::::::::: " + nonHelmetSpriteName[nHelmetNumber]);
    }

    public void ResultPanelActive()
    {
        resultPanel.SetActive(true);
        resultPanel.SendMessage("PresentGetHelmetNumberSetting", globalHelmetNum);     //미보유 중에 몇번째가 아니라 전체중에 몇번째가 필요
        resultPanel.SendMessage("ResultCharacterInitalize");
    }

    public void ResultPanelCloseActive()
    {
        resultPanel.SendMessage("ResultCharacterDestroy");
        resultPanel.SetActive(false);
    }

    void CharacterHelmetNumberCalculation(int nHelmetNumber)
    {
        for (int i = 0; i < characterHelmetSprite.Length; i++)
        {
            if ("ActiveHelmet" + i == nonHelmetSpriteName[nHelmetNumber])
            {
                globalHelmetNum = i;
                print("ActiveHelmet" + i);
            }
        }
    }
}
