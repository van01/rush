using UnityEngine;
using System.Collections;

public class RWBaseBlockHandler : MonoBehaviour {

    public GameObject baseBlock01;
    public GameObject baseBlock02;
    public GameObject baseBlock03;
    public float movePositionX = -5.0f;

    private float scrollSpeed;
    private bool scrollOnBaseBlock = false;

    private float beginBaseBlock01PositionX;
    private float beginBaseBlock02PositionX;
    private float beginBaseBlock03PositionX;

    void Start()
    {
        beginBaseBlock01PositionX = baseBlock01.transform.position.x;
        beginBaseBlock02PositionX = baseBlock02.transform.position.x;
        beginBaseBlock03PositionX = baseBlock03.transform.position.x;
    }

    void Update()
    {
        if (scrollOnBaseBlock == true)
        {
            Vector2 collScrollValue = Vector2.left * scrollSpeed * Time.deltaTime;
            Vector3 scrollValue = Vector3.left * scrollSpeed * Time.deltaTime;

            GetComponent<BoxCollider2D>().offset += collScrollValue;
            baseBlock01.transform.Translate(scrollValue, Space.World);
            baseBlock02.transform.Translate(scrollValue, Space.World);
            baseBlock03.transform.Translate(scrollValue, Space.World);


            if (baseBlock01.transform.position.x <= movePositionX)
            {
                baseBlock01.transform.position = new Vector3(baseBlock03.transform.position.x + baseBlock01.GetComponent<BoxCollider2D>().size.x, baseBlock01.transform.position.y, baseBlock01.transform.position.z);
                GetComponent<BoxCollider2D>().offset = new Vector2(baseBlock01.transform.position.x - 4.0f, 0);
            }
            if (baseBlock02.transform.position.x <= movePositionX)
            {
                baseBlock02.transform.position = new Vector3(baseBlock01.transform.position.x + baseBlock02.GetComponent<BoxCollider2D>().size.x, baseBlock02.transform.position.y, baseBlock02.transform.position.z);
                GetComponent<BoxCollider2D>().offset = new Vector2(baseBlock02.transform.position.x - 4.0f, 0);
            }
            if (baseBlock03.transform.position.x <= movePositionX)
            {
                baseBlock03.transform.position = new Vector3(baseBlock02.transform.position.x + baseBlock03.GetComponent<BoxCollider2D>().size.x, baseBlock03.transform.position.y, baseBlock03.transform.position.z);
                GetComponent<BoxCollider2D>().offset = new Vector2(baseBlock03.transform.position.x - 4.0f, 0);
            }
        }
    }

    public void DeliveryBaseBlockScrollSpeed(float fSC)
    {
        scrollSpeed = fSC;
    }

    public void ScrollOnBaseBlock()
    {
        scrollOnBaseBlock = true;
    }

    public void ScrollOffBaseBlock()
    {
        scrollOnBaseBlock = false;
    }

    public void BaseBlockDrop()
    {
        gameObject.SetActive(false);
    }

    public void BaseBlockInit()
    {
        GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);

        baseBlock01.transform.position = new Vector3 (-4f, -2.5f,0);
        baseBlock02.transform.position = new Vector3(0, -2.5f, 0);
        baseBlock03.transform.position = new Vector3(4, -2.5f, 0);      // 왜 2.5?
    }
}
