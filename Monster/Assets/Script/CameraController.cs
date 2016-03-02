using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject mainCamera;

    void Start()
    {
        if (GetComponent<HUDController>().isSmallBottomPanel == true)
        {
            mainCamera.transform.position = new Vector3(0, 1.0f, -5.5f);
        }
        else
        {
            mainCamera.transform.position = new Vector3(0, 1.0f, -5.5f);
        }
    }
}
