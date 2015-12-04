using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDOpeningTextEffect : MonoBehaviour {

    public GameObject openingText;
    private bool isPlus = false;

    // Use this for initialization
    void Start () {
        StartCoroutine(DisplayOpeningTextOff());
	}

    IEnumerator DisplayOpeningTextOff()
    {
        yield return new WaitForSeconds(0);

        for (float i = 1; i >= 0; i -= 0.03f)
        {
            openingText.GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForFixedUpdate();
            if (i <= 0.05)
                StartCoroutine(DisplayOpeningTextOn());
        }
    }

    IEnumerator DisplayOpeningTextOn()
    {
        yield return new WaitForSeconds(0);

        for (float i = 0; i <= 1; i += 0.03f)
        {
            openingText.GetComponent<Text>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            yield return new WaitForFixedUpdate();
            if (i >= 0.95)
                StartCoroutine(DisplayOpeningTextOff());
        }
    }
}
