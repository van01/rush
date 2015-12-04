using UnityEngine;
using System.Collections;

public class StageFloorHandler : MonoBehaviour {

    public GameObject Floor;
    public GameObject RWFloor;

    public void FloorSetting(bool isRWStage)
    {
        if (isRWStage == true)
        {
            Floor.SetActive(false);
            RWFloor.SetActive(true);
        }
        else
        {
            Floor.SetActive(true);
            RWFloor.SetActive(false);
        }
    }
}
