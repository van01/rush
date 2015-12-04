using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RWHelmetRaffleWhitePanelHandler : MonoBehaviour {

    private Transform currentBoxTransform;

    void Start()
    {
        //GetComponent<Image>().sprite.lay  //image 최상위로 올릴 방법 고민
    }

    public void WhitePanelEffectActive(Transform nCurrentBoxTransform)
    {
        StartCoroutine("WhitePanelEffect");
        currentBoxTransform = nCurrentBoxTransform;
    }

    IEnumerator WhitePanelEffect()
    {
        yield return new WaitForSeconds(0.1f);

        for (float i = 0; i <= 1; i += 0.05f)
        {
            GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForFixedUpdate();
        }

        currentBoxTransform.SendMessage("TreasureBoxInitialize");

        for (float i = 1; i >= 0; i -= 0.02f)
        {
            GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForFixedUpdate();
        }

        transform.parent.SendMessage("WhitePanelOff");
    }
}
