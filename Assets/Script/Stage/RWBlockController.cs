using UnityEngine;
using System.Collections;

public class RWBlockController : MonoBehaviour {
    public GameObject blockPrefab;
    public int blockPrefabCount;

    private GameObject presentBlockPrefab;
    private GameObject oldBlockPrefab;
    private GameObject[] arrBlock;

    private int presentBlockPrefabColSizeX;
    private float oldBlockPrefabColSizeX;
    private float presentBlockPrefabPositionX;
    private float oldBlockPrefabPositionX = 5.6f;

    private float blockSpaceSizeX;
    private float blockSpaceSizeY;

    void Start()
    {
        presentBlockPrefabColSizeX = 6;                 // 이번에 생성할 블럭의 collision 크기

        arrBlock = GameObject.FindGameObjectsWithTag("Block");

        if (arrBlock.Length < blockPrefabCount)
        {
            for (int i = 0; i < blockPrefabCount - arrBlock.Length; i++)
            {
                BlockGenerater();
            }
        }
    }

    void BlockGenerater()
    {
        GetOldBlockPrefabPositionX();
        RandomPresentBlockcolSizeX();

        presentBlockPrefabPositionX = oldBlockPrefabPositionX + ((float)presentBlockPrefabColSizeX / 2f);

        presentBlockPrefab = Instantiate(blockPrefab, new Vector3(presentBlockPrefabPositionX, blockSpaceSizeY, transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
        presentBlockPrefab.GetComponent<BoxCollider2D>().size = new Vector2(presentBlockPrefabColSizeX, 4.0f) ;
        presentBlockPrefab.transform.SetParent(transform);

        oldBlockPrefab = presentBlockPrefab;
    }

    void RandomPresentBlockcolSizeX()
    {
        presentBlockPrefabColSizeX = (int)Random.RandomRange(2f, 6f);   //테스트용 블럭 사이즈, 난이도 조정 후 난이도에 따라 범위 변하도록 수정 필요
    }

    void GetOldBlockPrefabPositionX()
    {
        if (oldBlockPrefab != null)
        {
            oldBlockPrefabColSizeX = oldBlockPrefab.GetComponent<BoxCollider2D>().size.x;

            RandomBlockPosition();
            oldBlockPrefabPositionX = oldBlockPrefab.transform.position.x + ((float)oldBlockPrefabColSizeX / 2f) + blockSpaceSizeX;    //마지막에 생성한 블럭 실제 위치 찾기 + blockSpaceSizeX
        }
        else
        {
            RandomBlockPosition();
            oldBlockPrefabPositionX = oldBlockPrefabPositionX + blockSpaceSizeX;
        }
    }

    void RandomBlockPosition()
    {
        RandomBlockSpaceSizeX();
        RandomBlockSpaceSizeY();
    }

    void RandomBlockSpaceSizeX()
    {
        blockSpaceSizeX = Random.RandomRange(0.5f, 1.0f);   //테스트용 블럭 간격, 난이도 조정 후 난이도에 따라 범위 변하도록 수정 필요
    }

    void RandomBlockSpaceSizeY()
    {
        blockSpaceSizeY = transform.position.y + Random.RandomRange(0f, 0.4f);   //테스트용 블럭 높이, 난이도 조정 후 난이도에 따라 범위 변하도록 수정 필요
    }

}
