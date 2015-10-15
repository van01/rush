using UnityEngine;
using System.Collections;

public class RWBlockHandler : MonoBehaviour {
    public GameObject blockSpritePrefab;

    private int blockSpriteLength;
    private GameObject presentBlockSprite;

    private float blockSpritePositionX;

    protected bool isCountBlock = true;
    private Transform tmpBlockController;
    
    void Start()
    {
        tmpBlockController = transform.parent;

        blockSpriteLength = (int)GetComponent<BoxCollider2D>().size.x;
        blockSpritePositionX = transform.position.x + (((float)blockSpriteLength - 1f) / 2f);

        for (int i = 1; i <= blockSpriteLength; i++)
        {
            presentBlockSprite = Instantiate(blockSpritePrefab, new Vector3(blockSpritePositionX, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            presentBlockSprite.transform.SetParent(transform);

            blockSpritePositionX = blockSpritePositionX - 1.0f;

            //presentStage.SendMessage("FloorSetting", isRWStage);
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
