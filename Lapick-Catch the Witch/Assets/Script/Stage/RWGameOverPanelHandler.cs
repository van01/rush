using UnityEngine;
using System.Collections;

public class RWGameOverPanelHandler : MonoBehaviour {

    public GameObject playerCharacterWindow;
    public GameObject witchCharacterWindow;

    public GameObject newRecordTitle;
    public GameObject adsPopupCallButton;
    public GameObject adsSuccessMark;

    private GameObject tmpGameController;
    private GameObject currentPlayerCharacter;
    private GameObject currentWitchCharacter;

    public void CurrentCharacterInitialize()
    {
        tmpGameController = GameObject.Find("GameController");

        currentPlayerCharacter = Instantiate(tmpGameController.GetComponent<RWPlayerController>().currentPlayerCharacter, playerCharacterWindow.transform.position, playerCharacterWindow.transform.rotation)as GameObject;

        Destroy(currentPlayerCharacter.GetComponent<Rigidbody2D>());

        currentPlayerCharacter.SendMessage("CharacterStateControll", "Disorder");
        currentPlayerCharacter.SendMessage("RWPlayerCharacterAniSpeed", 1);

        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().currentEyeState = CharacterEyeHandler.EyeState.Chaos;
        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().CheckEyeState();

        currentPlayerCharacter.transform.SetParent(playerCharacterWindow.transform);
        currentPlayerCharacter.transform.localPosition = new Vector3(0, -100f, 0);

        currentWitchCharacter = Instantiate(tmpGameController.GetComponent<RWOpeningDirector>().currentWitchCharacter, witchCharacterWindow.transform.position, witchCharacterWindow.transform.rotation) as GameObject;
        
        currentWitchCharacter.GetComponent<Puppet2D_GlobalControl>().flip = false;

        currentWitchCharacter.transform.SetParent(witchCharacterWindow.transform);
        currentWitchCharacter.transform.localPosition = new Vector3(-50f, -100f, 0);

        ChangeLayersRecursively(currentPlayerCharacter.transform, "UI");
        ChangeLayersRecursively(currentWitchCharacter.transform, "UI");

        currentPlayerCharacter.tag = "UI_Character";
        currentWitchCharacter.tag = "UI_Character";

        currentPlayerCharacter.SendMessage("AllSpriteRendererSortingLayerUI");
        currentWitchCharacter.SendMessage("AllSpriteRendererSortingLayerUI");

        currentWitchCharacter.GetComponent<RWWitchHandler>().currentWitchState = RWWitchHandler.WitchState.Idle;
        currentWitchCharacter.GetComponent<RWWitchHandler>().CheckWitchState();
    }

    public static void ChangeLayersRecursively(Transform trans, string name)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            ChangeLayersRecursively(child, name);
        }
    }

    public void CurrentCharacterDestroy()
    {
        Destroy(currentPlayerCharacter);
        Destroy(currentWitchCharacter);
    }

    public void NewRecordTitleOn()
    {
        newRecordTitle.SetActive(true);
    }

    public void GameOverUIInitialize()
    {
        newRecordTitle.SetActive(false);
        adsSuccessMark.SetActive(false);

        adsPopupCallButton.SetActive(true); //시간에 따라 보이도록하는 기능 추가 필요
    }
    //public void 

    //두개 캐릭터 off 기능 및 on 기능 추가, on 시 애니메이션 재생되도록
    //currentPlayerCharacter.SendMessage("AllSpriteRendererSortingLayerUI");
    //    currentWitchCharacter.
}
