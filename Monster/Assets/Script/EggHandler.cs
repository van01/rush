using UnityEngine;
using System.Collections;

public class EggHandler : MonoBehaviour
{

    public void CurrentEggItchyDelivery()
    {
        transform.root.SendMessage("CurrentEggItchy");
    }

    public void CurrentEggEndDelivery()
    {
        transform.root.SendMessage("CurrentEggEnd");
    }
}
