using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDEggMenuButtonHandler : MonoBehaviour {

    public GameObject eggImagePosition;
    public GameObject eggPriceTxt;

    private GameObject currentEggImage;

    public void MenuButtonInitialize(int nEggNumber)
    {
        currentEggImage = Instantiate(transform.parent.GetComponent<HUDEggScrollPanelHandler>().eggObjectArray[nEggNumber], transform.position, transform.rotation) as GameObject;
        currentEggImage.transform.localPosition = eggImagePosition.transform.position;
        currentEggImage.transform.SetParent(eggImagePosition.transform);

        eggImagePosition.GetComponent<Image>().sprite = currentEggImage.GetComponent<SpriteRenderer>().sprite;

        Destroy(currentEggImage);
    }
}
