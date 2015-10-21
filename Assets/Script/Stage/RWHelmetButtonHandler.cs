using UnityEngine;
using System.Collections;

public class RWHelmetButtonHandler : MonoBehaviour
{
    public enum HelmetButtonState
    {
        Lock,
        Active,
    }

    public HelmetButtonState currentHelmetButtonState;

    public int helmetNumber;

    public GameObject selectImage;  

    private GameObject tmpHelmetSelectPanal;
    private GameObject presentPlayerCharacter;
    private GameObject PlayerCharacter;

    private int appearHelmetNumber;

    void Start()
    {
        tmpHelmetSelectPanal = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

        CharacterDraw();
        if (helmetNumber > 4)
            CharacterOff();
    }

    public void HelmetSelectButtonActive()
    {
        if (currentHelmetButtonState == HelmetButtonState.Active)
        {
            tmpHelmetSelectPanal.SendMessage("HelmetButtonSelect", helmetNumber);
            tmpHelmetSelectPanal.SendMessage("HelmetNumberDelivery", helmetNumber);
        }
        else
        {
            print("Character Select Error Popup");
            PresentPlayerActive();
        }
    }

    public void SelectImageOn()
    {
        selectImage.SetActive(true);
    }

    public void SelectImageOff()
    {
        selectImage.SetActive(false);
    }

    public void HelmetSelectButtonUnLock()
    {
        currentHelmetButtonState = HelmetButtonState.Active;
        //LockImage.SetActive(false);
    }

    public void HelmetNumberSetting(int nHelmetNumber)
    {
        helmetNumber = nHelmetNumber;
    }

    void CharacterDraw()
    {
        PlayerCharacter = tmpHelmetSelectPanal.GetComponent<RWHelmetPanelHandler>().tmpGameController.GetComponent<RWPlayerController>().playerCharacter[0];
        presentPlayerCharacter = Instantiate(PlayerCharacter, transform.position, transform.rotation) as GameObject;
        presentPlayerCharacter.SendMessage("HealthBarInitOff");
        presentPlayerCharacter.transform.SetParent(transform);
        presentPlayerCharacter.transform.localScale = new Vector3(250f, 250f, 250f);
        presentPlayerCharacter.transform.localPosition = new Vector3(0, 100f, 0);
        ChangeLayersRecursively(presentPlayerCharacter.transform, "UI");
        presentPlayerCharacter.SendMessage("AllSpriteRendererSortingLayerUI");

        presentPlayerCharacter.GetComponent<CharacterWeaponHandler>().weponRNumber = -1;
        presentPlayerCharacter.GetComponent<CharacterWeaponHandler>().UseWeaponInialize();
        presentPlayerCharacter.GetComponent<CharacterBackHandler>().backNumber = -1;

        presentPlayerCharacter.SendMessage("EquipHelmet", appearHelmetNumber);

        presentPlayerCharacter.GetComponent<BoxCollider2D>().isTrigger = true;

        Destroy(presentPlayerCharacter.GetComponent<Rigidbody2D>());
        //Destroy(presentPlayerCharacter.GetComponent<BoxCollider2D>());


        Destroy(presentPlayerCharacter.GetComponent<PlayerAI>());
        Destroy(presentPlayerCharacter.GetComponent<PlayerAbility>());
        Destroy(presentPlayerCharacter.GetComponent<PlayerBattle>());

        if (currentHelmetButtonState == HelmetButtonState.Lock)
            CharacterDisable();

        presentPlayerCharacter.tag = "UI_Character";
        
    }

    public static void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }

    public void AppearHelmetNumberDelivery(int nHelmetNumber)
    {
        appearHelmetNumber = nHelmetNumber;
    }

    void CharacterDisable()
    {
        presentPlayerCharacter.SendMessage("CharacterDisable");
        presentPlayerCharacter.SendMessage("AniStop");
    }

    public void CharacterOff()
    {
        presentPlayerCharacter.SetActive(false);
    }

    public void CharacterOn()
    {
        presentPlayerCharacter.SetActive(true);
    }

    public void PresentPlayerCharacterStateChange(string nState)
    {
        presentPlayerCharacter.SendMessage("CharacterStateControll", nState);
    }

    void PresentPlayerActive()
    {
        presentPlayerCharacter.SendMessage("CharacterAble");
        currentHelmetButtonState = HelmetButtonState.Active;
        //상위로 전달
    }
}
