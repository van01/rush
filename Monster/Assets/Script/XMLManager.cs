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

    public TextAsset eggXmlData;
    public TextAsset monsterXmlData;

    void Awake () {
        MakeEggXML();
        MakeMonsterXML();
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
                if (childNode.Name == "stress")
                    tempParams.stress = float.Parse(childNode.InnerText);
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

    public static EggParams GetEggParamsById(int reqId)
    {
        return dicEgg[reqId];
    }

    public static MonsterParams GetMonsterParamsById(int reqId)
    {
        return dicMonster[reqId];
    }
}
