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
        eggMenuButtonArray = new GameObject[eggBasket.GetComponent<EggBasket>().eggObjectArray.Length];
        EggScrollPanelInitialize();
    }

	public void EggScrollPanelInitialize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(330f, Mathf.Ceil(eggBasket.GetComponent<EggBasket>().eggObjectArray.Length / 2.0f) * 175);

        for (int i = 0; i < eggBasket.GetComponent<EggBasket>().eggObjectArray.Length; i++)
        {
            eggMenuButtonArray[i] = Instantiate(eggMenuButton, transform.position , transform.rotation) as GameObject;
            eggMenuButtonArray[i].transform.SetParent(transform);
            eggMenuButtonArray[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            eggMenuButtonArray[i].SendMessage("MenuButtonInitialize", i);

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
