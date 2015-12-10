using UnityEngine;
using System.Collections;

public class EggAbility : MonoBehaviour {

    EggParams myParams = new EggParams();
    protected EggParams eggParams;

    public int hatchMonsterNumber;

    public void SetParams(EggParams tParams)
    {
        myParams = tParams;
    }

    public EggParams GetParams()
    {
        return myParams;
    }
}
