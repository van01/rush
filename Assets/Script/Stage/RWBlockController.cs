using UnityEngine;
using System.Collections;

public class RWBlockController : MonoBehaviour {
    public GameObject blockPrefab;
    public int blockPrefabCount;

    private GameObject presentBlockPrefab;
    private GameObject oldBlockPrefab;
    private GameObject[] arrBlock;

    private Transform tmpBaseBlock;

    private int presentBlockPrefabColSizeX;
    private float oldBlockPrefabColSizeX;
    private float presentBlockPrefabPositionX;
    private float oldBlockPrefabPositionX;

    private float blockSpaceSizeX;
    private float blockSpaceSizeY;

    private GameObject[] tmpArrBlock;

    protected GameObject tmpGameController;

    protected int blockColMinSize = 3;
    protected int blockColMaxSize;
    protected float blockSpaceXMinSize;
    protected float blockSpaceXMaxSize = 0.75f;
    protected float blockSpaceYMinSize = 0;
    protected float blockSpaceYMaxSize = 0.4f;

    void Start()
    {
        tmpGameController = GameObject.Find("GameController");

        presentBlockPrefabColSizeX = 6;                 // 이번에 생성할 블럭의 collision 크기
        
        arrBlock = GameObject.FindGameObjectsWithTag("Block");

        tmpBaseBlock = transform.FindChild("BaseBlock");
    }

    public void BlockGeneraterInit()
    {
        oldBlockPrefabPositionX = tmpBaseBlock.GetComponent<BoxCollider2D>().offset.x + tmpBaseBlock.GetComponent<BoxCollider2D>().size.x / 2 - 0.1f;
        presentBlockPrefabPositionX = 6;
        oldBlockPrefab = null;

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
        presentBlockPrefabColSizeX = (int)Random.Range(blockColMinSize, blockColMaxSize);
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
        blockSpaceSizeX = Random.Range(blockSpaceXMinSize, blockSpaceXMaxSize);   //테스트용 블럭 간격, 난이도 조정 후 난이도에 따라 범위 변하도록 수정 필요
    }

    void RandomBlockSpaceSizeY()
    {
        blockSpaceSizeY = transform.position.y + Random.Range(blockSpaceYMinSize, blockSpaceYMaxSize);   //테스트용 블럭 높이, 난이도 조정 후 난이도에 따라 범위 변하도록 수정 필요
    }

    public void AllBlockDelete()
    {
        tmpArrBlock = new GameObject[blockPrefabCount];
        tmpArrBlock = GameObject.FindGameObjectsWithTag("Block");

        for (int i = 0; i < tmpArrBlock.Length; i++)
        {
            if (tmpArrBlock[i].name == "BaseBlock")
            {

            }
            else
            {
                Destroy(tmpArrBlock[i]);
            }
        }
    }

    public void BlockCountRiseDelivery()
    {
        tmpGameController.SendMessage("BlockCountRise");
    }

    //RandomPresentBlockcolSizeX    min, max
    //RandomBlockSpaceSizeX         min, max
    //RandomBlockSpaceSizeY         min, max
    //protected float blockSpaceXMinSize;
    //protected float blockSpaceXMaxSize;
    //protected float blockSpaceYMinSize;
    //protected float blockSpaceYMaxSize;

    public void PresentBlockColMinSizeX(int nMinSize)
    {
        blockColMinSize = nMinSize;
    }

    public void PresentBlockColMaxSizeX(int nMaxSize)
    {
        blockColMaxSize = nMaxSize;
    }

    public void PresentBlockSpaceMinSizeX(float nMinSize)
    {
        blockSpaceXMinSize = nMinSize;
    }

    public void PresentBlockSpaceMaxSizeX(float nMaxSize)
    {
        blockSpaceXMaxSize = nMaxSize;
    }

    public void PresentBlockSpaceMinSizeY(float nMinSize)
    {
        blockSpaceYMinSize = nMinSize;
    }

    public void PresentBlockSpaceMaxSizeY(float nMaxSize)
    {
        blockSpaceYMaxSize = nMaxSize;
    }
}
