using UnityEngine;
using System.Collections;

public class RWCoinHandler : MonoBehaviour {
    public Sprite[] coinSprite;

    public enum CoinType
    {
        Coin,
        BlueCrystal,
        GreenCrystal,
        OrangeCrystal,
        RedCrystal,
    }

    public CoinType currentCoin;
    
    

    public void CoinTypeSetting(string nCoinType)
    {
        if (nCoinType == "Coin")
        {
            currentCoin = CoinType.Coin;
            GetComponent<SpriteRenderer>().sprite = coinSprite[0];
            GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.35f);
        }
        else if (nCoinType == "BlueCrystal")
        {
            currentCoin = CoinType.BlueCrystal;
            GetComponent<SpriteRenderer>().sprite = coinSprite[1];
            GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.48f);
        }
        else if (nCoinType == "GreenCrystal")
        {
            currentCoin = CoinType.GreenCrystal;
            GetComponent<SpriteRenderer>().sprite = coinSprite[2];
            GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.48f);
        }
        else if (nCoinType == "OrangeCrystal")
        {
            currentCoin = CoinType.OrangeCrystal;
            GetComponent<SpriteRenderer>().sprite = coinSprite[3];
            GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.64f);
        }
        else if (nCoinType == "RedCrystal")
        {
            currentCoin = CoinType.RedCrystal;
            GetComponent<SpriteRenderer>().sprite = coinSprite[4];
            GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.64f);
        }
    }

    public void CoinInitialize()
    {

    }
}
