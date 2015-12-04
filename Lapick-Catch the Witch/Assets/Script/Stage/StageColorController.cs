using UnityEngine;
using System.Collections;

public class StageColorController : MonoBehaviour {

    private SpriteRenderer[] myAllSpriteRenderer;
    public bool randomSpriteColorApply;

    private Vector4[] colorValue;
    private int randColorNum;

	void Awake () {
        if (randomSpriteColorApply == true)
        {
            ColorSetting();
            myAllSpriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();
        }
	}

    void ColorSetting()
    {
        colorValue = new Vector4[7];

        colorValue[0] = new Vector4(1.0f, 0.9f, 0.9f, 1.0f);
        colorValue[1] = new Vector4(1.0f, 0.9f, 0.8f, 1.0f);
        colorValue[2] = new Vector4(1.0f, 1.0f, 0.8f, 1.0f);
        colorValue[3] = new Vector4(0.9f, 1.0f, 0.8f, 1.0f);
        colorValue[4] = new Vector4(0.9f, 0.9f, 1.0f, 1.0f);
        colorValue[5] = new Vector4(0.7f, 0.7f, 0.8f, 1.0f);
        colorValue[6] = new Vector4(1.0f, 0.9f, 1.0f, 1.0f);
    }

    public void StageColorActive()
    {
        StageColorNumRand();
        for (int i = 0; i < myAllSpriteRenderer.Length; i++)
        {
            myAllSpriteRenderer[i].color = colorValue[randColorNum];
        }
    }

    void StageColorNumRand()
    {
        randColorNum = (int)Random.RandomRange(0f, colorValue.Length);
    }


}
