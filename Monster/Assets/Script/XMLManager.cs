using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.IO;
using System;

public class XMLManager : MonoBehaviour {

    static Dictionary<int, EggParams> dicEgg = new Dictionary<int, EggParams>();
    static Dictionary<int, MonsterParams> dicMonster = new Dictionary<int, MonsterParams>();
    static Dictionary<int, MonsterLevelParams> dicMonsterLevel = new Dictionary<int, MonsterLevelParams>();

    static Dictionary<int, MonsterLevelParams> dicCurrentMonsterLevel = new Dictionary<int, MonsterLevelParams>();

    public TextAsset eggXmlData;
    public TextAsset monsterXmlData;
    public TextAsset monsterLevelXmlData;

    void Awake () {
        MakeEggXML();
        MakeMonsterXML();
        MonsterLevelParamsXML();
    }
	
	void MakeEggXML()
    {
        XmlDocument eggXml = new XmlDocument();
        eggXml.LoadXml(eggXmlData.text);

        XmlNodeList eggNodeList = eggXml.GetElementsByTagName("row");

        foreach (XmlNode eggNode in eggNodeList)
        {
            EggParams tempParams = new EggParams();

            foreach (XmlNode childNode in eggNode.ChildNodes)
            {
                if (childNode.Name == "id")
                    tempParams.id = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "name")
                    tempParams.name = childNode.InnerText;
                if (childNode.Name == "hatchTime")
                    tempParams.hatchTime = Int16.Parse(childNode.InnerText);
            }

            dicEgg[tempParams.id] = tempParams;
        }
    }

    void MakeMonsterXML()
    {
        XmlDocument monsterXml = new XmlDocument();
        monsterXml.LoadXml(monsterXmlData.text);

        XmlNodeList monsterNodeList = monsterXml.GetElementsByTagName("row");

        foreach (XmlNode monsterNode in monsterNodeList)
        {
            MonsterParams tempParams = new MonsterParams();

            foreach (XmlNode childNode in monsterNode.ChildNodes)
            {
                if (childNode.Name == "id")
                    tempParams.id = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "name")
                    tempParams.name = childNode.InnerText;
                if (childNode.Name == "monType")
                    tempParams.monType = childNode.InnerText;
                if (childNode.Name == "minLevel")
                    tempParams.minLevel = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "fatigue")
                    tempParams.fatigue = float.Parse(childNode.InnerText);
                if (childNode.Name == "hunger")
                    tempParams.hunger = float.Parse(childNode.InnerText);
                if (childNode.Name == "statPow")
                    tempParams.statPow = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "statVit")
                    tempParams.statVit = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "statDex")
                    tempParams.statDex = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "statAgr")
                    tempParams.statAgr = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "statInt")
                    tempParams.statInt = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "statMal")
                    tempParams.statMal = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "monPrice")
                    tempParams.monPrice = Int16.Parse(childNode.InnerText);
            }
            dicMonster[tempParams.id] = tempParams;
        }
    }

    void MonsterLevelParamsXML()
    {
        XmlDocument monLevelXml = new XmlDocument();
        monLevelXml.LoadXml(monsterLevelXmlData.text);

        XmlNodeList monsterLevelList = monLevelXml.GetElementsByTagName("row");

        foreach (XmlNode monsterLevelNode in monsterLevelList)
        {
            MonsterLevelParams tempParams = new MonsterLevelParams();

            foreach (XmlNode childNode in monsterLevelNode.ChildNodes)
            {
                if (childNode.Name == "id")
                    tempParams.id = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "monType")
                    tempParams.monType = childNode.InnerText;
                if (childNode.Name == "level")
                    tempParams.level = Int16.Parse(childNode.InnerText);
                if (childNode.Name == "totalStat")
                    tempParams.totalStat = Int16.Parse(childNode.InnerText);
            }

            dicMonsterLevel[tempParams.id] = tempParams;
        }
    }

    public static EggParams GetEggParamsById(int reqId)
    {
        return dicEgg[reqId];
    }

    public static MonsterParams GetMonsterParamsById(int reqId)
    {
        return dicMonster[reqId];
    }

    public static MonsterLevelParams GetMonsterLevelParamsByMonType(string nMonType, int nLevel)
    {
        MonsterLevelParams tempParams = new MonsterLevelParams();

        foreach (KeyValuePair<int, MonsterLevelParams> kv in dicMonsterLevel)
        {
            if (nMonType == kv.Value.monType)
            {
                if (nLevel == kv.Value.level)
                {
                    return dicMonsterLevel[kv.Key];
                }
            }
        }

        return tempParams;
    }

    void Start()
    {
        
    }
}
