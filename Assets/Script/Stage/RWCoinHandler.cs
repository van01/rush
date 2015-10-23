using UnityEngine;
using System.Collections;

public class RWCoinHandler : MonoBehaviour {
    public Sprite[] coinSprite;

    private GameObject tmpGameController;
    private int nCoinValue;

    public enum CoinType
    {
        Null,
        Coin,
        BlueCrystal,
        GreenCrystal,
        OrangeCrystal,
        RedCrystal,
    }

    public CoinType currentCoin;

    void Start()
    {
        CheckCointype();
        tmpGameController = GameObject.Find("GameController");
    }

    public void CoinTypeSetting(string nCoinType)
    {
        if (nCoinType == "Null")
            currentCoin = CoinType.Coin;
        if (nCoinType == "Coin")
            currentCoin = CoinType.Coin;
        else if (nCoinType == "BlueCrystal")
            currentCoin = CoinType.BlueCrystal;
        else if (nCoinType == "GreenCrystal")
            currentCoin = CoinType.GreenCrystal;
        else if (nCoinType == "OrangeCrystal")
            currentCoin = CoinType.OrangeCrystal;
        else if (nCoinType == "RedCrystal")
            currentCoin = CoinType.RedCrystal;

        CheckCointype();
    }

    private void CheckCointype()
    {
        switch (currentCoin)
        {
            case CoinType.Null:
                GetComponent<SpriteRenderer>().sprite = null;
                GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.35f);
                CoinValueSetting(0);
                break;
            case CoinType.Coin:
                GetComponent<SpriteRenderer>().sprite = coinSprite[0];
                GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.35f);
                CoinValueSetting(1);
                break;
            case CoinType.BlueCrystal:
                
                GetComponent<SpriteRenderer>().sprite = coinSprite[1];
                GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.48f);
                break;
            case CoinType.GreenCrystal:
             
                GetComponent<SpriteRenderer>().sprite = coinSprite[2];
                GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.48f);
                break;
            case CoinType.OrangeCrystal:
                GetComponent<SpriteRenderer>().sprite = coinSprite[3];
                GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.64f);
                break;
            case CoinType.RedCrystal:
                GetComponent<SpriteRenderer>().sprite = coinSprite[4];
                GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.64f);
                break;
        }
    }


    public void CoinInitialize()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            ItemGet();
        }
    }

    protected void CoinValueSetting(int nValue)
    {
        nCoinValue = nValue;
    }

    protected void ItemGet()
    {
        tmpGameController.SendMessage("CoinValueSetting", nCoinValue);
        tmpGameController.SendMessage("CurrentGameCoinCount", "1");
        if (currentCoin == CoinType.Null)
            tmpGameController.SendMessage("CoinHitValue", new Vector3(-3.0f,-3.0f,0));
        else
            tmpGameController.SendMessage("CoinHitValue", transform.position);

        Destroy(gameObject);
    }
}
