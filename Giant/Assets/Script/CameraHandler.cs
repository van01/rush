using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public GameObject gameController;

    private float cameraAngleX;

    void Awake()
    {
        GameObject target;
        target = gameController.GetComponent<CharacterHandler>().targetObject;

        cameraAngleX =  - ((target.GetComponent<BoxCollider>().size.y * target.transform.localScale.y) / 2 + target.transform.position.y);

        transform.localEulerAngles = new Vector3(cameraAngleX, 0, 0);
    }
}
