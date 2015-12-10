using UnityEngine;
using System.Collections;

public class MonsterSpriteColorController : MonoBehaviour {

    private MonsterSpriteColorHandler[] myAllSpriteColorHandler;
    private Vector4 applyColor;

    void Awake()
    {
        myAllSpriteColorHandler = GetComponentsInChildren<MonsterSpriteColorHandler>();
    }

    void MonsterColorApply()
    {
        for (int i = 0; i < myAllSpriteColorHandler.Length; i++)
        {
            if (myAllSpriteColorHandler[i].GetComponent<MonsterSpriteColorHandler>().isSpriteColocActive == true)
            {
                myAllSpriteColorHandler[i].SendMessage("SpriteColorActive", applyColor);
            }
        }
    }

    public void MonsterSpriteColorApplyDelivery(Vector4 nColor)
    {
        applyColor = nColor;

        MonsterColorApply();
    }
}
