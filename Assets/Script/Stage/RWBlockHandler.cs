using UnityEngine;
using System.Collections;

public class RWBlockHandler : MonoBehaviour {
    public GameObject blockSpritePrefab;
    public GameObject coinPrefab;

    private int blockSpriteLength;
    private GameObject presentBlockSprite;

    private float blockSpritePositionX;

    protected bool isCountBlock = true;
    private Transform tmpBlockController;

    private GameObject presentCoin;
    private float coinPositionY;

    void Start()
    {
        tmpBlockController = transform.parent;

        blockSpriteLength = (int)GetComponent<BoxCollider2D>().size.x;
        blockSpritePositionX = transform.position.x + (((float)blockSpriteLength - 1f) / 2f);
        coinPositionY = 2.0f;

        for (int i = 1; i <= blockSpriteLength; i++)
        {
            presentBlockSprite = Instantiate(blockSpritePrefab, new Vector3(blockSpritePositionX, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            presentBlockSprite.transform.SetParent(transform);

            presentCoin = Instantiate(coinPrefab, new Vector3(blockSpritePositionX, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            presentCoin.SendMessage("CoinTypeSetting", "Coin");
            presentCoin.transform.position = new Vector3(blockSpritePositionX, transform.position.y + GetComponent<BoxCollider2D>().size.y / 2 + coinPrefab.GetComponent<BoxCollider2D>().size.y, transform.position.z);
            presentCoin.transform.SetParent(transform);

            blockSpritePositionX = blockSpritePositionX - 1.0f;
        }
    }

    public void BlockCount()
    {
        if (isCountBlock == true)
        {
            tmpBlockController.SendMessage("BlockCountRiseDelivery");
            isCountBlock = false;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (c.transform.position.y > transform.position.y + GetComponent<BoxCollider2D>().size.y / 2)
                BlockCount();
            c.gameObject.SendMessage("AddforceInitialize");
        }
    }
}
