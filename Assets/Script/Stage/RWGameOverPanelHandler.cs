using UnityEngine;
using System.Collections;

public class RWGameOverPanelHandler : MonoBehaviour {

    public GameObject playerCharacterWindow;
    public GameObject witchCharacterWindow;

    private GameObject tmpGameController;
    private GameObject currentPlayerCharacter;
    private GameObject currentWitchCharacter;

    public void CurrentCharacterInitialize()
    {
        tmpGameController = GameObject.Find("GameController");

        currentPlayerCharacter = Instantiate(tmpGameController.GetComponent<RWPlayerController>().currentPlayerCharacter, playerCharacterWindow.transform.position, playerCharacterWindow.transform.rotation)as GameObject;
        currentPlayerCharacter.transform.localPosition = new Vector3(currentPlayerCharacter.transform.position.x, 1.3f, currentPlayerCharacter.transform.position.z);

        Destroy(currentPlayerCharacter.GetComponent<Rigidbody2D>());

        currentPlayerCharacter.SendMessage("CharacterStateControll", "Disorder");
        currentPlayerCharacter.SendMessage("RWPlayerCharacterAniSpeed", 1);

        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().currentEyeState = CharacterEyeHandler.EyeState.Chaos;
        currentPlayerCharacter.GetComponent<CharacterEyeHandler>().CheckEyeState();

        currentPlayerCharacter.transform.SetParent(playerCharacterWindow.transform);


        currentWitchCharacter = Instantiate(tmpGameController.GetComponent<RWOpeningDirector>().currentWitchCharacter, witchCharacterWindow.transform.position, witchCharacterWindow.transform.rotation) as GameObject;
        
        currentWitchCharacter.transform.localPosition = new Vector3(currentWitchCharacter.transform.position.x - 0.4f, 1.3f, currentWitchCharacter.transform.position.z);
        currentWitchCharacter.GetComponent<Puppet2D_GlobalControl>().flip = false;

        currentWitchCharacter.transform.SetParent(witchCharacterWindow.transform);

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
}
