using UnityEngine;
using System.Collections;

public class PlayerParams : CharacterParams
{

    public PlayerParams()
    {
        this.name = "유니티";
        this.id = 0;

        this.maxHP = 500;
        this.curHP = this.maxHP;
        this.attack = 5;
    }
}
