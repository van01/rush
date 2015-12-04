using UnityEngine;
using System.Collections;

public class HUDParentSizeSuccession : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<RectTransform>().sizeDelta = transform.parent.GetComponent<RectTransform>().sizeDelta;
	}
}
