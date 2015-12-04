using UnityEngine;
using System.Collections;

public class RWReadyHandler : MonoBehaviour {

    public GameObject tmpGameController;

    public GameObject dummyCharacter;
    public GameObject dummyBlock;

    private SpriteRenderer[] myAllSpriteRenderer;
    private Vector4 _stageColor;

    public void ReadyPanelInitailize()
    {
        dummyCharacter.SendMessage("CharacterStateControll", "RWPlay");
        dummyCharacter.SendMessage("RWPlayerCharacterAniSpeed", 1.0f);

        myAllSpriteRenderer = dummyBlock.GetComponentsInChildren<SpriteRenderer>();

        _stageColor = tmpGameController.GetComponent<StageController>().presentStage.GetComponent<SpriteRenderer>().color;
        RWStageFloorColorApply(_stageColor);
    }

    void RWStageFloorColorApply(Vector4 nColor)
    {
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            if (myAllSpriteRenderer[i].GetComponent<StageBGColorApply>().BGColorApply == true)
            {
                myAllSpriteRenderer[i].color = nColor;
            }
        }
    }

    public void ReadyEnd()
    {
        transform.root.SendMessage("ReadyPanelActive");
    }
}
