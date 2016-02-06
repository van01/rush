using UnityEngine;
using System.Collections;

public class EnemyParams : CharacterParams
{

    public int moneyBonus { get; set; }

    public EnemyParams()
    {
        this.name = "테스트 골렘";
        this.id = 0;
        this.maxHP = 500;
        this.curHP = this.maxHP;
        this.attack = 5;
        this.moneyBonus = 100;
    }
}
