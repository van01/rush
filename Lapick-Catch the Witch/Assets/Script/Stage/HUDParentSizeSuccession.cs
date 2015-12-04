using UnityEngine;
using System.Collections;

public class HUDParentSizeSuccession : MonoBehaviour {

    public bool isParent;
    public bool isEffect;

    void Awake()
    {
        if (isParent == true)
        {
            if (isEffect == false)
                GetComponent<RectTransform>().sizeDelta = transform.parent.GetComponent<RectTransform>().sizeDelta;
            else
                GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x * transform.parent.GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().localScale.y * transform.parent.GetComponent<RectTransform>().sizeDelta.y, 10f);
        }
    }

    void Start () {
        if (isParent == false)
        {
            if (isEffect == false)
                GetComponent<RectTransform>().sizeDelta = transform.parent.GetComponent<RectTransform>().sizeDelta;
            else
                GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x * transform.parent.GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().localScale.y * transform.parent.GetComponent<RectTransform>().sizeDelta.y, 10f);
        }
    }
}
