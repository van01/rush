using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDEggScrollPanelHandler : MonoBehaviour {

    public GameObject eggBasket;
    public GameObject eggMenuButton;

    public float eggMenuButtonPositionX;
    public float eggMenuButtonPositionY;

    public  GameObject[] eggObjectArray;
    private GameObject[] eggMenuButtonArray;

    void Start()
    {
        eggObjectArray = eggBasket.GetComponent<EggBasket>().eggObjectArray;
        eggMenuButtonArray = new GameObject[eggObjectArray.Length];
        EggScrollPanelInitialize();
    }

	public void EggScrollPanelInitialize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(330f, Mathf.Ceil(eggObjectArray.Length / 2.0f) * 170);
        //스크롤 사이즈 조정, 175 = 버튼 사이즈 170 + 위+아래 여백 5

        for (int i = 0; i < eggObjectArray.Length; i++)
        {
            eggMenuButtonArray[i] = Instantiate(eggMenuButton, transform.position , transform.rotation) as GameObject;
            eggMenuButtonArray[i].transform.SetParent(transform);
            eggMenuButtonArray[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            eggMenuButtonArray[i].SendMessage("EggMenuButtonInitialize", i);

            if ((i + 1) % 2 == 1)
            {
                eggMenuButtonArray[i].transform.localPosition = new Vector3(-eggMenuButtonPositionX, -eggMenuButtonPositionY, 1);
            }
            else
            {
                eggMenuButtonArray[i].transform.localPosition = new Vector3(eggMenuButtonPositionX, -eggMenuButtonPositionY, 1);
                eggMenuButtonPositionY = eggMenuButtonPositionY + 170f;
            }                
        }
    }
}
