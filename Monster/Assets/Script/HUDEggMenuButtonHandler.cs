using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDEggMenuButtonHandler : MonoBehaviour {

    public GameObject eggImagePosition;
    public GameObject eggPriceTxt;

    private GameObject currentEggImage;

    private int currentEggNumber;

    public void MenuButtonInitialize(int nEggNumber)
    {
        currentEggImage = Instantiate(transform.parent.GetComponent<HUDEggScrollPanelHandler>().eggObjectArray[nEggNumber], transform.position, transform.rotation) as GameObject;
        currentEggImage.transform.localPosition = eggImagePosition.transform.position;
        currentEggImage.transform.SetParent(eggImagePosition.transform);

        eggImagePosition.GetComponent<Image>().sprite = currentEggImage.GetComponent<SpriteRenderer>().sprite;

        currentEggNumber = nEggNumber;

        GetComponent<Button>().onClick.AddListener(delegate { EggButtonCall(); });

        Destroy(currentEggImage);
    }

    void EggButtonCall()
    {
        transform.root.SendMessage("EggBuySuccessDelivery", currentEggNumber);
    }
}
