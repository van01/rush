﻿using UnityEngine;
using System.Collections;

public class CharacterHelmetBasket : MonoBehaviour {

    public Sprite[] CharacterHelmetSprite;
    public string[] CharacterHelmetName;
    private int possessHelmetCount;
    private string nActiveHelmet;
    public string[] nonItemSpriteName;
    public Sprite[] nonItemSprite;
    public int nonItemCount;
    
    void Start()
    {
        HelmetCheck();
        //TestHelmetInitalize();  //테스트 코드, 초기화 기능
        //CharacterHelmetName = new string[CharacterHelmetSprite.Length];   //초기화 
        //CharacterHelmetNameInitalize();                                   //초기화 후 스프라이트 이름 박기
    }

    void PossessHelmetCheck()
    {
        for (int i = 0; i < CharacterHelmetSprite.Length; i++)
        {
            if (PlayerPrefs.GetInt("ActiveHelmet" + i) == 1)
            {
                possessHelmetCount++;
            }
        }
    }

    void NonItemCheck()
    {
        nonItemSpriteName = new string[CharacterHelmetSprite.Length - possessHelmetCount];
        nonItemSprite = new Sprite[CharacterHelmetSprite.Length - possessHelmetCount];

        for (int i = 0; i < CharacterHelmetSprite.Length; i++)
        {
            if (PlayerPrefs.GetInt("ActiveHelmet" + i) == 0)
            {
                nonItemSpriteName.SetValue("ActiveHelmet" + i, nonItemCount);
                nonItemSprite.SetValue(CharacterHelmetSprite[i], nonItemCount);
                nonItemCount++;
            }
        }
    }

    public void HelmetCheck()
    {
        possessHelmetCount = 0;
        PossessHelmetCheck();

        nonItemCount = 0;
        NonItemCheck();
    }

    void CharacterHelmetNameInitalize()
    {
        for (int i = 0; i < CharacterHelmetName.Length; i++)
        {
            CharacterHelmetName[i] = CharacterHelmetSprite[i].name;
        }
    }

    public void TestHelmetInitalize()
    {
        for (int i = 0; i < CharacterHelmetSprite.Length; i++)
        {
            PlayerPrefs.SetInt("ActiveHelmet" + i, 0);
        }
        PlayerPrefs.SetInt("CurrentHelmetNumber", -1);
    }
}