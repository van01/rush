using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHomePanelHandler : MonoBehaviour {

    public GameObject monsterLevelTxt;

    public GameObject monsterNameTxt;

    public GameObject fatigueTxt;
    public GameObject stuffedTxt;

    public GameObject fatigueGauge;
    public GameObject stuffedGauge;
    

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

    private float _currentMonsterFatiguePoint;
    private float _currentMonsterStuffedPoint;

    void Awake()
    {
        tmpGameController = transform.root.GetComponent<HUDHandler>().tmpGameController;
    }

    public void MonsterInfoInitialIze()
    {
        if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.StandBy)
        {
            monsterLevelTxt.GetComponent<Text>().text = "0";
            monsterNameTxt.GetComponent<Text>().text = "-";

            stuffedGauge.GetComponent<Scrollbar>().size = 0;
            fatigueGauge.GetComponent<Scrollbar>().size = 0;

            statPowValue.GetComponent<Text>().text = "-";
            statVitValue.GetComponent<Text>().text = "-";
            statDexValue.GetComponent<Text>().text = "-";
            statAgrValue.GetComponent<Text>().text = "-";
            statIntValue.GetComponent<Text>().text = "-";
            statMalValue.GetComponent<Text>().text = "-";

            HomePanelCurrentMonsterInitialize();
        }

        else if (tmpGameController.GetComponent<GameState>().currentState == GameState.State.Egg)
        {
            tmpCurrentEgg = tmpGameController.GetComponent<EggController>().currentEgg;

            currentEggParams = tmpCurrentEgg.GetComponent<EggAbility>().GetParams();

            monsterLevelTxt.GetComponent<Text>().text = "0";
            monsterNameTxt.GetComponent<Text>().text = currentEggParams.name;

            stuffedGauge.GetComponent<Scrollbar>().size = 0;
            fatigueGauge.GetComponent<Scrollbar>().size = 0;

            statPowValue.GetComponent<Text>().text = "-";
            statVitValue.GetComponent<Text>().text = "-";
            statDexValue.GetComponent<Text>().text = "-";
            statAgrValue.GetComponent<Text>().text = "-";
            statIntValue.GetComponent<Text>().text = "-";
            statMalValue.GetComponent<Text>().text = "-";

            HomePanelCurrentMonsterInitialize();
        }
        else if ((tmpGameController.GetComponent<GameState>().currentState == GameState.State.Monster))
        {
            tmpCurrentMonster = tmpGameController.GetComponent<MonsterController>().currentMonster;

            currentMonsterParams = tmpCurrentMonster.GetComponent<MonsterAbility>().GetParams();

            monsterLevelTxt.GetComponent<Text>().text = currentMonsterParams.level.ToString();
            monsterNameTxt.GetComponent<Text>().text = currentMonsterParams.name;

            statPowValue.GetComponent<Text>().text = currentMonsterParams.statPow.ToString();
            statVitValue.GetComponent<Text>().text = currentMonsterParams.statVit.ToString();
            statDexValue.GetComponent<Text>().text = currentMonsterParams.statDex.ToString();
            statAgrValue.GetComponent<Text>().text = currentMonsterParams.statAgr.ToString();
            statIntValue.GetComponent<Text>().text = currentMonsterParams.statInt.ToString();
            statMalValue.GetComponent<Text>().text = currentMonsterParams.statMal.ToString();
        }
    }

    public void MonsterInfoStuffUpdate()
    {
        //배고픔 업데이트
        _currentMonsterStuffedPoint = currentMonsterParams.currentHunger / currentMonsterParams.hunger;
        stuffedGauge.GetComponent<Scrollbar>().size = _currentMonsterStuffedPoint;

        if (_currentMonsterStuffedPoint <= 0.2f)
            stuffedTxt.GetComponent<Text>().text = "매우 배고픔";
        else if (_currentMonsterStuffedPoint <= 0.4f)
            stuffedTxt.GetComponent<Text>().text = "배고픔";
        else if (_currentMonsterStuffedPoint <= 0.6f)
            stuffedTxt.GetComponent<Text>().text = "보통";
        else if (_currentMonsterStuffedPoint <= 0.8f)
            stuffedTxt.GetComponent<Text>().text = "배부름";
        else
            stuffedTxt.GetComponent<Text>().text = "매우 배부름";
    }

    public void MonsterInfoFatigueUpdate()
    {
        //피로도 업데이트
        _currentMonsterFatiguePoint = currentMonsterParams.currentFatigue / currentMonsterParams.fatigue;
        fatigueGauge.GetComponent<Scrollbar>().size = _currentMonsterFatiguePoint;

        if (_currentMonsterFatiguePoint <= 0.2f)
            fatigueTxt.GetComponent<Text>().text = "매우 상쾌함";
        else if (_currentMonsterFatiguePoint <= 0.4f)
            fatigueTxt.GetComponent<Text>().text = "상쾌함";
        else if (_currentMonsterFatiguePoint <= 0.6f)
            fatigueTxt.GetComponent<Text>().text = "보통";
        else if (_currentMonsterFatiguePoint <= 0.8f)
            fatigueTxt.GetComponent<Text>().text = "피곤함";
        else
            fatigueTxt.GetComponent<Text>().text = "매우 피곤함";
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
        {
            MonsterInfoStuffUpdate();
            MonsterInfoFatigueUpdate();
        }
    }

    public void HomePanelCurrentMonsterInitialize()
    {
        currentMonsterParams = null;
        Destroy(tmpCurrentMonster);
    }
}
