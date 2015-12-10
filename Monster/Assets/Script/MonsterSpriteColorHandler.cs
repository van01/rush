using UnityEngine;
using System.Collections;

public class MonsterSpriteColorHandler : MonoBehaviour {

    public bool isSpriteColocActive;

    public bool isMeshRenderer;

    public void SpriteColorActive(Vector4 nApplyColor)
    {
        if (isMeshRenderer == true)
        {
            GetComponent<Renderer>().material.color = nApplyColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = nApplyColor;
        }
    }
}
