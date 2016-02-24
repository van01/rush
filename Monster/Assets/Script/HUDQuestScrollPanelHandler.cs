using UnityEngine;
using System.Collections;

public class HUDQuestScrollPanelHandler : MonoBehaviour {

    public GameObject questBasket;
    public GameObject questMenuButton;

    public float questMenuButtonPositionY;

    public GameObject[] currentQuestArray;
    private GameObject[] questMenuButtonArray;

    void Start()
    {
        currentQuestArray = questBasket.GetComponent<QuestBasket>().currentQuestArray;
        questMenuButtonArray = new GameObject[currentQuestArray.Length];
        QuestScrollPanelInitialize();
    }

    public void QuestScrollPanelInitialize()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(330f, currentQuestArray.Length * 170);

        for (int i = 0; i < currentQuestArray.Length; i++)
        {
            questMenuButtonArray[i] = Instantiate(questMenuButton, transform.position, transform.rotation) as GameObject;
            questMenuButtonArray[i].transform.SetParent(transform);
            questMenuButtonArray[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            questMenuButtonArray[i].transform.localPosition = new Vector3(0, -questMenuButtonPositionY, 1);
            questMenuButtonPositionY = questMenuButtonPositionY + 170;

            questMenuButtonArray[i].SendMessage("QuestMenuButtonInitialize", i);
            
        }
    }
}
