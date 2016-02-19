using UnityEngine;
using System.Collections;

public class CharacterMonParams
{
    public int id { get; set; }
    public string name { get; set; }
    public string monType { get; set; }

    public float stress { get; set; }
    public float hunger { get; set; }

    public float currentStress { get; set; }
    public float currentHunger { get; set; }

    public int statPow { get; set; }    //힘, 기사
    public int statVit { get; set; }    //체력, HP
    public int statDex { get; set; }    //손재주, 궁수
    public int statAgr { get; set; }    //민첩, 도둑
    public int statInt { get; set; }    //지능, 마법사
    public int statMal { get; set; }    //악의, 천사/악마

    public int monPrice { get; set; }    //몬스터 가격
}
