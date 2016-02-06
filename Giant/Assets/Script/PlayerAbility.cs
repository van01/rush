using UnityEngine;
using System.Collections;

public class PlayerAbility : MonoBehaviour
{

    PlayerParams myParams = new PlayerParams();

    public void SetParams(PlayerParams tParams)
    {
        myParams = tParams;
    }

    public PlayerParams GetParams()
    {
        return myParams;
    }
}
