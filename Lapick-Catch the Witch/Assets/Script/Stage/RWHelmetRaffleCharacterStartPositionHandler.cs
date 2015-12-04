using UnityEngine;
using System.Collections;

public class RWHelmetRaffleCharacterStartPositionHandler : MonoBehaviour {

    public GameObject tmpRaffleButton;
    public GameObject tmpTreasureBox;

    private float localPosionY;

    public bool isCompulsionResultCall;

    void Awake()
    {
        localPosionY = tmpRaffleButton.GetComponent<RectTransform>().localPosition.y + tmpTreasureBox.GetComponent<Transform>().localPosition.y;
        GetComponent<RectTransform>().localPosition = new Vector3 (GetComponent<RectTransform>().localPosition.x, localPosionY + 100f, GetComponent<RectTransform>().localPosition.z);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "UI_Character")
        {
            if (isCompulsionResultCall == true)
            {
                tmpRaffleButton.SendMessage("AttackButtonEnd");
            }
        }
    }
}
