using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHomePanelHandler : MonoBehaviour {

    public GameObject monsterLevelTxt;

    public GameObject monsterNameTxt;

    public GameObject stuffedTxt;

    public GameObject stuffedGauge;
    public GameObject stressGauge;

    public GameObject statPowValue;
    public GameObject statVitValue;
    public GameObject statDexValue;
    public GameObject statAgrValue;
    public GameObject statIntValue;
    public GameObject statMalValue;

    private GameObject tmpGameController;
    private GameObject tmpCurrentMonster;
    private GameObject tmpCurrentEgg;

    protected EggParams currentEggParams;
    protected MonsterParams currentMonsterParams;

    void Awake()
    {
        tmpGameController = transform.root.GetComponent<HUDHandler>().tmpGameController;
    }

    public void MonsterInfoInitialIze()
    {
        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.StandBy)
        {
            monsterNameTxt.GetComponent<Text>().text = "-";

            stuffedGauge.GetComponent<Scrollbar>().size = 0;
            stressGauge.GetComponent<Scrollbar>().size = 0;

            statPowValue.GetComponent<Text>().text = "-";
            statVitValue.GetComponent<Text>().text = "-";
            statDexValue.GetComponent<Text>().text = "-";
            statAgrValue.GetComponent<Text>().text = "-";
            statIntValue.GetComponent<Text>().text = "-";
            statMalValue.GetComponent<Text>().text = "-";
        }

        else if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.Egg)
        {
            tmpCurrentEgg = tmpGameController.GetComponent<EggController>().currentEgg;

            currentEggParams = tmpCurrentEgg.GetComponent<EggAbility>().GetParams();
            monsterNameTxt.GetComponent<Text>().text = currentEggParams.name;

            stuffedGauge.GetComponent<Scrollbar>().size = 0;
            stressGauge.GetComponent<Scrollbar>().size = 0;

            statPowValue.GetComponent<Text>().text = "-";
            statVitValue.GetComponent<Text>().text = "-";
            statDexValue.GetComponent<Text>().text = "-";
            statAgrValue.GetComponent<Text>().text = "-";
            statIntValue.GetComponent<Text>().text = "-";
            statMalValue.GetComponent<Text>().text = "-";
        }
        else if ((tmpGameController.GetComponent<GameState>().currentState == GameState.State.Monster))
        {
            tmpCurrentMonster = tmpGameController.GetComponent<MonsterController>().currentMonster;

            currentMonsterParams = tmpCurrentMonster.GetComponent<MonsterAbility>().GetParams();
            monsterNameTxt.GetComponent<Text>().text = currentMonsterParams.name;

            statPowValue.GetComponent<Text>().text = currentMonsterParams.statPow.ToString();
            statVitValue.GetComponent<Text>().text = currentMonsterParams.statVit.ToString();
            statDexValue.GetComponent<Text>().text = currentMonsterParams.statDex.ToString();
            statAgrValue.GetComponent<Text>().text = currentMonsterParams.statAgr.ToString();
            statIntValue.GetComponent<Text>().text = currentMonsterParams.statInt.ToString();
            statMalValue.GetComponent<Text>().text = currentMonsterParams.statMal.ToString();

            stuffedGauge.GetComponent<Scrollbar>().size = 1.0f;
        }
    }

    public void MonsterInfoStuffUpdate()
    {
        //배고픔 업데이트
        stuffedGauge.GetComponent<Scrollbar>().size = currentMonsterParams.currentHunger / currentMonsterParams.hunger;

        if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.2f)
            stuffedTxt.GetComponent<Text>().text = "매우 배고픔";
        else if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.4f)
            stuffedTxt.GetComponent<Text>().text = "배고픔";
        else if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.6f)
            stuffedTxt.GetComponent<Text>().text = "보통";
        else if (currentMonsterParams.currentHunger / currentMonsterParams.hunger <= 0.8f)
            stuffedTxt.GetComponent<Text>().text = "배부름";
        else
            stuffedTxt.GetComponent<Text>().text = "매우 배부름";
    }

    public void MonsterInfoStressUpdate()
    {
        //스트레스 업데이트
    }

    public void MonsterInfoStatUpdate()
    {
        //스탯 업데이트
        statPowValue.GetComponent<Text>().text = currentMonsterParams.statPow.ToString();
        statVitValue.GetComponent<Text>().text = currentMonsterParams.statVit.ToString();
        statDexValue.GetComponent<Text>().text = currentMonsterParams.statDex.ToString();
        statAgrValue.GetComponent<Text>().text = currentMonsterParams.statAgr.ToString();
        statIntValue.GetComponent<Text>().text = currentMonsterParams.statInt.ToString();
        statMalValue.GetComponent<Text>().text = currentMonsterParams.statMal.ToString();
    }

    void Update()
    {
        if (currentMonsterParams != null)
            MonsterInfoStuffUpdate();
    }
}
