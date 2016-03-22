using UnityEngine;
using System.Collections;

public class TrainingController : MonoBehaviour {

    private GameObject _currentMonster;
    private MonsterParams _cParams;

    public enum TrainingType
    {
        Pow,
        Vit,
        Dex,
        Agr,
        Int,
    }

    public TrainingType currentTraining;

    public void CheckTrainingType()
    {
        switch (currentTraining)
        {
            case TrainingType.Pow:
                PowAction();
                break;
            case TrainingType.Vit:
                VitAction();
                break;
            case TrainingType.Dex:
                DexAction();
                break;
            case TrainingType.Agr:
                AgrAction();
                break;
            case TrainingType.Int:
                IntAction();
                break;
        }
    }

    public GameObject trainingDramaticHandler;

    private int _currentMountValue;
    private int _currentTrainingTurnMountTotalValue;

    public void MonsterPowTraining()
    {
        TrainingInitialize();

        currentTraining = TrainingType.Pow;
        CheckTrainingType();
    }

    public void TrainingInitialize()
    {
        //훈련 시작
        _currentMonster = GetComponent<MonsterController>().currentMonster;

        //모든 UIclose
        SendMessage("HUDHideDelivery");

        GetComponent<GameState>().currentState = GameState.State.RoomOut;
        GetComponent<GameState>().CheckGameState();

        //훈련 시작 시 배고픔 멈춤
        SendMessage("CurrentMonsterHungryStopDilevery");
    }

    public void TrainingEnd()
    {
        //훈련 완료

        SendMessage("HUDInitializeDelivery"); //UI 복원
        GetComponent<MonsterController>().currentMonster.SendMessage("TrainingComplete");
        GetComponent<MonsterController>().currentMonster.SendMessage("HungryPlay");

        GetComponent<GameState>().currentState = GameState.State.MonsterEnd;
        GetComponent<GameState>().CheckGameState();


        switch (currentTraining)
        {
            case TrainingType.Pow:
                trainingDramaticHandler.GetComponent<TrainingDramaticHandler>().SendMessage("PowDirectionDestroy");
                break;
            case TrainingType.Vit:
                VitAction();
                break;
            case TrainingType.Dex:
                DexAction();
                break;
            case TrainingType.Agr:
                AgrAction();
                break;
            case TrainingType.Int:
                IntAction();
                break;
        }
        SendMessage("MonsterRestorePosition");     //진짜 현재 몬스터 복구

        SendMessage("NextEvolutionMonsterCheck");
    }


    void PowAction()
    {
        //현재 트레이닝 비용 및 레벨 불러오기, 이번 트레이닝에서 증가될 능력치 계산
		//배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요. (배경 바꾸기는 gamestate)

        //연출 호출
        trainingDramaticHandler.SendMessage("PowDirectionStart");
        _currentMountValue = PowTrainingValue();
    }

    void VitAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    void DexAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    void AgrAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    void IntAction()
    {
        //배경 바꾸기, 캐릭터 상태 바꾸기 추가 필요
    }

    public bool TrainingSuccessJudgment()
    {
        //훈련 성공여부 판단
        bool isTriningSuccess;
        float _currentHungerPoint;
        float _currentFatiguePoint;

        float _currentchanceValue;
        float _chanceMaxValue = 2.0f;

        _currentchanceValue = Random.RandomRange(0, _chanceMaxValue);

        _cParams = _currentMonster.GetComponent<MonsterAbility>().GetParams();

        _currentHungerPoint = _cParams.currentHunger / _cParams.hunger;
        _currentFatiguePoint = 1 - _cParams.currentFatigue / _cParams.fatigue;

        if (_currentchanceValue <= _currentHungerPoint + _currentFatiguePoint)
        {
            isTriningSuccess = true;
            TrainingSuccessCurrentValueMount();
        }
        else
            isTriningSuccess = false;

        return isTriningSuccess;
    }

    public int PowTrainingValue()
    {
        //훈련장 Level에 따라 판단, 회당 증가될 힘의 크기
        return 3;
    }

    protected void TrainingSuccessCurrentValueMount()
    {
        //GetComponent<MonsterAbility>().myParams.statPow += 20;
        _currentTrainingTurnMountTotalValue += _currentMountValue;
    }

    public void CurrentTrainingTurnMountTotalValueInitialize()
    {
        _currentTrainingTurnMountTotalValue = 0;
    }

    public int TrainingResultTotalValue()
    {
        return _currentTrainingTurnMountTotalValue;
    }
}
