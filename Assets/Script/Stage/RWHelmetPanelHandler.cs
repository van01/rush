using UnityEngine;
using System.Collections;

public class RWHelmetPanelHandler : MonoBehaviour {
    public GameObject tmpGameController;
    public GameObject tmpItemHandler;
    public GameObject helmetBasket;
    public float helmetEntityWidthSize;

    public GameObject helmetEntityPrefab;
    private GameObject[] presentHelmetEntity;

    private float helmetBasketWidthSize;
    private float helmetBasketHeightSize;

    private int helmetSpriteCount;

    private Vector3 helmetEntityPosition;

    private float baseHelmetBasketPositionX;

    void Awake()
    {
        helmetSpriteCount = tmpItemHandler.GetComponent<CharacterHelmetBasket>().CharacterHelmetSprite.Length;
        presentHelmetEntity = new GameObject[helmetSpriteCount];
    }

    void Start()
    {
        helmetBasketWidthSize = helmetEntityWidthSize * helmetSpriteCount;
        helmetBasketHeightSize = helmetBasket.GetComponent<RectTransform>().sizeDelta.y;

        helmetBasketInitialize();
    }

    void helmetBasketInitialize()
    {
        helmetBasket.GetComponent<RectTransform>().sizeDelta = new Vector2(helmetBasketWidthSize, helmetBasketHeightSize);
        helmetEntityPosition = new Vector3(0 - ((helmetBasketWidthSize / 2) - helmetEntityWidthSize / 2), 0,0);

        baseHelmetBasketPositionX = helmetEntityPosition.x * -1;
        for (int i = 0; i < helmetSpriteCount; i++)
        {
            presentHelmetEntity[i] = Instantiate(helmetEntityPrefab, helmetBasket.transform.position, helmetBasket.transform.rotation) as GameObject;
            presentHelmetEntity[i].GetComponent<RectTransform>().SetParent(helmetBasket.transform);
            presentHelmetEntity[i].GetComponent<RectTransform>().localPosition = helmetEntityPosition;
            presentHelmetEntity[i].GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);

            presentHelmetEntity[i].GetComponent<RWHelmetButtonHandler>().helmetNumber = i;

            presentHelmetEntity[i].SendMessage("AppearHelmetNumberDelivery", i);

            presentHelmetEntity[i].tag = "UI_Character";

            helmetEntityPosition = helmetEntityPosition + new Vector3(helmetEntityWidthSize, 0, 0);
        }

        helmetBasket.GetComponent<RectTransform>().localPosition = new Vector3(baseHelmetBasketPositionX, 0, 0);
    }
}
