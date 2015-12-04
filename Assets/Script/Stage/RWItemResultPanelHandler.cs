using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RWItemResultPanelHandler : MonoBehaviour {

    public GameObject presentCharacterPoseedor;

    public GameObject ItemHandler;
    public GameObject HelmetNameText;

    private GameObject PlayerCharacter;
    private GameObject presentPlayerCharacter;

    private int presentGetHelmetNumber;

    public void ResultCharacterInitalize()
    {
        PlayerCharacter = presentCharacterPoseedor.GetComponent<RWHelmetRafflePanelHandler>().PlayerCharacter;

        presentPlayerCharacter = Instantiate(PlayerCharacter, transform.position, transform.rotation) as GameObject;
        Destroy(presentPlayerCharacter.GetComponent<Rigidbody2D>());
        presentPlayerCharacter.GetComponent<BoxCollider2D>().isTrigger = true;
        presentPlayerCharacter.transform.SetParent(transform);
        presentPlayerCharacter.transform.localPosition = new Vector3(0, 125f, 0);
        presentPlayerCharacter.transform.localScale = new Vector3(350, 350f, 350f);
        presentPlayerCharacter.SendMessage("EquipHelmet", presentGetHelmetNumber);
        HelmetNameText.GetComponent<Text>().text = ItemHandler.GetComponent<CharacterHelmetBasket>().CharacterHelmetName[presentGetHelmetNumber];

        print(presentGetHelmetNumber);

        ChangeLayersRecursively(presentPlayerCharacter.transform, "UI");
        presentPlayerCharacter.SendMessage("AllSpriteRendererSortingLayerUI");

        presentPlayerCharacter.SendMessage("CharacterStateControll", "RWPlay");
        presentPlayerCharacter.SendMessage("RWPlayerCharacterAniSpeed", 1);
    }

    public void ResultCharacterDestroy()
    {
        Destroy(presentPlayerCharacter);
    }

    public static void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }

    public void PresentGetHelmetNumberSetting(int nGetHelmetNumber)
    {
        presentGetHelmetNumber = nGetHelmetNumber;
    }

    public void RWHelmetRaffleResultActiveDelivery()
    {
        transform.parent.SendMessage("RWHelmetRaffleResultActive", presentGetHelmetNumber);
        transform.parent.SendMessage("ResultPanelCloseActive");
        transform.parent.transform.parent.SendMessage("HelmetRaffleCloseButtonActive");
        //HelmetRaffleCloseButtonActive
    }
}
